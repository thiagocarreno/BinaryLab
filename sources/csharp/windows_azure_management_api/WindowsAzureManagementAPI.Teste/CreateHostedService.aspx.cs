using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.Text;
using System.IO;

namespace Teste
{
    public partial class Default : System.Web.UI.Page
    {
        //information needed for the Windows Azure Service Management RESTful API
        private const string azureSubscriptionID = "28c67d1c-6da5-4a24-8a8f-b4af1f470bb9";
        private const string azureCertificateThumbprint = "c5 60 2f cf 8a c2 e2 42 0f cc 8c 09 9e 20 54 79 0f 68 ad ab";
        private const string azureManagementServiceBaseURI = "https://management.core.windows.net";
        private const string azureHostedServicesURI = "services/hostedservices";

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadPage();
        }

        private void LoadPage()
        {
            var teste = CreateHostedService("thiagoteste");
        }

        public X509Certificate2 GetManagementCertificate(string certificateThumbprint)
        {
            var certificateStore = new X509Store(StoreName.My, StoreLocation.LocalMachine);

            try
            {
                certificateStore.Open(OpenFlags.ReadOnly);

                //search the store and return a collection of matching certificates
                X509Certificate2Collection col = certificateStore.Certificates.Find(X509FindType.FindByThumbprint, certificateThumbprint, false);

                //ensure a certificate was found
                if (col.Count > 0)
                {
                    //return the first certificate in the collection - there should only be one because we are searching by thumbprint which is unique
                    X509Certificate2 cert = col[0];
                    return cert;
                }
                else
                {
                    throw new InvalidOperationException("The requested certificate was not found in your certificate store.");
                }
            }
            finally
            {
                certificateStore.Close();
            }
        }

        public string CreateHostedService(string serviceName)
        {
            try
            {
                //build the complete request URI
                string requestURI = string.Format("{0}/{1}/{2}", azureManagementServiceBaseURI, azureSubscriptionID, azureHostedServicesURI);

                //create the web request
                HttpWebRequest request = WebRequest.Create(requestURI) as HttpWebRequest;

                //get the certificate and add it to the request
                X509Certificate2 cert = GetManagementCertificate(azureCertificateThumbprint);
                request.ClientCertificates.Add(cert);

                //create the request headers and specify the method required for this type of operation
                request.Headers.Add("x-ms-version", "2010-10-28");
                request.ContentType = "application/xml";
                request.Method = "POST";

                //create the request body
                string requestBody = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                                     "<CreateHostedService xmlns=\"http://schemas.microsoft.com/windowsazure\">" +
                                     "<ServiceName>" + serviceName + "</ServiceName>" +
                                     "<Label>" + Convert.ToBase64String(Encoding.UTF8.GetBytes("v1.0")) + "</Label>" +
                                     "<Location>" + "North Central US" + "</Location>" +
                                     "</CreateHostedService>";

                byte[] byteArray = Encoding.UTF8.GetBytes(requestBody);
                request.ContentLength = byteArray.Length;

                //write the data to the stream that holds the request body content
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                //get the response  
                string responseStatus = string.Empty;
                string responseBody = string.Empty;

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    //get the response status 
                    responseStatus = response.StatusCode.ToString();

                    //get the response body
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        responseBody = reader.ReadToEnd();
                    }
                }

                return "Response Status: " + responseStatus + "\r\nResponse Body: " + responseBody;
            }

            catch (WebException ex)
            {
                if (((HttpWebResponse)ex.Response).StatusCode == HttpStatusCode.Conflict)
                {
                    //The HTTP (409) Conflict error will occur when a hosted service with same the namespace already exists
                    throw new InvalidOperationException(string.Format("A hosted service with the DNS prefix [{0}] already exists.", serviceName));
                }
                else
                {
                    throw ex;
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace ConvertCertificate
{
    class Program
    {
        static void Main(string[] args)
        {
            ConvertCerToPfx(@"C:\Users\carrenot\Desktop\mynw-us-en.cloudapp.net.cer", @"C:\Users\carrenot\Desktop\mynw-us-en.cloudapp.net.pfx", "WT@123456");
        }

        static void ConvertCerToPfx(string pathCer, string pathPfx, string password)
        {
            string msg = String.Empty;

            try
            {
                if (!String.IsNullOrEmpty(pathCer) && !String.IsNullOrEmpty(pathPfx) && !String.IsNullOrEmpty(password))
                {
                    X509Certificate cert = new X509Certificate(pathCer);
                    byte[] certData = cert.Export(X509ContentType.Pkcs12, password);

                    File.WriteAllBytes(pathPfx, certData);
                    msg = "Certificado convertido com sucesso.";
                }
                else
                {
                    msg = String.Format("Falha ao converter Certificado:{0}Parametros inválidos.", Environment.NewLine);
                }

            }
            catch (Exception ex)
            {
                msg = String.Format("Falha ao converter Certificado: ", Environment.NewLine);
            }

            Console.Write(msg);
            Console.ReadLine();
        }
    }
}

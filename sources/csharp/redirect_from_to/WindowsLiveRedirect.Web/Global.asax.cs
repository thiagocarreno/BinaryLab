using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Configuration;

namespace WindowsLiveRedirect
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            string url = Request.Url.AbsoluteUri;

            if (!String.IsNullOrEmpty(url))
            {
                string key = String.Empty;
                string value = String.Empty;
                string urlRedirect = String.Empty;

                for (int i = 0; i < WebConfigurationManager.AppSettings.Count; i++)
                {
                    key = WebConfigurationManager.AppSettings.GetKey(i);
                    value = WebConfigurationManager.AppSettings.Get(i);

                    if (url.ToLower() == key.ToLower())
                    {
                        urlRedirect = value;
                    }
                }

                if (!String.IsNullOrEmpty(urlRedirect))
                {
                    Response.Redirect(urlRedirect.Replace("|", "&"), false);
                }
                else
                {
                    Response.Redirect(WebConfigurationManager.AppSettings.Get(0).Replace("|", "&"), false);
                }
            }
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
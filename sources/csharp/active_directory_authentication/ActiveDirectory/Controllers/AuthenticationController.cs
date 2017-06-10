using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.DirectoryServices.AccountManagement;

namespace ActiveDirectory.Controllers
{
    public class AuthenticationController : Controller
    {
        public ActionResult Index(string user, string password)
        {
            if (!String.IsNullOrEmpty(user) && !String.IsNullOrEmpty(password))
            {
                bool isValid = AuthOne(user, password);
                if (isValid)
                {
                    ViewData["Message"] = "Autenticado.";
                }
                else
                {
                    ViewData["Message"] = "Não foi possível autenticar.";
                }
            }
            
            return View();
        }

        private bool AuthOne(string user, string password)
        {
            bool isValid = new bool();
            //string domain = "LATAM";
            //string domain = "latam.corp.yr.com";
            string domain = "152.146.75.178";

            using (PrincipalContext context = new PrincipalContext(ContextType.Domain, domain))
            {
                isValid = context.ValidateCredentials(user, password);
            }

            return isValid;
        }
    }
}
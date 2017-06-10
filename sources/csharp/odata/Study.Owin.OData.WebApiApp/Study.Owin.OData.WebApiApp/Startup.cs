using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(Study.Owin.OData.WebApiApp.Startup))]

namespace Study.Owin.OData.WebApiApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            WebApiConfig.Register(config);
            ODataConfig.Register(config);

            app.UseWebApi(config);
        }
    }
}

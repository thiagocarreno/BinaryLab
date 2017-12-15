using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(Study.Oauth.WebApi.Startup))]
namespace Study.Oauth.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var httpConfiguration = new HttpConfiguration();
            WebApiConfig.Register(httpConfiguration);
            //SwaggerConfig.Register(httpConfiguration);

            ConfigureAuth(app);

            app.UseWebApi(httpConfiguration);
        }
    }
}
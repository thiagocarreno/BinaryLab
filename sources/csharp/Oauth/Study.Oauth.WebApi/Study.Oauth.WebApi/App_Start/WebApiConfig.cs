using System.Web.Http;
using System.Web.Http.Cors;

namespace Study.Oauth.WebApi
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: @"DefaultApiV1",
                routeTemplate: @"api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
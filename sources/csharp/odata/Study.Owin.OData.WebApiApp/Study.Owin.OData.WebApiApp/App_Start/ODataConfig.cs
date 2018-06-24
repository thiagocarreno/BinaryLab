using Microsoft.OData.Edm;
using Study.Owin.OData.WebApiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.OData.Batch;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

namespace Study.Owin.OData.WebApiApp
{
    public static class ODataConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var modelBuilder = new ODataConventionModelBuilder(config);
            modelBuilder.EnableLowerCamelCase();
            modelBuilder.Namespace = "Study.Owin.OData.WebApiApp";
            modelBuilder.ContainerName = "DefaultContainer";
            modelBuilder.EntitySet<Person>("People");
            modelBuilder.EntitySet<Trip>("Trips");

            config.EnableCaseInsensitive(true);

            config.MapODataServiceRoute(
                "OData",
                null,
                modelBuilder.GetEdmModel(),
                new DefaultODataBatchHandler(GlobalConfiguration.DefaultServer)
            );

            //config.EnsureInitialized();
        }
    }
}
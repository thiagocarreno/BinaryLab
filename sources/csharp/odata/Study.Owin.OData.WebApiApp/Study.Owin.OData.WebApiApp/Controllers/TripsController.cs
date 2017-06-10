using Study.Owin.OData.WebApiApp.DataSource;
using Study.Owin.OData.WebApiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.OData;

namespace Study.Owin.OData.WebApiApp.Controllers
{
    public class TripsController : ODataController
    {
        public IQueryable<Trip> Get()
        {
            return DataSources.Instance
                .Trips
                .AsQueryable();
        }
    }
}
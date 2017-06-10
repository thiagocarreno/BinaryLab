using Study.Owin.OData.WebApiApp.DataSource;
using Study.Owin.OData.WebApiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Routing;

namespace Study.Owin.OData.WebApiApp.Controllers
{
    public class PeopleController : ODataController
    {
        [EnableQuery]
        public IQueryable<Person> Get()
        {
            return DataSources.Instance
                .People
                .AsQueryable();
        }

        [EnableQuery]
        public SingleResult<Person> Get([FromODataUri] int key)
        {
            var item = DataSources.Instance
                .People
                .Where(
                    p => p.Id.Equals(key)
                ).AsQueryable();

            return SingleResult.Create(item);
        }

        [EnableQuery]
        public IQueryable<Trip> GetTrips([FromODataUri] int key)
        {
            var items = DataSources.Instance
                .People
                .Where(
                    p => p.Id.Equals(key)
                ).SelectMany(
                    p => p.Trips
                ).AsQueryable();

            return items;
        }

        public IHttpActionResult Post(Person model)
        {
            return Created(model);
        }

        public IHttpActionResult Put([FromODataUri] int key, [FromBody] Delta<Person> model)
        {
            return Updated(model);
        }

        public IHttpActionResult Put([FromODataUri] int key, [FromBody] Person model)
        {
            return Updated(model);
        }

        public IHttpActionResult Delete([FromODataUri] int key)
        {
            return StatusCode(HttpStatusCode.NoContent);
        }

        //public IHttpActionResult Get(
        //    [FromODataUri] int offset,
        //    [FromODataUri] int page = 1
        //)
        //{
        //    int skip = 0;
        //    if (page > 1)
        //        skip = (--page) * offset;

        //    var itemsPaginated = DataSources.Instance
        //        .People
        //        .Skip(skip)
        //        .Take(offset);

        //    return Ok(itemsPaginated);
        //}
    }
}
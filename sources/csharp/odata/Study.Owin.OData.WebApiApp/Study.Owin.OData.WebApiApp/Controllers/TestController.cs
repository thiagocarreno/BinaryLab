using Study.Owin.OData.WebApiApp.DataSource;
using Study.Owin.OData.WebApiApp.Models;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.OData;

namespace Study.Owin.OData.WebApiApp.Controllers
{
    public class TestController : ApiController
    {
        [EnableQuery]
        public IQueryable<Person> Get()
        {
            return DataSources.Instance
                .People
                .AsQueryable();
        }

        public IHttpActionResult Post([FromBody] Person model)
        {
            return StatusCode(HttpStatusCode.Created);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.OData;

namespace Study.Orderable.WebApiApp.Controllers
{
    public class Test1Controller : ApiController
    {
        private readonly IEnumerable<Test1Model> _values;

        public Test1Controller()
        {
            _values = new List<Test1Model>
            {
                new Test1Model
                {
                    Id = 1,
                    Name = "Name 1"
                },
                new Test1Model
                {
                    Id = 2,
                    Name = "Name 2"
                },
                new Test1Model
                {
                    Id = 3,
                    Name = "Name 3"
                }
            };
        }

        // GET api/values
        [EnableQuery]
        public IHttpActionResult Get()
        {
            var values = _values.AsQueryable();
            return Ok(values);
        }

        // GET api/values/5
        public IHttpActionResult Get(int id)
        {
            var value = _values.First(
                v => v.Id.Equals(id)
            );

            return Ok(value);
        }
    }

    public class Test1Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
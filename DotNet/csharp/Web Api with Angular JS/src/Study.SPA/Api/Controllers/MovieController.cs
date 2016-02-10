using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using Study.SPA.Models;
using Newtonsoft.Json;

namespace Study.SPA.Controllers
{
    [Route("api/[controller]")]
    public class MovieController
        : Controller
    {
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return GetData();
        }

        [HttpGet("{id}")]
        public Movie Get(int id)
        {
            var data = GetData();
            Movie value = null;

            if (data != null
                && data.Count > 0
            )
            {
                value = data.Find(
                    m => m.Id == id
                );
            }

            return value;
        }

        [HttpPost]
        public void Post([FromBody]Movie value)
        {
            if (!string.IsNullOrEmpty(value.Title)
                && !string.IsNullOrEmpty(value.Director)
            )
            {
                var data = GetData();

                value.Id = data.Count + 1;
                data.Add(value);
                SaveData(data);
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Movie value)
        {
            var data = GetData();
            if (data != null
                && data.Count > 0
            )
            {
                var idx = data.FindIndex(
                    m => m.Id == id
                );

                if (idx > 0)
                {
                    data[idx].Title = value.Title;
                    data[idx].Director = value.Director;
                }

                SaveData(data);
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var data = GetData();
            if (data != null
                && data.Count > 0
            )
            {
                var item = data.Find(
                    m => m.Id == id
                );

                if (item != null)
                    data.Remove(item);

                SaveData(data);
            }
        }

        private List<Movie> GetData()
        {
            var file = System.IO.File.ReadAllText(@"C:\My Documents\Studies\DotNet\SPA with Web Api\Study.SPA\src\Study.SPA\Api\App_Data\Data.json");
            var data = JsonConvert.DeserializeObject(file, typeof(List<Movie>));
            return (List<Movie>)data;
        }

        private void SaveData(List<Movie> value)
        {
            if (value != null)
            {
                var data = JsonConvert.SerializeObject(value);
                System.IO.File.WriteAllText(
                    @"C:\My Documents\Studies\DotNet\SPA with Web Api\Study.SPA\src\Study.SPA\Api\App_Data\Data.json",
                    data
                );
            }
        }
    }
}

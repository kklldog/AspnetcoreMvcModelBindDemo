using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AspnetCoreModelbindDemo.Controllers
{
    public class FromBodyController : Controller
    {
        public IActionResult Index()
        {
            return Content("FromBody");
        }

        public class model1
        {
            public string NAME { get; set; }
        }

        public async Task<IActionResult> Test()
        {
            Request.EnableBuffering();

            string body = "";
            var stream = Request.Body;
            if (stream != null)
            {
                stream.Seek(0, SeekOrigin.Begin);
                using (var reader = new StreamReader(stream, Encoding.UTF8, true, 1024, true))
                {
                    body = await reader.ReadToEndAsync();
                }
                stream.Seek(0, SeekOrigin.Begin);
            }

            var model = JsonConvert.DeserializeObject<model1>(body);

            return Content(model.NAME);
        }

        public IActionResult Test1([FromBody]model1 model)
        {
            return Content(model.NAME);
        }

        public IActionResult Test2([FromForm]model1 model)
        {
            return Content(model.NAME);
        }
    }
}

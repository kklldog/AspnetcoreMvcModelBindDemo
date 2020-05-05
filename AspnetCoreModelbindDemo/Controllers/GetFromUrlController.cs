using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspnetCoreModelbindDemo.Models;

namespace AspnetCoreModelbindDemo.Controllers
{
    public class FromUrlController : Controller
    {
        public IActionResult Index()
        {
            return Content("FromUrl");
        }

        /// <summary>
        /// /fromurl/test?name=mjzhou
        /// </summary>
        /// <returns></returns>
        public IActionResult Test()
        {
            var name = Request.Query["name"];
            return Content(name);
        }

        public IActionResult Test1(string name)
        {
            return Content(name);
        }
        public IActionResult Test2([FromQuery(Name = "id")]string bh)
        {
            return Content(bh);
        }

        public IActionResult Test3()
        {
            var path = Request.Path;
            return Content(path);
        }

        [Route("FromUrl/test4/{name}/{id}")]
        public IActionResult Test4(string name, int id)
        {
            return Content($"{name}/{id}");
        }

        [HttpGet("FromUrl/test5/{name}/{id}")]
        public IActionResult Test5(string name, int id)
        {
            return Content($"{name}/{id}");
        }

        [Route("FromUrl/test6/{name}/{id}")]
        public IActionResult Test6([FromRoute(Name ="name")]string xm, [FromRoute(Name = "id")]int bh)
        {
            return Content($"{xm}/{bh}");
        }
    }
}

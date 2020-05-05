using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCoreModelbindDemo.Controllers
{
    public class FromHeaderController : Controller
    {
        public IActionResult Index()
        {
            return Content("FromHeader");
        }
        // /FromHeader/test
        public IActionResult Test()
        {
            var myName = Request.Headers["myName"];

            return Content(myName);
        }

        public IActionResult Test1([FromHeader]string myName)
        {
            return Content(myName);
        }

        public IActionResult Test2([FromHeader(Name = "myName")]string name)
        {
            return Content(name);
        }
    }
}

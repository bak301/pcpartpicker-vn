using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PcPartPickerBackendAPI.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("/")]
        public IActionResult Index()
        {
            return File("~/index.html", "text/html");
        }

        [HttpGet("/build")]
        public IActionResult Build()
        {
            return File("~/build.html", "text/html");
        }

        [HttpGet("/products/{part}")]
        public IActionResult List(string part)
        {
            string[] partTypes = {"cpu", "gpu", "motherboard", "memory", "storage", "powersupply", "pccase"};
            if (Array.Exists(partTypes, e => e.Equals(part)))
            {
                return File("~/list.html", "text/html");
            } else {
                return NotFound();
            }
        
        }

        [HttpGet("/order")]
        public IActionResult Order()
        {
            return File("~/order.html", "text/html");
        }

        [HttpGet("/admin")]
        public IActionResult Admin()
        {
            return File("~/admin.html", "text/html");
        }
    }
}
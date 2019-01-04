using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PcPartPickerBackendAPI.Controllers
{
    [ApiController]
    public class DetailController : ControllerBase
    {
        [HttpGet("/products/{part}/{id}")]
        public IActionResult Detail(string part) {
            string[] partTypes = {"cpu", "gpu", "motherboard", "memory", "storage", "powersupply", "pccase"};
            if (Array.Exists(partTypes, e => e.Equals(part)))
            {
                return File("~/detail.html", "text/html");
            } else {
                return NotFound();
            }
        }
    }
}
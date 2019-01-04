using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PcPartPickerBackendAPI.Repository.Interfaces;
using PcPartPickerBackendAPI.Models;
using PcPartPickerBackendAPI.ViewModels;
using Microsoft.AspNetCore.Cors;

namespace PcPartPickerBackendAPI.Controllers
{
    [Route("api/filter")]
    [ApiController]
    public class FilterController : ControllerBase
    {
        [HttpGet("{partType}/{property}")]
        public ActionResult<List<string>> GetProperties()
        {
            return new[] {"AMD", "Intel"}.ToList();
        }
    }
}

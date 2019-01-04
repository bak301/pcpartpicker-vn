using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PcPartPickerBackendAPI.Repository.Interfaces;
using PcPartPickerBackendAPI.Models;

namespace PcPartPickerBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemoryController : ControllerBase
    {
        IRepository<Memory> _memory;

        public MemoryController(IRepository<Memory> memory)
        {
            _memory = memory;
        }

        [HttpGet]
        public ActionResult<List<Memory>> GetAll()
        {
            return _memory.GetAll();
        }
    }
}
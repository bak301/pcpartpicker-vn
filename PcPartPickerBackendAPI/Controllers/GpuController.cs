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
    public class GpuController : ControllerBase
    {
        IRepository<Gpu> _gpu;

        public GpuController(IRepository<Gpu> gpu)
        {
            _gpu = gpu;
        }

        [HttpGet]
        public ActionResult<List<Gpu>> GetAll()
        {
            return _gpu.GetAll();
        }

        [HttpGet("{id}", Name="GetGpu")]
        public ActionResult<Gpu> GetById(int id) {
            var item = _gpu.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return item; 
        }
    }
}
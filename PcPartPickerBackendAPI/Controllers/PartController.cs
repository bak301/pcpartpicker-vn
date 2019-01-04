using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PcPartPickerBackendAPI.Repository.Interfaces;
using PcPartPickerBackendAPI.Models;

namespace PcPartPickerBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartController : ControllerBase
    {
        IRepository<Part> _part;

        public PartController(IRepository<Part> part)
        {
            _part = part;
        }

        [HttpGet]
        public ActionResult<List<Part>> GetAll()
        {
            return _part.GetAll();
        }

        [HttpGet("{id}", Name = "GetById")]
        public ActionResult<Part> GetById(int id)
        {
            var partItem = _part.GetById(id);
            if (partItem == null)
            {
                return NotFound();
            }
            return partItem;
        }
    }
}
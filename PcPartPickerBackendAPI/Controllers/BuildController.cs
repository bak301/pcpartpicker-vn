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
    public class BuildController : ControllerBase
    {
        IRepository<Build> _build;
        IBuildRepository _build2;

        public BuildController(IRepository<Build> build, IBuildRepository build2)
        {
            _build2 = build2;
            _build = build;
        }

        [HttpGet]
        public ActionResult<List<Build>> GetAll()
        {
            return _build.GetAll();
        }

        [HttpGet("{id}", Name = "GetBuild")]
        public ActionResult<Build> GetById(int id)
        {
            var item = _build.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public int Create(Build build)
        {
            int id = _build2.AddWithGetId(build);

            return id;
        }

        [HttpPut("id")]
        public IActionResult Update(Build build)
        {
            _build.Update(build);
            return NoContent();
        }

        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            _build.Delete(id);
            return NoContent();
        }
    }
}
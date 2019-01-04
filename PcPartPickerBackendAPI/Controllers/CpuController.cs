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
    [Route("api/[controller]")]
    [ApiController]
    public class CpuController : ControllerBase
    {
        IRepository<Cpu> _cpu;
        IRepository<PartViewModel> _cpuModel;
        
        public CpuController(IRepository<Cpu> cpu, IRepository<PartViewModel> cpuModel)
        { 
            _cpu = cpu;
            _cpuModel = cpuModel;
        }

        [HttpGet(Name="GetAllCpus")]
        public ActionResult<List<Cpu>> GetAll()
        {
            return _cpu.GetAll();
        }

        [HttpPost]
        public IActionResult Create(PartViewModel cpu)
        {
            _cpuModel.Add(cpu);
            return CreatedAtRoute("GetAllCpuModels", "");
        }

        [HttpGet("{id}", Name="GetCpu")]
        public ActionResult<Cpu> GetById(int id)
        {
            var item = _cpu.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }
    }
}

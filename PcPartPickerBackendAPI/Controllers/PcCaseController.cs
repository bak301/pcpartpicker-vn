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
    public class PccaseController : ControllerBase
    {
        IRepository<Pccase> _pcCase;

        public PccaseController(IRepository<Pccase> pcCase)
        {
            _pcCase = pcCase;
        }

        [HttpGet]
        public ActionResult<List<Pccase>> GetAll()
        {
            return _pcCase.GetAll();
        }
    }
}
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
    public class PowersupplyController : ControllerBase
    {
        IRepository<Powersupply> _powerSupply;

        public PowersupplyController(IRepository<Powersupply> powerSupply)
        {
            _powerSupply = powerSupply;
        }

        [HttpGet]
        public ActionResult<List<Powersupply>> GetAll()
        {
            return _powerSupply.GetAll();
        }
    }
}
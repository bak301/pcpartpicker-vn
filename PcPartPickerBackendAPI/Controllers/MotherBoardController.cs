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
    public class MotherboardController : ControllerBase
    {
        IRepository<Motherboard> _motherBoard;

        public MotherboardController(IRepository<Motherboard> motherBoard)
        {
            _motherBoard = motherBoard;
        }

        [HttpGet]
        public ActionResult<List<Motherboard>> GetAll()
        {
            return _motherBoard.GetAll();
        }
    }
}
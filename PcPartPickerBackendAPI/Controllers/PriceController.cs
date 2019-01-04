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
    public class PriceController : ControllerBase
    {
        IPriceRepository _price;

        public PriceController(IPriceRepository price) {
            this._price = price;
        }

        [HttpGet("part/{id}", Name="GetPriceByPartId")]
        public ActionResult<List<Price>> GetPricesByPartId(int id) {
            return _price.GetPricesByPartId(id);
        }
    }
}
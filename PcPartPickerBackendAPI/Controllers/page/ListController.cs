
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PcPartPickerBackendAPI.Repository.Interfaces;
using PcPartPickerBackendAPI.Models;
using PcPartPickerBackendAPI.ViewModels;

namespace PcPartPickerBackendAPI.Controllers
{
    [Route("api/products/{part}")]
    [ApiController]
    public class ListController : ControllerBase
    {
        IPartRepository _partRepository;

        public ListController(IPartRepository partRepository)
        {
            this._partRepository = partRepository;
        }

        [HttpGet]
        public ActionResult<List<PartViewModel>> GetPartsByType(
            string part, 
            string property,
            string value,
            string sortBy = "id",
            string direction = "asc",
            int page = 1
        )
        {
            string[] partTypes = { "cpu", "gpu", "motherboard", "memory", "storage", "powersupply", "pccase" };
            if (Array.Exists(partTypes, e => e.Equals(part)))
            {
                return _partRepository.GetPartViewModels(
                    part, new KeyValuePair<string,string>(property, value), sortBy, direction, page);
            }
            else
            {
                return NotFound();
            }

        }
    }
}
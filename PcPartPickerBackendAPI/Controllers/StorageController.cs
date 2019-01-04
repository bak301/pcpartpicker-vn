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
    public class StorageController : ControllerBase
    {
        IRepository<Storage> _storage;

        public StorageController(IRepository<Storage> storage)
        {
            _storage = storage;
        }

        [HttpGet]
        public ActionResult<List<Storage>> GetAll()
        {   
            return _storage.GetAll();
        }
    }
}
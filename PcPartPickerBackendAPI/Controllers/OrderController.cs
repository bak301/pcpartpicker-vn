using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PcPartPickerBackendAPI.Models;
using PcPartPickerBackendAPI.Repository.Interfaces;

namespace PcPartPickerBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IRepository<Order> _orderRepository;

        public OrderController(IRepository<Order> orderRepository) 
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public ActionResult<List<Order>> GetAll()
        {
            return _orderRepository.GetAll();
        }

        [HttpGet("{id}", Name = "GetOrder")]
        public ActionResult<Order> GetById(int id)
        {
            var item = _orderRepository.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create(Order order)
        {
            _orderRepository.Add(order);
            return CreatedAtRoute("GetOrder", new { id = order.Id }, order);
        }
    }
}
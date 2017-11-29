using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MessagingService.Respsitory;
using MessagingService.Models;

namespace MessagingService.Controllers
{
    [Route("api/[controller]")]
    public class MessageController : Controller
    {
        public IMessageRepository MessageRepo { get; set; }

        public MessageController(IMessageRepository _repo)
        {
            MessageRepo = _repo;
        }

        [HttpGet]
        public IEnumerable<Message> GetAll()
        {
            return MessageRepo.GetAll();
        }

        [HttpGet("{id}", Name = "GetMessage")]
        public IActionResult GetById(string id)
        {
            var item = MessageRepo.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Message item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            MessageRepo.Add(item);
            return CreatedAtRoute("GetMessage", new { Controller = "Message", id = item.id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Message item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var contactObj = MessageRepo.Find(id);
            if (contactObj == null)
            {
                return NotFound();
            }
            MessageRepo.Update(item);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            MessageRepo.remove(id);
        }
    }
}


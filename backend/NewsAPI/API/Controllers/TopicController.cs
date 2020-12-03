using System.Collections.Generic;
using System.Linq;
using API.Data;
using API.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/topic")]
    public class TopicController : ControllerBase
    {
        private readonly ITopicRepository _repository;

        public TopicController(ITopicRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<List<Topic>> Get() => _repository.GetAll().ToList();

        [HttpGet("{id}", Name = "GetTopicById")]
        public ActionResult<Topic> GetById(int id) => _repository.GetById(id);

        [HttpPost]
        public IActionResult Create(Topic topic)
        {
            _repository.Create(topic);
            return CreatedAtAction(nameof(GetById), new { id = topic.Id }, topic);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Topic topic)
        {
            _repository.Update(id, topic);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            _repository.Remove(id);
            return NoContent();
        }
    }
}
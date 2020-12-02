using System.Collections.Generic;
using System.Linq;
using API.Data;
using API.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/news-topic")]
    public class NewsTopicController : ControllerBase
    {
        private readonly INewsTopicRepository _repository;

        public NewsTopicController(INewsTopicRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<List<NewsTopic>> Get() => _repository.GetAll().ToList();

        [HttpGet("{id}", Name = "GetNewsTopicById")]
        public ActionResult<NewsTopic> GetById(int id) => _repository.GetById(id);

        [HttpPost]
        public IActionResult Create(NewsTopic newsTopic)
        {
            _repository.Create(newsTopic);
            return CreatedAtAction(nameof(GetById), new { id = newsTopic.Id }, newsTopic);
        }

        [HttpPut("{id}")]
        public void Update(int id, NewsTopic newsTopic)
        {
            _repository.Update(id, newsTopic);
        }

        [HttpDelete("{id}")]
        public void Remove(int id)
        {
            _repository.Remove(id);
        }
    }
}
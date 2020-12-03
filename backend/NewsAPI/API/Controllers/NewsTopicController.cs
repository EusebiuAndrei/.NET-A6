using System.Collections.Generic;
using System.Linq;
using API.Data;
using API.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/news-topic")]
    public class NewsTopicController : ControllerBase
    {
        private readonly INewsTopicRepository _repository;

        public NewsTopicController(INewsTopicRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<NewsTopic>> Get() => _repository.GetAll().ToList();

        [HttpGet("{id}", Name = "GetNewsTopicById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<NewsTopic> GetById(int id) => _repository.GetById(id);

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create(NewsTopic newsTopic)
        {
            _repository.Create(newsTopic);
            return CreatedAtAction(nameof(GetById), new { id = newsTopic.Id }, newsTopic);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(int id, NewsTopic newsTopic)
        {
            _repository.Update(id, newsTopic);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Remove(int id)
        {
            _repository.Remove(id);
            return NoContent();
        }
    }
}
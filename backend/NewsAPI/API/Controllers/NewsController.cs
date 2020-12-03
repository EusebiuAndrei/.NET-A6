using System.Collections.Generic;
using System.Linq;
using API.Data;
using API.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/news")]
    public class NewsController : ControllerBase
    {
        private readonly INewsRepository _repository;

        public NewsController(INewsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<List<News>> Get() => _repository.GetAll().ToList();

        [HttpGet("{id}", Name = "GetNewsById")]
        public ActionResult<News> GetById(int id) => _repository.GetById(id);

        [HttpPost]
        public IActionResult Create(News news)
        {
            _repository.Create(news);
            return CreatedAtAction(nameof(GetById), new { id = news.Id }, news);
        }

        [HttpPut("{id}")]
        public void Update(int id, News news)
        {
            _repository.Update(id, news);
        }

        [HttpDelete("{id}")]
        public void Remove(int id)
        {
            _repository.Remove(id);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using API.Views;

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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<News>> Get() => _repository.GetAll().ToList();

        [HttpGet("{id}", Name = "GetNewsById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<News> GetById(int id)
        {
            var news = _repository.GetById(id);
            
            if(news == null)
            {
                return NotFound();
            }

            return news;
        }

        [HttpGet("query", Name = "QueryNews")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<News>> GetQueriedNews([FromQuery] int pageNumber, [FromQuery] int nrOfNews, [FromQuery] string[] wordsInTitle, 
            [FromQuery] DateTime? fromDate, [FromQuery] DateTime? toDate, [FromQuery] Int16? classifiedAs, [FromQuery] int? topicId)
        {
            return _repository.GetQueriedNews(pageNumber, nrOfNews, wordsInTitle, fromDate, toDate, classifiedAs, topicId).ToList();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create(News news)
        {
            _repository.Create(news);
            return CreatedAtAction(nameof(GetById), new { id = news.Id }, news);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(int id, News news)
        {
            _repository.Update(id, news);
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
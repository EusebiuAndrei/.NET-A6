using System;
using System.Collections.Generic;
using System.Linq;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using API.Authentication;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;

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

        [HttpGet("topic/{topicId}", Name = "GetAllNewsByTopicId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<News>> GetAllByTopicId(int id) => _repository.GetAllByTopicId(id).ToList();

        [HttpGet("{newsId}", Name = "GetNewsById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<News> GetById(int id)
        {
            var news = _repository.GetNewsById(id);
            
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
        public ActionResult<List<News>> GetQueriedNews([FromQuery] int pageNumber, [FromQuery] int nrOfNews, [FromQuery] string search, 
            [FromQuery] DateTime? fromDate, [FromQuery] DateTime? toDate, [FromQuery] Int16? classifiedAs, [FromQuery] int? topicId)
        {
            return _repository.GetQueriedNews(pageNumber, nrOfNews, search, fromDate, toDate, classifiedAs, topicId).ToList();
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] News news)
        {
            _repository.Create(news);
            return CreatedAtAction(nameof(GetById), new { id = news.Id }, news);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut("{newsId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(int id, [FromBody] News news)
        {
            _repository.Update(id, news);
            return NoContent();
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("{newsId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Remove(int id)
        {
            _repository.Remove(id);
            return NoContent();
        }

        [HttpGet("latest-news")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<News>> GetLatestNews(int number = 3) => _repository.GetLatestNews(number).ToList();

        [HttpPut("views/{newsId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateViews(int id)
        {
            _repository.UpdateViews(id);
            return NoContent();
        }

        [HttpPut("read/{newsId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateRead(int id)
        {
            _repository.UpdateRead(id);
            return NoContent();
        }

        [HttpPost("validate")]
        public ActionResult<string> ValidateText([FromBody] NewsToClassify data)
        {
            return Ok(_repository.ValidateNewsAsync(data));
        }
    }
}
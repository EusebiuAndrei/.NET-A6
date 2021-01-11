using System.Collections.Generic;
using System.Threading.Tasks;
using CrawlerAPI.CrawlingFunctions;
using CrawlerAPI.NewsModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CrawlerAPI.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        public NewsController() { }

        [HttpGet("news")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<News>>> GetNews(string website="all", string subject="all")
        {
            MappingCrawlingMethods mapping = new MappingCrawlingMethods();
            var news = await mapping.GetNewsFromWebsiteWithSubject(website, subject);
            return Ok(news);
        }

        [HttpGet("latest-news")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<News>>> GetLatestNews(string website = "all", string subject = "all", int hoursNumber = 3)
        {
            Console.WriteLine("apel crawler latest news");
            MappingCrawlingMethods mapping = new MappingCrawlingMethods();
            var news = await mapping.GetLatestNewsFromWebsiteWithSubject(website, subject, hoursNumber);
            Console.WriteLine(news.Count);
            return Ok(news);
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using CrawlerAPI.CrawlingFunctions;
using CrawlerAPI.NewsModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrawlerAPI.Controllers
{
    [Authorize]
    [Route("api/v1")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        public NewsController() { }

        [HttpGet("news")]
        public async Task<ActionResult<List<News>>> GetNews(string website="all", string subject="all")
        {
            MappingCrawlingMethods mapping = new MappingCrawlingMethods();
            return await mapping.GetNewsFromWebsiteWithSubject(website, subject);
        }

        [HttpGet("latest-news")]
        public async Task<ActionResult<List<News>>> GetLatestNews(string website = "all", string subject = "all", int hoursNumber = 3)
        {
            MappingCrawlingMethods mapping = new MappingCrawlingMethods();
            return await mapping.GetLatestNewsFromWebsiteWithSubject(website, subject, hoursNumber);
        }
    }
}

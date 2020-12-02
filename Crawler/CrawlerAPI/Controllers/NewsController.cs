using System.Collections.Generic;
using System.Threading.Tasks;
using CrawlerAPI.CrawlingFunctionsBBC;
using CrawlerAPI.NewsModel;
using Microsoft.AspNetCore.Mvc;

namespace CrawlerAPI.Controllers
{
    [Route("api/news")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        [HttpGet("bbc/sport")]
        public async Task<ActionResult<List<News>>> GetSportNewsFromBBC()
        {
            SportCrawler sportCrawler = new SportCrawler();
            return await sportCrawler.StartCrawlerAsync();
        }

        [HttpGet("bbc/health")]
        public async Task<ActionResult<List<News>>> GetHealthNewsFromBBC()
        {
            HealthCrawler healthCrawler = new HealthCrawler();
            return await healthCrawler.StartCrawlerAsync();
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using CrawlerAPI.CrawlingFunctionsBBC;
using CrawlerAPI.NewsModel;
using Microsoft.AspNetCore.Mvc;

namespace CrawlerAPI.Controllers
{
    [Route("api/v1/news")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        [HttpGet("bbc")]
        public async Task<ActionResult<List<News>>> GetAllNewsFromBBC()
        {
            List<News> allNews = new List<News>();
            //allNews.AddRange(await SportCrawler.GetSportNews());
            allNews.AddRange(await HealthCrawler.GetHealthNews());
            allNews.AddRange(await CoronavirusCrawler.GetCoronavirusNews());
            allNews.AddRange(await WorldCrawler.GetWorldNews());
            allNews.AddRange(await BusinessCrawler.GetBusinessNews());
            return allNews;
        }

        [HttpGet("bbc/sport")]
        public async Task<ActionResult<List<News>>> GetSportNewsFromBBC()
        {
            return await SportCrawler.GetSportNews();
        }

        [HttpGet("bbc/health")]
        public async Task<ActionResult<List<News>>> GetHealthNewsFromBBC()
        {
            return await HealthCrawler.GetHealthNews();
        }

        [HttpGet("bbc/coronavirus")]
        public async Task<ActionResult<List<News>>> GetCoronavirusNewsFromBBC()
        {
            return await CoronavirusCrawler.GetCoronavirusNews();
        }

        [HttpGet("bbc/world")]
        public async Task<ActionResult<List<News>>> GetWorldNewsFromBBC()
        {
            return await WorldCrawler.GetWorldNews();
        }

        [HttpGet("bbc/business")]
        public async Task<ActionResult<List<News>>> GetBusinessNewsFromBBC()
        {
            return await BusinessCrawler.GetBusinessNews();
        }
    }
}

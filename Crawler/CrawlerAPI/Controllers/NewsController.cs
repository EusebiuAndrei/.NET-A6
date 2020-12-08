using System.Collections.Generic;
using System.Threading.Tasks;
using CrawlerAPI.CrawlingFunctionsABCNews;
using CrawlerAPI.CrawlingFunctionsBBC;
using CrawlerAPI.CrawlingFunctionTheNewYorkTimes;
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
            allNews.AddRange(await SportCrawlerBBC.GetSportNews());
            allNews.AddRange(await HealthCrawlerBBC.GetHealthNews());
            allNews.AddRange(await CoronavirusCrawlerBBC.GetCoronavirusNews());
            allNews.AddRange(await WorldCrawlerBBC.GetWorldNews());
            allNews.AddRange(await BusinessCrawlerBBC.GetBusinessNews());
            return allNews;
        }

        [HttpGet("bbc/sport")]
        public async Task<ActionResult<List<News>>> GetSportNewsFromBBC()
        {
            return await SportCrawlerBBC.GetSportNews();
        }

        [HttpGet("bbc/health")]
        public async Task<ActionResult<List<News>>> GetHealthNewsFromBBC()
        {
            return await HealthCrawlerBBC.GetHealthNews();
        }

        [HttpGet("bbc/coronavirus")]
        public async Task<ActionResult<List<News>>> GetCoronavirusNewsFromBBC()
        {
            return await CoronavirusCrawlerBBC.GetCoronavirusNews();
        }

        [HttpGet("bbc/world")]
        public async Task<ActionResult<List<News>>> GetWorldNewsFromBBC()
        {
            return await WorldCrawlerBBC.GetWorldNews();
        }

        [HttpGet("bbc/business")]
        public async Task<ActionResult<List<News>>> GetBusinessNewsFromBBC()
        {
            return await BusinessCrawlerBBC.GetBusinessNews();
        }

        [HttpGet("abcnews")]
        public async Task<ActionResult<List<News>>> GetAllNewsFromABCNews()
        {
            List<News> allNews = new List<News>();
            allNews.AddRange(await InternationalCrawlerABCNews.GetInternationalNews());
            allNews.AddRange(await PoliticsCrawlerABCNews.GetPoliticsNews());
            allNews.AddRange(await SportCrawlerABCNews.GetSportNews());
            allNews.AddRange(await TechnologyCrawlerABCNews.GetTechnologyNews());
            allNews.AddRange(await EntertainmentCrawlerABCNews.GetEntertainmentNews());
            return allNews;
        }

        [HttpGet("abcnews/international")]
        public async Task<ActionResult<List<News>>> GetInternationalNewsFromABCNews()
        {
            return await InternationalCrawlerABCNews.GetInternationalNews();
        }

        [HttpGet("abcnews/politics")]
        public async Task<ActionResult<List<News>>> GetPoliticsNewsFromABCNews()
        {
            return await PoliticsCrawlerABCNews.GetPoliticsNews();
        }

        [HttpGet("abcnews/sport")]
        public async Task<ActionResult<List<News>>> GetSportNewsFromABCNews()
        {
            return await SportCrawlerABCNews.GetSportNews();
        }

        [HttpGet("abcnews/technology")]
        public async Task<ActionResult<List<News>>> GetTechnologyNewsFromABCNews()
        {
            return await TechnologyCrawlerABCNews.GetTechnologyNews();
        }

        [HttpGet("abcnews/entertainment")]
        public async Task<ActionResult<List<News>>> GetEntertainmentNewsFromABCNews()
        {
            return await EntertainmentCrawlerABCNews.GetEntertainmentNews();
        }

        [HttpGet("thenewyorktimesnews/politics")]
        public async Task<ActionResult<List<News>>> GetPoliticsNewsFromTheNewYorkTimes()
        {
            return await PoliticsCrawlerTheNewYorkTimes.GetPoliticsNews();
        }

        [HttpGet("thenewyorktimesnews/business")]
        public async Task<ActionResult<List<News>>> GetBusinessNewsFromTheNewYorkTimes()
        {
            return await BusinessCrawlerTheNewYorkTimes.GetBusinessNews();
        }

        [HttpGet("thenewyorktimesnews/technology")]
        public async Task<ActionResult<List<News>>> GetTechnologyNewsFromTheNewYorkTimes()
        {
            return await TechnologyCrawlerTheNewYorkTimes.GetTechnologyNews();
        }


        [HttpGet("cbsnews/science")]
        public async Task<ActionResult<List<News>>> GetScienceNewsFromCBSNews()
        {
            return await ScienceCrawlerCBS.GetScienceNews();
        }
    }
}

using System;
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
        public NewsController() { }
        [HttpGet("bbc")]
        public async Task<ActionResult<List<News>>> GetAllNewsFromBBC()
        {
            return await AllNewsBBC.GetNews();
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
            return await AllNewsABC.GetNews();
        }

        [HttpGet("abcnews/world")]
        public async Task<ActionResult<List<News>>> GetInternationalNewsFromABCNews()
        {
            return await WorldCrawlerABCNews.GetWorldNews();
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

        [HttpGet("thenewyorktimes")]
        public async Task<ActionResult<List<News>>> GetAllNewsFromTheNewYorkTimesNews()
        {
            return await AllNewsNYTimes.GetNews();
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

        [HttpGet("thenewyorktimesnews/health")]
        public async Task<ActionResult<List<News>>> GetHealthNewsFromTheNewYorkTimes()
        {
            return await HealthCrawlerTheNewYorkTimes.GetHealthNews();
        }

        [HttpGet("thenewyorktimesnews/sport")]
        public async Task<ActionResult<List<News>>> GetSportNewsFromTheNewYorkTimes()
        {
            return await SportCrawlerTheNewYorkTimes.GetSportNews();
        }

        [HttpGet]
        public async Task<ActionResult<List<News>>> GetAllNews()
        {
            List<News> allNews = new List<News>();
            allNews.AddRange(await AllNewsBBC.GetNews());
            allNews.AddRange(await AllNewsABC.GetNews());
            allNews.AddRange(await AllNewsNYTimes.GetNews());
            return allNews;
        }

        [HttpGet("sport")]
        public async Task<ActionResult<List<News>>> GetAllSportNews()
        {
            List<News> allNews = new List<News>();
            allNews.AddRange(await SportCrawlerBBC.GetSportNews());
            allNews.AddRange(await SportCrawlerABCNews.GetSportNews());
            allNews.AddRange(await SportCrawlerTheNewYorkTimes.GetSportNews());
            return allNews;
        }

        [HttpGet("business")]
        public async Task<ActionResult<List<News>>> GetAllBusinessNews()
        {
            List<News> allNews = new List<News>();
            allNews.AddRange(await BusinessCrawlerBBC.GetBusinessNews());
            allNews.AddRange(await BusinessCrawlerTheNewYorkTimes.GetBusinessNews());
            return allNews;
        }

        [HttpGet("coronavirus")]
        public async Task<ActionResult<List<News>>> GetAllCoronavirusNews()
        {
            List<News> allNews = new List<News>();
            allNews.AddRange(await CoronavirusCrawlerBBC.GetCoronavirusNews());
            return allNews;
        }

        [HttpGet("health")]
        public async Task<ActionResult<List<News>>> GetAllHealthNews()
        {
            List<News> allNews = new List<News>();
            allNews.AddRange(await HealthCrawlerBBC.GetHealthNews());
            allNews.AddRange(await HealthCrawlerTheNewYorkTimes.GetHealthNews());
            return allNews;
        }

        [HttpGet("world")]
        public async Task<ActionResult<List<News>>> GetAllWorldNews()
        {
            List<News> allNews = new List<News>();
            allNews.AddRange(await WorldCrawlerBBC.GetWorldNews());
            allNews.AddRange(await WorldCrawlerABCNews.GetWorldNews());
            return allNews;
        }

        [HttpGet("entertainment")]
        public async Task<ActionResult<List<News>>> GetAllEntertainmentNews()
        {
            List<News> allNews = new List<News>();
            allNews.AddRange(await EntertainmentCrawlerABCNews.GetEntertainmentNews());
            return allNews;
        }

        [HttpGet("politics")]
        public async Task<ActionResult<List<News>>> GetAllPoliticsNews()
        {
            List<News> allNews = new List<News>();
            allNews.AddRange(await PoliticsCrawlerABCNews.GetPoliticsNews());
            allNews.AddRange(await PoliticsCrawlerTheNewYorkTimes.GetPoliticsNews());
            return allNews;
        }

        [HttpGet("technology")]
        public async Task<ActionResult<List<News>>> GetAllTechnologyNews()
        {
            List<News> allNews = new List<News>();
            allNews.AddRange(await TechnologyCrawlerABCNews.GetTechnologyNews());
            allNews.AddRange(await TechnologyCrawlerTheNewYorkTimes.GetTechnologyNews());
            return allNews;
        }
    }
}

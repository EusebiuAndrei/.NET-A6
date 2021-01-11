using CrawlerAPI.CrawlingFunctions.CrawlingFunctionsABCNews;
using CrawlerAPI.CrawlingFunctions.CrawlingFunctionsBBC;
using CrawlerAPI.CrawlingFunctions.CrawlingFunctionsTheNewYorkTimes;
using CrawlerAPI.NewsModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrawlerAPI.CrawlingFunctions
{
    public class MergeNewsWebsitesFunctions
    {
        public static async Task<List<News>> GetAllNews()
        {
            Console.WriteLine("get all news");
            List<News> allNews = new List<News>();
            allNews.AddRange(await AllNewsABC.GetNews());
            Console.WriteLine("get all news abc");
            allNews.AddRange(await AllNewsBBC.GetNews());
            Console.WriteLine("get all news bbc");
            allNews.AddRange(await AllNewsNYTimes.GetNews());
            Console.WriteLine("get all news nytimes");
            return allNews;
        }

        public static async Task<List<News>> GetAllSportNews()
        {
            List<News> allNews = new List<News>();
            allNews.AddRange(await SportCrawlerBBC.GetSportNews());
            allNews.AddRange(await SportCrawlerABCNews.GetSportNews());
            allNews.AddRange(await SportCrawlerTheNewYorkTimes.GetSportNews());
            return allNews;
        }

        public static async Task<List<News>> GetAllBusinessNews()
        {
            List<News> allNews = new List<News>();
            allNews.AddRange(await BusinessCrawlerBBC.GetBusinessNews());
            allNews.AddRange(await BusinessCrawlerTheNewYorkTimes.GetBusinessNews());
            return allNews;
        }

        public static async Task<List<News>> GetAllCoronavirusNews()
        {
            List<News> allNews = new List<News>();
            allNews.AddRange(await CoronavirusCrawlerBBC.GetCoronavirusNews());
            return allNews;
        }

        public static async Task<List<News>> GetAllHealthNews()
        {
            List<News> allNews = new List<News>();
            allNews.AddRange(await HealthCrawlerBBC.GetHealthNews());
            allNews.AddRange(await HealthCrawlerTheNewYorkTimes.GetHealthNews());
            return allNews;
        }

        public static async Task<List<News>> GetAllWorldNews()
        {
            List<News> allNews = new List<News>();
            allNews.AddRange(await WorldCrawlerBBC.GetWorldNews());
            allNews.AddRange(await WorldCrawlerABCNews.GetWorldNews());
            return allNews;
        }

        public static async Task<List<News>> GetAllEntertainmentNews()
        {
            List<News> allNews = new List<News>();
            allNews.AddRange(await EntertainmentCrawlerABCNews.GetEntertainmentNews());
            return allNews;
        }

        public static async Task<List<News>> GetAllPoliticsNews()
        {
            List<News> allNews = new List<News>();
            allNews.AddRange(await PoliticsCrawlerABCNews.GetPoliticsNews());
            allNews.AddRange(await PoliticsCrawlerTheNewYorkTimes.GetPoliticsNews());
            return allNews;
        }

        public static async Task<List<News>> GetAllTechnologyNews()
        {
            List<News> allNews = new List<News>();
            allNews.AddRange(await TechnologyCrawlerABCNews.GetTechnologyNews());
            allNews.AddRange(await TechnologyCrawlerTheNewYorkTimes.GetTechnologyNews());
            return allNews;
        }
    }
}

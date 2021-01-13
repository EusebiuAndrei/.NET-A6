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
            List<News> allNews = new List<News>();
            allNews.AddRange(await AllNewsABC.GetNews());
            allNews.AddRange(await AllNewsBBC.GetNews());
            return allNews;
        }

        public static async Task<List<News>> GetAllSportNews()
        {
            List<News> allNews = new List<News>();
            allNews.AddRange(await SportCrawlerBBC.GetSportNews());
            allNews.AddRange(await SportCrawlerABCNews.GetSportNews());
            return allNews;
        }

        public static async Task<List<News>> GetAllBusinessNews()
        {
            List<News> allNews = new List<News>();
            allNews.AddRange(await BusinessCrawlerBBC.GetBusinessNews());
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
            return allNews;
        }

        public static async Task<List<News>> GetAllTechnologyNews()
        {
            List<News> allNews = new List<News>();
            allNews.AddRange(await TechnologyCrawlerABCNews.GetTechnologyNews());
            return allNews;
        }
    }
}

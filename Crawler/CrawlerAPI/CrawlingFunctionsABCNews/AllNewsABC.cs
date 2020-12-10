using CrawlerAPI.NewsModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrawlerAPI.CrawlingFunctionsABCNews
{
    public static class AllNewsABC
    {
        public async static Task<List<News>> GetNews()
        {
            List<News> allNews = new List<News>();
            allNews.AddRange(await WorldCrawlerABCNews.GetWorldNews());
            allNews.AddRange(await PoliticsCrawlerABCNews.GetPoliticsNews());
            allNews.AddRange(await SportCrawlerABCNews.GetSportNews());
            allNews.AddRange(await TechnologyCrawlerABCNews.GetTechnologyNews());
            allNews.AddRange(await EntertainmentCrawlerABCNews.GetEntertainmentNews());
            return allNews;
        }
    }
}

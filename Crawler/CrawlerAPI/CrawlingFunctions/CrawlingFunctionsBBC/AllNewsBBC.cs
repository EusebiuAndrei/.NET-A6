using CrawlerAPI.NewsModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrawlerAPI.CrawlingFunctions.CrawlingFunctionsBBC
{
    public static class AllNewsBBC
    {
        public async static Task<List<News>> GetNews()
        {
            List<News> allNews = new List<News>();
            allNews.AddRange(await SportCrawlerBBC.GetSportNews());
            allNews.AddRange(await HealthCrawlerBBC.GetHealthNews());
            allNews.AddRange(await CoronavirusCrawlerBBC.GetCoronavirusNews());
            allNews.AddRange(await WorldCrawlerBBC.GetWorldNews());
            allNews.AddRange(await BusinessCrawlerBBC.GetBusinessNews());
            return allNews;
        }
    }
}

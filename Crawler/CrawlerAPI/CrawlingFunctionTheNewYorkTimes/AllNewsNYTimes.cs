using CrawlerAPI.NewsModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrawlerAPI.CrawlingFunctionTheNewYorkTimes
{
    public static class AllNewsNYTimes
    {
        public async static Task<List<News>> GetNews()
        {
            List<News> allNews = new List<News>();
            allNews.AddRange(await PoliticsCrawlerTheNewYorkTimes.GetPoliticsNews());
            allNews.AddRange(await BusinessCrawlerTheNewYorkTimes.GetBusinessNews());
            allNews.AddRange(await TechnologyCrawlerTheNewYorkTimes.GetTechnologyNews());
            allNews.AddRange(await HealthCrawlerTheNewYorkTimes.GetHealthNews());
            allNews.AddRange(await SportCrawlerTheNewYorkTimes.GetSportNews());
            return allNews;
        }
    }
}

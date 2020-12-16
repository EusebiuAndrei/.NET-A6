using CrawlerAPI.NewsModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrawlerAPI.CrawlingFunctions.CrawlingFunctionsABCNews
{
    public static class PoliticsCrawlerABCNews
    {
        public static async Task<List<News>> GetPoliticsNews()
        {
            return await CrawlerABCNews.StartCrawlerAsync("https://abcnews.go.com/Politics", "politics");
        }
    }
}

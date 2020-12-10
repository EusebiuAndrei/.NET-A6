using CrawlerAPI.NewsModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrawlerAPI.CrawlingFunctionsABCNews
{
    public static class WorldCrawlerABCNews
    {
        public static async Task<List<News>> GetWorldNews()
        {
            return await CrawlerABCNews.StartCrawlerAsync("https://abcnews.go.com/International", "world");
        }
    }
}

using CrawlerAPI.NewsModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrawlerAPI.CrawlingFunctionsABCNews
{
    public static class TechnologyCrawlerABCNews
    {
        public static async Task<List<News>> GetTechnologyNews()
        {
            return await CrawlerABCNews.StartCrawlerAsync("https://abcnews.go.com/Technology", "technology");
        }
    }
}

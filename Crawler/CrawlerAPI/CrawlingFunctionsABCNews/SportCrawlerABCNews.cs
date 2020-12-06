using CrawlerAPI.NewsModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrawlerAPI.CrawlingFunctionsABCNews
{
    public static class SportCrawlerABCNews
    {
        public static async Task<List<News>> GetSportNews()
        {
            return await CrawlerABCNews.StartCrawlerAsync("https://abcnews.go.com/Sports", "sport");
        }
    }
}

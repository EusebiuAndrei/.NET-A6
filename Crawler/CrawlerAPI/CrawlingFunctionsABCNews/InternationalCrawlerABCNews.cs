using CrawlerAPI.NewsModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrawlerAPI.CrawlingFunctionsABCNews
{
    public static class InternationalCrawlerABCNews
    {
        public static async Task<List<News>> GetInternationalNews()
        {
            return await CrawlerABCNews.StartCrawlerAsync("https://abcnews.go.com/International", "international");
        }
    }
}

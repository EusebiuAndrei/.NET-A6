using CrawlerAPI.NewsModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrawlerAPI.CrawlingFunctionsABCNews
{
    public static class EntertainmentCrawlerABCNews
    {
        public static async Task<List<News>> GetEntertainmentNews()
        {
            return await CrawlerABCNews.StartCrawlerAsync("https://abcnews.go.com/Entertainment", "entertainment");
        }
    }
}

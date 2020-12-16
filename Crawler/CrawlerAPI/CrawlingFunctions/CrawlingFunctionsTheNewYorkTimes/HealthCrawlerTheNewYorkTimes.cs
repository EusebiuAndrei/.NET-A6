using CrawlerAPI.NewsModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrawlerAPI.CrawlingFunctions.CrawlingFunctionsTheNewYorkTimes
{
    public static class HealthCrawlerTheNewYorkTimes
    {
        public static async Task<List<News>> GetHealthNews()
        {
            return await CrawlerTheNewYorkTimes.StartCrawlerAsync("https://www.nytimes.com/section/health", "health");
        }
    }
}

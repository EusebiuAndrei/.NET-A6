using CrawlerAPI.NewsModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrawlerAPI.CrawlingFunctions.CrawlingFunctionsTheNewYorkTimes
{
    public static class BusinessCrawlerTheNewYorkTimes
    {
        public static async Task<List<News>> GetBusinessNews()
        {
            return await CrawlerTheNewYorkTimes.StartCrawlerAsync("https://www.nytimes.com/section/business", "business");
        }
    }
}

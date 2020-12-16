using CrawlerAPI.NewsModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrawlerAPI.CrawlingFunctions.CrawlingFunctionsTheNewYorkTimes
{
    public static class PoliticsCrawlerTheNewYorkTimes
    {
        public static async Task<List<News>> GetPoliticsNews()
        {
            return await CrawlerTheNewYorkTimes.StartCrawlerAsync("https://www.nytimes.com/section/politics", "politics");
        }
    }
}

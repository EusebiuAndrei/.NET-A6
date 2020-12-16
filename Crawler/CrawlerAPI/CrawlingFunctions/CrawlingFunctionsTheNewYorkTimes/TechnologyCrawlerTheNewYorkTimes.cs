using CrawlerAPI.NewsModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrawlerAPI.CrawlingFunctions.CrawlingFunctionsTheNewYorkTimes
{
    public static class TechnologyCrawlerTheNewYorkTimes
    {
        public static async Task<List<News>> GetTechnologyNews()
        {
            return await CrawlerTheNewYorkTimes.StartCrawlerAsync("https://www.nytimes.com/section/technology", "technology");
        }
    }
}

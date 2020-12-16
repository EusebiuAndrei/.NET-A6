using CrawlerAPI.NewsModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrawlerAPI.CrawlingFunctions.CrawlingFunctionsTheNewYorkTimes
{
    public static class SportCrawlerTheNewYorkTimes
    {
        public static async Task<List<News>> GetSportNews()
        {
            return await CrawlerTheNewYorkTimes.StartCrawlerAsync("https://www.nytimes.com/section/sports", "sport");
        }
    }
}

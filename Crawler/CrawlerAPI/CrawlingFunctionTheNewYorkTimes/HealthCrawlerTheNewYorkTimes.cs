using CrawlerAPI.NewsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrawlerAPI.CrawlingFunctionTheNewYorkTimes
{
    public class HealthCrawlerTheNewYorkTimes
    {
        public static async Task<List<News>> GetHealthNews()
        {
            return await CrawlerTheNewYorkTimes.StartCrawlerAsync("https://www.nytimes.com/section/health", "health");
        }
    }
}

using CrawlerAPI.NewsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrawlerAPI.CrawlingFunctionTheNewYorkTimes
{
    public static class PoliticsCrawlerTheNewYorkTimes
    {
        public static async Task<List<News>> GetPoliticsNews()
        {
            return await CrawlerTheNewYorkTimes.StartCrawlerAsync("https://www.nytimes.com/section/politics", "politics");
        }
    }
}

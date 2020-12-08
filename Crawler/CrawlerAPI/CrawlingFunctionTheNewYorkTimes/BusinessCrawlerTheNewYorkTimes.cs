using CrawlerAPI.NewsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrawlerAPI.CrawlingFunctionTheNewYorkTimes
{
    public class BusinessCrawlerTheNewYorkTimes
    {
        public static async Task<List<News>> GetBusinessNews()
        {
            return await CrawlerTheNewYorkTimes.StartCrawlerAsync("https://www.nytimes.com/section/business", "business");
        }
    }
}

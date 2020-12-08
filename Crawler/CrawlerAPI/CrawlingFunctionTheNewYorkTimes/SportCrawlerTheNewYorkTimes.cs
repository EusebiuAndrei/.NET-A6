using CrawlerAPI.NewsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrawlerAPI.CrawlingFunctionTheNewYorkTimes
{
    public static class SportCrawlerTheNewYorkTimes
    {
        public static async Task<List<News>> GetSportNews()
        {
            return await CrawlerTheNewYorkTimes.StartCrawlerAsync("https://www.nytimes.com/section/sports", "sport");
        }
    }
}

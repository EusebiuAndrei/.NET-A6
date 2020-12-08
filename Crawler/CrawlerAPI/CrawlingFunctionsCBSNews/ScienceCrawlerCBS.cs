using CrawlerAPI.NewsModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrawlerAPI.CrawlingFunctionsBBC
{
    public static class ScienceCrawlerCBS
    {
        public static async Task<List<News>> GetScienceNews()
        {
            return await CrawlerCBS.StartCrawlerAsync("https://www.cbsnews.com/science/", new string[] { "component__item-wrapper", "item  item--type-article item--topic-space", "item  item--type-article item--topic-us", "item  item--type-article item--topic-world", "item  item--type-article item--topic-science" }, "science");
        }
    }
}

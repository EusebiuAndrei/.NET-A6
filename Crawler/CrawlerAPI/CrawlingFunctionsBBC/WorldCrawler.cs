using CrawlerAPI.NewsModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrawlerAPI.CrawlingFunctionsBBC
{
    public static class WorldCrawler
    {
        public static async Task<List<News>> GetWorldNews()
        {
            return await Crawler.StartCrawlerAsync("https://www.bbc.co.uk/news/world", new string[] {"gel-layout__item gel-1/4@xl gs-u-display-flex@xl", "gel-layout__item gel-1/1@m gel-1/3@xl gel-1/1@l gel-1/3@xxl nw-o-keyline nw-o-no-keyline@l"}, "h3", "world");
        }
    }
}

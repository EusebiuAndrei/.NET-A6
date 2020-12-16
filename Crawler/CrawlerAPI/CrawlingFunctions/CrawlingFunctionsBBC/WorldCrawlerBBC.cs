using CrawlerAPI.NewsModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrawlerAPI.CrawlingFunctions.CrawlingFunctionsBBC
{
    public static class WorldCrawlerBBC
    {
        public static async Task<List<News>> GetWorldNews()
        {
            return await CrawlerBBC.StartCrawlerAsync("https://www.bbc.co.uk/news/world", new string[] { "gel-layout__item gs-u-pb+@m gel-1/3@m gel0-1/4@xl gel-1/3@xxl nw-o-keyline nw-o-no-keyline@m", "gel-layout__item gs-u-pb+@m gel-1/3@m gel-1/4@xl gel-1/3@xxl nw-o-keyline nw-o-no-keyline@m" }, "world");
        }
    }
}

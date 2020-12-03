using CrawlerAPI.NewsModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrawlerAPI.CrawlingFunctionsBBC
{
    public static class BusinessCrawler
    {
        public static async Task<List<News>> GetBusinessNews()
        {
            return await Crawler.StartCrawlerAsync("https://www.bbc.co.uk/news/business", new string[] { "gel-layout__item gs-u-pb+@m gel-1/1@m gel-1/1@l gel-1/3@xl gel-1/3@xxl nw-o-keyline nw-o-no-keyline@l", "gel-layout__item gel-1/1@m gel-1/3@xl gel-1/1@l gel-1/3@xxl nw-o-keyline nw-o-no-keyline@m" }, "h3", "business");
        }
    }
}

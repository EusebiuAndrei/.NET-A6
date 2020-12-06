using CrawlerAPI.NewsModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrawlerAPI.CrawlingFunctionsBBC
{
    public static class BusinessCrawlerBBC
    {
        public static async Task<List<News>> GetBusinessNews()
        {
            return await CrawlerBBC.StartCrawlerAsync("https://www.bbc.co.uk/news/business", new string[] { "gel-layout__item gs-u-pb+@m gel-1/3@m gel0-1/4@xl gel-1/3@xxl nw-o-keyline nw-o-no-keyline@m", "gel-layout__item gs-u-pb+@m gel-1/3@m gel-1/4@xl gel-1/3@xxl nw-o-keyline nw-o-no-keyline@m" }, "business");
        }
    }
}

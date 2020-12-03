using CrawlerAPI.NewsModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrawlerAPI.CrawlingFunctionsBBC
{
    public static class CoronavirusCrawler
    {
        public static async Task<List<News>> GetCoronavirusNews()
        {
            return await Crawler.StartCrawlerAsync("https://www.bbc.co.uk/news/coronavirus", new string[] {"gel-layout__item gs-u-pb+@m gel-1/3@m gel0-1/4@xl gel-1/3@xxl nw-o-keyline nw-o-no-keyline@m", "gel-layout__item gs-u-pb+@m gel-1/3@m gel-1/4@xl gel-1/3@xxl nw-o-keyline nw-o-no-keyline@m", "gel-layout__item gs-u-pb+@m gel-1/1 gel-1/1@xl gel-2/5@xxl gs-u-ml0 nw-o-keyline nw-o-no-keyline@m"}, "h3", "coronavirus");
        }
    }
}


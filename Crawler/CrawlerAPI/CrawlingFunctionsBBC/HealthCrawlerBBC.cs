using CrawlerAPI.NewsModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrawlerAPI.CrawlingFunctionsBBC
{
    public static class HealthCrawlerBBC
    {
        public static async Task<List<News>> GetHealthNews()
        {
            return await CrawlerBBC.StartCrawlerAsync("https://www.bbc.co.uk/news/health", new string[]{"gel-layout__item gs-u-pb+@m gel-1/3@m gel-1/4@xl gel-1/3@xxl nw-o-keyline nw-o-no-keyline@m", "gel-layout__item gs-u-pb+@m gel-1/3@m gel0-1/4@xl gel-1/3@xxl nw-o-keyline nw-o-no-keyline@m", "gs-c-promo gs-t-News nw-c-promo gs-o-faux-block-link gs-u-pb gs-u-pb+@m nw-p-default gs-c-promo--inline@m gs-c-promo--stacked@xxl gs-c-promo--flex"}, "health");
        }
    }
}

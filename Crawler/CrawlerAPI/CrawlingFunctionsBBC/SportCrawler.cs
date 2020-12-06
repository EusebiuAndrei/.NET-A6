using System.Threading.Tasks;
using CrawlerAPI.NewsModel;
using System.Collections.Generic;

namespace CrawlerAPI.CrawlingFunctionsBBC
{
    public static class SportCrawler
    {
        public static async Task<List<News>> GetSportNews()
        {
            return await Crawler.StartCrawlerAsync("https://www.bbc.co.uk/sport", new string[] {"gel-layout__item gel-1/3@m gel-1/4@xxl sp-o-keyline sp-o-no-keyline@m"}, "sport");
        }
    }
}

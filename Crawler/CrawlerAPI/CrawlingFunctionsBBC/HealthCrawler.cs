using CrawlerAPI.NewsModel;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerAPI.CrawlingFunctionsBBC
{
    public class HealthCrawler
    {
        public async Task<List<News>> StartCrawlerAsync()
        {
            List<News> newsList = new List<News>();
            var url = "https://www.bbc.co.uk/news/health";
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            var divs = htmlDocument.DocumentNode.Descendants("div").Where(node => node.GetAttributeValue("class", "").Equals("gel-layout__item gs-u-pb+@m gel-1/3@m gel-1/4@xl gel-1/3@xxl nw-o-keyline nw-o-no-keyline@m")).ToList();
            foreach (var div in divs)
            {
                var title = div.Descendants("h3").FirstOrDefault().InnerText;
                var sourceLink = div.Descendants("a").FirstOrDefault().ChildAttributes("href").FirstOrDefault().Value;
                if (!sourceLink.StartsWith("https://www.bbc.co.uk"))
                {
                    sourceLink = "https://www.bbc.co.uk" + sourceLink;
                }

                var newsHtml = await httpClient.GetStringAsync(sourceLink);
                var newsHtmlDocument = new HtmlDocument();
                newsHtmlDocument.LoadHtml(newsHtml);
                var article = newsHtmlDocument.DocumentNode.Descendants("article").FirstOrDefault();
                var date = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
                try
                {
                    date = article.Descendants("time").FirstOrDefault().ChildAttributes("datetime").FirstOrDefault().Value;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                StringBuilder concatenateParagraphs = new StringBuilder();
                foreach (var item in article.DescendantsAndSelf())
                {
                    if (item.NodeType == HtmlNodeType.Text)
                    {
                        if (item.InnerText.Trim() != "" && !item.InnerText.StartsWith(".css"))
                        {
                            concatenateParagraphs.Append(HtmlEntity.DeEntitize(item.InnerText.Trim()));
                        }
                    }
                    
                }
                var news = new News
                {
                    Title = title,
                    Subject = "health",
                    Content = concatenateParagraphs.ToString(),
                    Date = DateTime.ParseExact(date.Substring(0, 19), "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture),
                    SourceLink = sourceLink,
                };
                newsList.Add(news);
            }
            return newsList;
        }
    }
}

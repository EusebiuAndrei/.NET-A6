using CrawlerAPI.NewsModel;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CrawlerAPI.CrawlingFunctions.CrawlingFunctionsABCNews
{
    public static class CrawlerABCNews
    {
        public static async Task<List<News>> StartCrawlerAsync(string url, string subject)
        {
            List<News> newsList = new List<News>();
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            var sections = htmlDocument.DocumentNode.Descendants("section").Where(node => node.GetAttributeValue("class", "").Equals("ContentRoll__Item")).ToList();
            foreach (var section in sections)
            {
                var descendantA = section.Descendants("a").FirstOrDefault();
                var title = HtmlEntity.DeEntitize(descendantA.InnerText);
                var sourceLink = descendantA.ChildAttributes("href").FirstOrDefault().Value;
                var newsHtml = await httpClient.GetStringAsync(sourceLink);
                var newsHtmlDocument = new HtmlDocument();
                newsHtmlDocument.LoadHtml(newsHtml);
                HtmlNode article;
                var date = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
                try
                {
                    article = newsHtmlDocument.DocumentNode.Descendants("article").Where(node => node.GetAttributeValue("class", "").Equals("Article__Wrapper")).FirstOrDefault();
                    date = article.Descendants("div").Where(node => node.GetAttributeValue("class", "").Equals("Byline__Meta Byline__Meta--publishDate")).FirstOrDefault().InnerText;
                }
                catch (Exception e)
                {
                    //Console.WriteLine(e);
                    continue;
                }
                var sectionContent = article.Descendants("section").Where(node => node.GetAttributeValue("class", "").Equals("Article__Content story")).FirstOrDefault();
                StringBuilder concatenateParagraphs = new StringBuilder();
                var textElements = new string[] { "h1", "h2", "h3", "h4", "h5", "h6", "p", "li" };
                foreach (var item in sectionContent.DescendantsAndSelf())
                {
                    if (textElements.Contains(item.Name))
                    {
                        if (item.InnerText.Trim() != "")
                        {
                            concatenateParagraphs.AppendLine(HtmlEntity.DeEntitize(Regex.Replace(item.InnerText.Trim(), @"\s+", " ")));
                        }
                    }
                }
                var news = new News
                {
                    Title = title,
                    Subject = subject,
                    Content = concatenateParagraphs.ToString(),
                    Date = Convert.ToDateTime(date),
                    SourceLink = sourceLink,
                };
                newsList.Add(news);
            }
            return newsList;
        }
    }
}

using CrawlerAPI.NewsModel;
using HtmlAgilityPack;  
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CrawlerAPI.CrawlingFunctionsBBC
{
    public static class CrawlerCBS
    {
        public static async Task<List<News>> StartCrawlerAsync(string url, string[] newsDivsClasses, string subject)
        {
            List<News> newsList = new List<News>();
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            var divs = htmlDocument.DocumentNode.Descendants("div").Where(node => node.GetAttributeValue("class", "").Equals(newsDivsClasses[0])).ToList();
            for(int i = 1; i < newsDivsClasses.Length; i++)
            {
                divs.AddRange(htmlDocument.DocumentNode.Descendants("article").Where(node => node.GetAttributeValue("class", "").Equals(newsDivsClasses[i])).ToList());
            }
            foreach (var div in divs)
            {
                string title = HtmlEntity.DeEntitize(div.Descendants("h4").FirstOrDefault().InnerText);
                var descendantA = div.Descendants("a").FirstOrDefault();
                var sourceLink = descendantA.ChildAttributes("href").FirstOrDefault().Value;

                var newsHtml = await httpClient.GetStringAsync(sourceLink);
                var newsHtmlDocument = new HtmlDocument();
                newsHtmlDocument.LoadHtml(newsHtml);
                HtmlNode article;
                var date = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
                try
                {
                    article = newsHtmlDocument.DocumentNode.Descendants("article").Where(node => node.GetAttributeValue("class", "").Equals("content content-article")).FirstOrDefault();
                    date = article.Descendants("time").FirstOrDefault().ChildAttributes("datetime").FirstOrDefault().Value;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                    continue;
                }
                var sectionContent = article.Descendants("section").Where(node => node.GetAttributeValue("class", "").Equals("content__body")).FirstOrDefault();
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

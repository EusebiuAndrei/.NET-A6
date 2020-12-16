using CrawlerAPI.NewsModel;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CrawlerAPI.CrawlingFunctions.CrawlingFunctionsTheNewYorkTimes
{
    public static class CrawlerTheNewYorkTimes
    {
        public static async Task<List<News>> StartCrawlerAsync(string url, string subject)
        {
            List<News> newsList = new List<News>();
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            var lists = htmlDocument.DocumentNode.Descendants("li").Where(node => node.GetAttributeValue("class", "").Equals("css-ye6x8s")).ToList();
            foreach (var list in lists)
            {
                var descendantA = list.Descendants("a").FirstOrDefault();
                var sourceLink = descendantA.ChildAttributes("href").FirstOrDefault().Value;
                var title = HtmlEntity.DeEntitize(descendantA.Descendants("h2").FirstOrDefault().InnerText);
                if (!sourceLink.StartsWith("https://www.nytimes.com"))
                {
                    sourceLink = "https://www.nytimes.com" + sourceLink;
                }
                var newsHtml = await httpClient.GetStringAsync(sourceLink);
                var newsHtmlDocument = new HtmlDocument();
                newsHtmlDocument.LoadHtml(newsHtml);

                HtmlNode article;
                var date = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
                try
                {
                    article = newsHtmlDocument.DocumentNode.Descendants("article").Where(node => node.GetAttributeValue("class", "").Equals("css-1vxca1d e1qksbhf0")).FirstOrDefault();
                    date = article.Descendants("time").FirstOrDefault().ChildAttributes("datetime").FirstOrDefault().Value;
                }
                catch (Exception e)
                {
                    //Console.WriteLine(e);
                    continue;
                }

                var sectionContent = article.Descendants("section").Where(node => node.GetAttributeValue("class", "").Equals("meteredContent css-1r7ky0e") || node.GetAttributeValue("class", "").Equals("meteredContent css-yw67de")).FirstOrDefault();
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

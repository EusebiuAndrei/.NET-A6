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
    public static class Crawler
    {
        public static async Task<List<News>> StartCrawlerAsync(string url, string[] newsDivsClasses, string titleType, string subject)
        {
            List<News> newsList = new List<News>();
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            var divs = htmlDocument.DocumentNode.Descendants("div").Where(node => node.GetAttributeValue("class", "").Equals(newsDivsClasses[0])).ToList();
            for(int i = 1; i < newsDivsClasses.Length; i++)
            {
                divs.AddRange(htmlDocument.DocumentNode.Descendants("div").Where(node => node.GetAttributeValue("class", "").Equals(newsDivsClasses[i])).ToList());
            }
            foreach (var div in divs)
            {
                string title = "";
                if(titleType == "data-bbc-title")
                {
                    var innerDiv = div.Descendants("div").FirstOrDefault();
                    title = HtmlEntity.DeEntitize(innerDiv.ChildAttributes("data-bbc-title").FirstOrDefault().Value);
                }
                else
                {
                    if(titleType == "h3")
                    {
                        title = HtmlEntity.DeEntitize(div.Descendants("h3").FirstOrDefault().InnerText);
                    }
                }
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
                    try
                    {
                        if (item.ChildAttributes("id").FirstOrDefault().Value == "view-comments")
                        {
                            break;
                        }
                    }catch(Exception e)
                    {
                    }
                    if (item.NodeType == HtmlNodeType.Text)
                    {
                        if (item.InnerText.Trim() != "" && !item.InnerText.StartsWith("."))
                        {
                            concatenateParagraphs.Append(HtmlEntity.DeEntitize(item.InnerText.Trim()));
                        }
                    }
                }
                var news = new News
                {
                    Title = title,
                    Subject = subject,
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

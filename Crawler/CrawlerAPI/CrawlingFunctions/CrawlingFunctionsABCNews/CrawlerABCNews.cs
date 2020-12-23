using CrawlerAPI.NewsModel;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
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
            var scriptText = htmlDocument.DocumentNode.Descendants("script").Where(node => node.InnerText.StartsWith("window['__abcnews__']")).FirstOrDefault().InnerText;
            var contentJson = scriptText.Substring(scriptText.IndexOf('{'));
            contentJson = contentJson.Substring(0, contentJson.Length - 1);
            JObject json = JObject.Parse(contentJson);
            var pageBands = json.GetValue("page").ToObject<JObject>().GetValue("content").ToObject<JObject>().GetValue("section").ToObject<JObject>().GetValue("bands");
            var newsComponentItems = pageBands.Where(band => band.ToObject<JObject>().GetValue("type").ToString() == "articleroll").First().ToObject<JObject>().GetValue("blocks").First().ToObject<JObject>().GetValue("items").ToObject<JObject>().GetValue("latestVideos");
            foreach (var newsItem in newsComponentItems)
            {
                var itemObj = newsItem.ToObject<JObject>();
                var title = itemObj.GetValue("title").ToString();
                var sourceLink = itemObj.GetValue("location").ToString();
                var imageSource = itemObj.GetValue("image").ToString();
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
                    ImageSource = imageSource
                };
                newsList.Add(news);
            }
            return newsList;
        }
    }
}

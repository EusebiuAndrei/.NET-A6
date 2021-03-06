﻿using CrawlerAPI.NewsModel;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CrawlerAPI.CrawlingFunctions.CrawlingFunctionsBBC
{
    public static class CrawlerBBC
    {
        public static async Task<List<News>> StartCrawlerAsync(string url, string[] newsDivsClasses, string subject)
        {
            List<News> newsList = new List<News>();
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            var divs = htmlDocument.DocumentNode.Descendants("div").Where(node => node.GetAttributeValue("class", "").Equals(newsDivsClasses[0])).ToList();
            for (int i = 1; i < newsDivsClasses.Length; i++)
            {
                divs.AddRange(htmlDocument.DocumentNode.Descendants("div").Where(node => node.GetAttributeValue("class", "").Equals(newsDivsClasses[i])).ToList());
            }
            foreach (var div in divs)
            {
                string title = HtmlEntity.DeEntitize(div.Descendants("h3").FirstOrDefault().InnerText);
                var descendantA = div.Descendants("a").FirstOrDefault();
                var sourceLink = descendantA.ChildAttributes("href").FirstOrDefault().Value;
                if (!sourceLink.StartsWith("https://www.bbc.co.uk"))
                {
                    sourceLink = "https://www.bbc.co.uk" + sourceLink;
                }
                try
                {
                    if (descendantA.Descendants("span").FirstOrDefault().ChildAttributes("class").FirstOrDefault().Value == "gs-o-bullet gs-c-live-pulse gs-c-live-pulse--sport gs-u-mr")
                    {
                        continue;
                    }
                }
                catch (Exception e)
                {
                    //Console.WriteLine(e);
                }
                var imageSource = "";
                try
                {
                    string src = "src";
                    var img = div.Descendants("img").FirstOrDefault();
                    if (img.Attributes.Contains("srcset"))
                    {
                        src = "srcset";
                    }
                    else
                    {
                        if (img.Attributes.Contains("data-src"))
                        {
                            src = "data-src";
                        }
                    }
                    imageSource = img.ChildAttributes(src).FirstOrDefault().Value;
                    if(imageSource.IndexOf(' ') != -1)
                    {
                        imageSource = imageSource.Substring(0, imageSource.IndexOf(' '));
                    }
                    if (imageSource.Contains("{width}"))
                    {
                        imageSource = imageSource.Replace("{width}", "240");
                    }
                }
                catch(Exception e)
                {
                    //Console.WriteLine(e);
                    continue;
                }
                var newsHtml = await httpClient.GetStringAsync(sourceLink);
                var newsHtmlDocument = new HtmlDocument();
                newsHtmlDocument.LoadHtml(newsHtml);
                HtmlNode article;
                var date = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
                try
                {
                    article = newsHtmlDocument.DocumentNode.Descendants("article").Where(node => !node.GetAttributeValue("class", "").Contains("sp-c-fixture")).FirstOrDefault();
                    date = article.Descendants("time").FirstOrDefault().ChildAttributes("datetime").FirstOrDefault().Value;
                }
                catch (Exception e)
                {
                    //Console.WriteLine(e);
                    continue;
                }
                StringBuilder concatenateParagraphs = new StringBuilder();
                var textElements = new string[] { "h1", "h2", "h3", "h4", "h5", "h6", "p", "li" };
                foreach (var item in article.DescendantsAndSelf())
                {
                    if (item.Name == "header" || item.ParentNode.Name == "header")
                    {
                        continue;
                    }
                    if (item.Id.Contains("comments"))
                    {
                        break;
                    }
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
                    Date = DateTime.ParseExact(date.Substring(0, 19), "yyyy-MM-ddTHH:mm:ss", new CultureInfo("ro-RO")),
                    SourceLink = sourceLink,
                    ImageSource = imageSource
                };
                newsList.Add(news);
            }
            return newsList;
        }
    }
}

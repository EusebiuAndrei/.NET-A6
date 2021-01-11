using AspNetCoreSchedulerDemo.BackgroundService;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using API.Entities;

namespace AspNetCoreSchedulerDemo.ScheduleTask
{
    public class Task1 : ScheduledProcessor
    {

        public Task1(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
        {

        }

        protected override string Schedule => "22 * * * *"; // every 1 min 
        //0 */3 * * * 
        public override Task ProcessInScope(IServiceProvider scopeServiceProvider)
        {
            Console.WriteLine("a intrat in task");
            HttpClient clientCrawlerApi = new HttpClient();

            clientCrawlerApi.BaseAddress = new Uri("https://localhost:5001");
            clientCrawlerApi.DefaultRequestHeaders.Accept.Clear();
            clientCrawlerApi.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Console.WriteLine("incepe apelul la crawler");
            var list_topics = new List<string>() { "sport", "business", "coronavirus", "health", "world", "entertainment", "politics", "technology" };
            var list_news = new List<NewsFromCrawling>();
            HttpClient clientFakeNewsApi = new HttpClient();

            clientFakeNewsApi.BaseAddress = new Uri("https://localhost:5003/");
            clientFakeNewsApi.DefaultRequestHeaders.Accept.Clear();
            clientFakeNewsApi.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            foreach (var topic in list_topics)
            {
                var getTask = clientCrawlerApi.GetAsync("api/v1/latest-news?website=all&subject="+topic+"&hoursNumber=3");
                getTask.Wait();
                var result = getTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    Console.WriteLine("a facut request la crawler");
                    var readTask = result.Content.ReadAsAsync<List<NewsFromCrawling>>();
                    readTask.Wait();
                    var newsResult = readTask.Result;

                    List<NewsToClassify> fromCrawlerToClassifyNews = new List<NewsToClassify>();
                    foreach(var news in newsResult)
                    {
                        fromCrawlerToClassifyNews.Add(
                            new NewsToClassify()
                            {
                                Title = news.Title,
                                Text = news.Content,
                                Subject = news.Subject
                            }
                        );
                    }
                    var postTask = clientFakeNewsApi.PostAsJsonAsync("api/v1/validator/news-list", fromCrawlerToClassifyNews);
                    postTask.Wait();
                    var resultPostClassifier = postTask.Result;
                    if (resultPostClassifier.IsSuccessStatusCode)
                    {
                        var readTaskPost = result.Content.ReadAsAsync<List<NewsToClassify>>();
                        readTaskPost.Wait();

                        var newsResultPost = readTaskPost.Result;
                        foreach(var item in newsResultPost)
                        {
                            Console.Write(item.Classified);
                        }
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine(resultPostClassifier.StatusCode);
                    }
                    list_news.AddRange(newsResult);
                }
                else
                {
                    Console.WriteLine(result.StatusCode);
                }
            }

            Console.WriteLine(list_news.Count);

            return Task.CompletedTask;
        }
    }
}
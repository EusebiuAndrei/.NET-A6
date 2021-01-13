using AspNetCoreSchedulerDemo.BackgroundService;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using API.Entities;
using API.Data;

namespace AspNetCoreSchedulerDemo.ScheduleTask
{
    public class Task1 : ScheduledProcessor
    {
        public Task1(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
        {

        }

        protected override string Schedule => "35 * * * *";
        //" "0 */3 * * *"; // every 3 hours 
        //44 * * * *   -> every hour on minute 44

        public int GetTopicBySubject(string subject)
        {
            switch (subject)
            {
                case "sport": return 1;
                case "politics": return 2;
                case "entertainment": return 3;
                case "technology": return 4;
                case "world": return 5;
                case "business": return 6;
                case "coronavirus": return 7;
                case "health": return 8;
                default: return 1;
            }
        }
        public override Task ProcessInScope(IServiceProvider scopeServiceProvider)
        {
            INewsRepository newsRepository;
            var scope = _serviceScopeFactory.CreateScope();
            newsRepository = scope.ServiceProvider.GetRequiredService<INewsRepository>();
            int id = 1;

            HttpClient clientCrawlerApi = new HttpClient();
            clientCrawlerApi.BaseAddress = new Uri("https://localhost:5001");
            clientCrawlerApi.DefaultRequestHeaders.Accept.Clear();
            clientCrawlerApi.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var list_topics = new List<string>() { "sport", "business", "coronavirus", "health", "world", "entertainment", "politics", "technology" };
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
                    var readTask = result.Content.ReadAsAsync<List<NewsFromCrawling>>();
                    readTask.Wait();
                    var newsResult = readTask.Result;

                    List<NewsToClassify> fromCrawlerToClassifyNews = new List<NewsToClassify>();
                    foreach(var news in newsResult)
                    {
                        fromCrawlerToClassifyNews.Add(
                            new NewsToClassify
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
                        var readTaskPost = resultPostClassifier.Content.ReadAsAsync<List<string>>();
                        readTaskPost.Wait();

                        var newsResultPost = readTaskPost.Result;
                        
                        for (int i = 0; i < newsResultPost.Count; i++)
                        {
                            newsRepository.Create(
                                new News
                                {
                                    Id = id,
                                    Title = newsResult[i].Title,
                                    Date = newsResult[i].Date,
                                    Text = newsResult[i].Content,
                                    SourceLink = newsResult[i].SourceLink,
                                    SourceImage = newsResult[i].ImageSource,
                                    ClassifiedAs = Convert.ToInt16(newsResultPost[i]),
                                    Views = 0,
                                    Read = 0,
                                    TopicId = GetTopicBySubject(newsResult[i].Subject)
                                }    
                            );
                            id++;
                        }
                    }
                    else
                    {
                        Console.WriteLine(resultPostClassifier.StatusCode);
                    }
                }
                else
                {
                    Console.WriteLine(result.StatusCode);
                }
            }
            return Task.CompletedTask;
        }
    }
}
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

        protected override string Schedule => "36 * * * *"; // every 1 min 
        //0 */3 * * * 
        public override Task ProcessInScope(IServiceProvider scopeServiceProvider)
        {
            Console.WriteLine("a intrat in task");
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://localhost:5001");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Console.WriteLine("incepe apelul la crawler");
            var getTask = client.GetAsync("api/v1/latest-news?website=all&subject=all&hoursNumber=3");
            getTask.Wait();
            var result = getTask.Result;
            Console.WriteLine(result);
            Console.WriteLine(result.StatusCode);
            if (result.IsSuccessStatusCode)
            {
                Console.WriteLine("a facut request la crawler");
                var readTask = result.Content.ReadAsAsync<List<NewsFromCrawling>>();
                readTask.Wait();
                var newsResult = readTask.Result;
                foreach(var item in newsResult)
                {
                    Console.WriteLine(item.Title);
                }
            }
            else
            {
                Console.WriteLine(result.StatusCode);
            }


            return Task.CompletedTask;
        }
    }
}
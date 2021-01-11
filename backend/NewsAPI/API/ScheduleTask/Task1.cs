using AspNetCoreSchedulerDemo.BackgroundService;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System.Net.Http.Headers;

namespace AspNetCoreSchedulerDemo.ScheduleTask
{
    public class Task1 : ScheduledProcessor
    {

        public Task1(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
        {

        }

        protected override string Schedule => "21 * * * *"; // every 1 min 
        //0 */3 * * * 
        public override Task ProcessInScope(IServiceProvider scopeServiceProvider)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://localhost:5001");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var getTask = client.GetAsync("api/v1/latest-news");
            getTask.Wait();

            var result = getTask.Result;
            if (result.IsSuccessStatusCode)
            {

                var readTask = result.Content.ReadAsAsync<string>();
                readTask.Wait();

                var newsResult = readTask.Result;
                Console.WriteLine(newsResult);
            }
            else
            {
                Console.WriteLine(result.StatusCode);
            }


            return Task.CompletedTask;
        }
    }
}
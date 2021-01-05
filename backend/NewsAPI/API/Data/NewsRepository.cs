using System.Diagnostics.Tracing;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System;
using System.Xml;
using System.Reflection.Metadata;
using System.Globalization;
using System.Runtime.CompilerServices;
using API.Entities;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.Data
{
    public class NewsRepository : INewsRepository
    {
        private readonly DataContext context;

        public NewsRepository(DataContext context)
        {
            this.context = context;
        }

        public void Create(News news)
        {
            this.context.Add(news);
            this.context.SaveChanges();
        }

        public void Update(int id, News news)
        {
            News entity = this.context.News.FirstOrDefault(n => n.Id == id);
            if (entity != null)
            {
                entity.Id = news.Id;
                entity.Title = news.Title;
                entity.Date = news.Date;
                entity.Text = news.Text;
                entity.SourceLink = news.SourceLink;
                entity.ClassifiedAs = news.ClassifiedAs;
                entity.Views = news.Views;
                entity.Read = news.Read;
            }

            this.context.SaveChanges();
        }

        public IEnumerable<News> GetAll()
        {
            return this.context.News.Include(n => n.Topic).AsNoTracking().ToList();
        }

        public News GetById(int id)
        {
            return this.context.News.Find(id);
        }

        public void Remove(int id)
        {
            this.context.News.Remove(this.context.News.FirstOrDefault(n => n.Id == id));
            this.context.SaveChanges();
        }

        public IEnumerable<News> GetLatestNews(int number)
        {
            return this.context.News.Include(n => n.Topic).AsNoTracking().OrderBy(o => o.Date).Take(number).ToList();
        }

        public void UpdateViews(int id)
        {
            News entity = this.context.News.FirstOrDefault(n => n.Id == id);
            if (entity != null)
            {
                entity.Views += 1;
            }

            this.context.SaveChanges();
        }

        public void UpdateRead(int id)
        {
            News entity = this.context.News.FirstOrDefault(n => n.Id == id);
            if (entity != null)
            {
                entity.Read += 1;
            }

            this.context.SaveChanges();
        }

        public string ValidateNewsAsync(NewsToClassify news)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://localhost:5003/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var postTask = client.PostAsJsonAsync("api/v1/validator", news);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {

                var readTask = result.Content.ReadAsAsync<string>();
                readTask.Wait();

                var newsResult = readTask.Result;
                return newsResult;
            }
            else
            {
                Console.WriteLine(result.StatusCode);
                return null;
            }

            
        }
    }
}

using System.Data;
using System.Net.Http.Headers;
using System;
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
        private readonly DataContext _context;

        public NewsRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(News news)
        {
            _context.Add(news);
            _context.SaveChanges();
        }

        public void Update(int id, News news)
        {
            News entity = _context.News.FirstOrDefault(n => n.Id == id);
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

            _context.SaveChanges();
        }

        public IEnumerable<News> GetAll()
        {
            return _context.News.Include(n => n.Topic).AsNoTracking().ToList();
        }

        public IEnumerable<News> GetAllByTopicId(int id)
        {
            return _context.News.Where(n => n.TopicId == id).Include(n => n.Topic).AsNoTracking().ToList();
        }

        public News GetNewsById(int id)
        {
            IQueryable<News> query = _context.News.Include(n => n.Topic).AsNoTracking();
            query = query.Where(n => n.Id == id);
            return query.First();
        }

        public IEnumerable<News> GetQueriedNews(int pageNumber, int nrOfNews, string search, 
            DateTime? fromDate, DateTime? toDate, Int16? classifiedAs, int? topicId)
        {
            char[] delimiterChars = { ' ', ',', '.', ':', '\t', '(', ')', '"', ';' };
            IEnumerable<News> query = _context.News.Include(n => n.Topic).AsNoTracking();

            if (!string.IsNullOrEmpty(search)) {
                string[] words = search.ToLower().Split(' ');
                query = query.Where(n => n.Title.ToLower().Split(delimiterChars).Intersect(words).Any());
            }

            if (fromDate.HasValue && toDate.HasValue)
                query = query.Where(n => (DateTime.Compare((DateTime)fromDate, n.Date) <= 0 && DateTime.Compare(n.Date, (DateTime)toDate) <= 0));

            if (classifiedAs.HasValue)
                query = query.Where(n => (n.ClassifiedAs == classifiedAs));

            if (topicId.HasValue)
                query = query.Where(n => (n.TopicId == topicId));

            return query.OrderByDescending(n => n.Date).Skip((pageNumber - 1) * nrOfNews).Take(nrOfNews);
        }

        public IEnumerable<News> GetLatestNews(int number)
        {
            return _context.News.Include(n => n.Topic).AsNoTracking().OrderBy(o => o.Date).Take(number).ToList();
        }

        public void UpdateViews(int id)
        {
            News entity = _context.News.FirstOrDefault(n => n.Id == id);
            if (entity != null)
            {
                entity.Views += 1;
            }

            _context.SaveChanges();
        }

        public void UpdateRead(int id)
        {
            News entity = _context.News.FirstOrDefault(n => n.Id == id);
            if (entity != null)
            {
                entity.Read += 1;
            }

            _context.SaveChanges();
        }

        public string ValidateNewsAsync(NewsToClassify news)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://localhost:5003");
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
        public void Remove(int id)
        {
            _context.News.Remove(_context.News.FirstOrDefault(n => n.Id == id));
            _context.SaveChanges();
        }
    }
}

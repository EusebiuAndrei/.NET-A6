using System.Globalization;
using System.Runtime.CompilerServices;
using API.Entities;
using System.Collections.Generic;
using System.Linq;

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
            }

            this.context.SaveChanges();
        }

        public IEnumerable<News> GetAll()
        {
            return this.context.News.ToList();
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


    }
}

using System.Globalization;
using System.Runtime.CompilerServices;
using API.Entities;
using System.Collections.Generic;
using System.Linq;

namespace API.Data
{
    public class NewsTopicRepository : INewsTopicRepository
    {
        private readonly DataContext context;

        public NewsTopicRepository(DataContext context)
        {
            this.context = context;
        }

        public void Create(NewsTopic newsTopic)
        {
            this.context.Add(newsTopic);
            this.context.SaveChanges();
        }

        public void Update(int id, NewsTopic newsTopic)
        {
            NewsTopic entity = this.context.NewsTopic.FirstOrDefault(n => n.Id == id);
            if (entity != null)
            {
                entity.Id = newsTopic.Id;
                entity.NewsId = newsTopic.NewsId;
                entity.TopicId = newsTopic.TopicId;
            }

            this.context.SaveChanges();
        }

        public IEnumerable<NewsTopic> GetAll()
        {
            return this.context.NewsTopic.ToList();
        }

        public NewsTopic GetById(int id)
        {
            return this.context.NewsTopic.Find(id);
        }

        public void Remove(int id)
        {
            this.context.NewsTopic.Remove(this.context.NewsTopic.FirstOrDefault(n => n.Id == id));
            this.context.SaveChanges();
        }


    }
}

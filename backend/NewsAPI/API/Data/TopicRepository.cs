using System.Globalization;
using System.Runtime.CompilerServices;
using API.Entities;
using System.Collections.Generic;
using System.Linq;

namespace API.Data
{
    public class TopicRepository : ITopicRepository
    {
        private readonly DataContext context;

        public TopicRepository(DataContext context)
        {
            this.context = context;
        }

        public void Create(Topic topic)
        {
            this.context.Add(topic);
            this.context.SaveChanges();
        }

        public void Update(int id, Topic topic)
        {
            Topic entity = this.context.Topic.FirstOrDefault(t => t.Id == id);
            if (entity != null)
            {
                entity.Id = topic.Id;
                entity.Name = topic.Name;
            }

            this.context.SaveChanges();
        }

        public IEnumerable<Topic> GetAll()
        {
            return this.context.Topic.ToList();
        }

        public Topic GetById(int id)
        {
            return this.context.Topic.Find(id);
        }

        public void Remove(int id)
        {
            this.context.Topic.Remove(this.context.Topic.FirstOrDefault(t => t.Id == id));
            this.context.SaveChanges();
        }

    }
}

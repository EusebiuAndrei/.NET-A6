using API.Entities;
using System.Collections.Generic;
using System.Linq;

namespace API.Data
{
    public class TopicRepository : ITopicRepository
    {
        private readonly DataContext _context;

        public TopicRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Topic topic)
        {
            _context.Add(topic);
            _context.SaveChanges();
        }

        public void Update(int id, Topic topic)
        {
            Topic entity = _context.Topic.FirstOrDefault(t => t.Id == id);
            if (entity != null)
            {
                entity.Id = topic.Id;
                entity.Name = topic.Name;
            }

            _context.SaveChanges();
        }

        public IEnumerable<Topic> GetAll()
        {
            return _context.Topic.ToList();
        }

        public Topic GetById(int id)
        {
            return _context.Topic.Find(id);
        }

        public void Remove(int id)
        {
            _context.Topic.Remove(_context.Topic.FirstOrDefault(t => t.Id == id));
            _context.SaveChanges();
        }

    }
}

using API.Entities;
using System.Collections.Generic;

namespace API.Data
{
    public interface ITopicRepository
    {
        void Create(Topic topic);
        IEnumerable<Topic> GetAll();
        Topic GetById(int id);
        void Remove(int id);
        void Update(int id, Topic topic);
    }
}
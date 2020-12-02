using API.Entities;
using System.Collections.Generic;

namespace API.Data
{
    public interface INewsTopicRepository
    {
        void Create(NewsTopic newsTopic);
        IEnumerable<NewsTopic> GetAll();
        NewsTopic GetById(int id);
        void Remove(int id);
        void Update(int id, NewsTopic newsTopic);
    }
}
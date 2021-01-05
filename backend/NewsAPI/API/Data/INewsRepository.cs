using API.Entities;
using System.Collections.Generic;

namespace API.Data
{
    public interface INewsRepository
    {
        void Create(News news);
        IEnumerable<News> GetAll();
        News GetById(int id);
        void Remove(int id);
        void Update(int id, News news);
        IEnumerable<News> GetLatestNews(int number);
    }
}
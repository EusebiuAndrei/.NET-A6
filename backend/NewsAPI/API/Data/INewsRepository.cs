using API.Entities;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

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
        void UpdateViews(int id);
        void UpdateRead(int id);

        string ValidateNewsAsync(NewsToClassify news);
    }
}
using API.Entities;
using System.Collections.Generic;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.Data
{
    public interface INewsRepository
    {
        void Create(News news);
        IEnumerable<News> GetAll();
        IEnumerable<News> GetQueriedNews(int pageNumber, int nrOfNews, string search, 
            DateTime? fromDate, DateTime? toDate, Int16? classifiedAs, int? topicId);
        News GetNewsById(int id);
        void Remove(int id);
        void Update(int id, News news);
        IEnumerable<News> GetLatestNews(int number);
        void UpdateViews(int id);
        void UpdateRead(int id);

        string ValidateNewsAsync(NewsToClassify news);
    }
}
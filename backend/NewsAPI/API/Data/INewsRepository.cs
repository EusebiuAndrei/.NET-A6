using API.Entities;
using System.Collections.Generic;
using System;

namespace API.Data
{
    public interface INewsRepository
    {
        void Create(News news);
        IEnumerable<News> GetAll();
        IEnumerable<News> GetQueriedNews(int nrOfNews, string wordInTitle, 
            DateTime? fromDate, DateTime? toDate, Int16? classifiedAs, int? topicId);
        News GetById(int id);
        void Remove(int id);
        void Update(int id, News news);
    }
}
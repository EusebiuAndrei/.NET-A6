using System.Runtime.InteropServices;
using System.Collections;
using System.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.ComponentModel;
using System.Reflection;
using System.Diagnostics.Tracing;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System;
using System.Xml;
using System.Reflection.Metadata;
using System.Globalization;
using System.Runtime.CompilerServices;
using API.Entities;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class NewsRepository : INewsRepository
    {
        private readonly DataContext _context;

        public NewsRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(News news)
        {
            _context.Add(news);
            _context.SaveChanges();
        }

        public void Update(int id, News news)
        {
            News entity = _context.News.FirstOrDefault(n => n.Id == id);
            if (entity != null)
            {
                entity.Id = news.Id;
                entity.Title = news.Title;
                entity.Date = news.Date;
                entity.Text = news.Text;
                entity.SourceLink = news.SourceLink;
                entity.ClassifiedAs = news.ClassifiedAs;
                entity.Views = news.Views;
                entity.Read = news.Read;
            }

            _context.SaveChanges();
        }

        public IEnumerable<News> GetAll()
        {
            return _context.News.Include(n => n.Topic).AsNoTracking().ToList();
        }

        public News GetById(int id)
        {
            return _context.News.Find(id);
        }

        public IEnumerable<News> GetQueriedNews(int pageNumber, int nrOfNews, string wordInTitle, 
            DateTime? fromDate, DateTime? toDate, Int16? classifiedAs, int? topicId)
        {
            IEnumerable<News> query = _context.News.Include(n => n.Topic).AsNoTracking();

            if (wordInTitle != null)
                query = query.Where(n => (n.Title.ToLower().Contains(wordInTitle.ToLower())));
            
            if (fromDate.HasValue && toDate.HasValue)
                query = query.Where(n => (DateTime.Compare((DateTime)fromDate, n.Date) <= 0 && DateTime.Compare(n.Date, (DateTime)toDate) <= 0));

            if (classifiedAs.HasValue)
                query = query.Where(n => (n.ClassifiedAs == classifiedAs));

            if (topicId.HasValue)
                query = query.Where(n => (n.TopicId == topicId));

            return query.OrderByDescending(n => n.Date).Skip((pageNumber - 1) * nrOfNews).Take(nrOfNews);
        }

        public void Remove(int id)
        {
            _context.News.Remove(_context.News.FirstOrDefault(n => n.Id == id));
            _context.SaveChanges();
        }


    }
}

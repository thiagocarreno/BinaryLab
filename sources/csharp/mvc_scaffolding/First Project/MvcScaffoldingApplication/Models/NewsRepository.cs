using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MvcScaffoldingApplication.Models
{ 
    public class NewsRepository : INewsRepository
    {
        MvcScaffoldingApplicationContext context = new MvcScaffoldingApplicationContext();

        public IQueryable<News> All
        {
            get { return context.News; }
        }

        public IQueryable<News> AllIncluding(params Expression<Func<News, object>>[] includeProperties)
        {
            IQueryable<News> query = context.News;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public News Find(int id)
        {
            return context.News.Find(id);
        }

        public void InsertOrUpdate(News news)
        {
            if (news.IdNews == default(int)) {
                // New entity
                context.News.Add(news);
            } else {
                // Existing entity
                context.Entry(news).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var news = context.News.Find(id);
            context.News.Remove(news);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose() 
        {
            context.Dispose();
        }
    }

    public interface INewsRepository : IDisposable
    {
        IQueryable<News> All { get; }
        IQueryable<News> AllIncluding(params Expression<Func<News, object>>[] includeProperties);
        News Find(int id);
        void InsertOrUpdate(News news);
        void Delete(int id);
        void Save();
    }
}
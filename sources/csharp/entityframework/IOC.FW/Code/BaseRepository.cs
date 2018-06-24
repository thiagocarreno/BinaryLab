using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Configuration;
using IOC.FW.Abstraction.DAO;
using System.Linq.Expressions;
using IOC.FW.Abstraction.Model;

namespace IOC.FW.Code
{
    public class BaseRepository<TModel>
        : IBaseDAO<TModel>
        where TModel : class
    {
        private Repository<TModel> Context { get; set; }

        public BaseRepository()
        {
            this.Context = new Repository<TModel>((ConfigurationManager.ConnectionStrings["DefaultConnection"]).ConnectionString);
        }

        public BaseRepository(string connectionString)
        {
            this.Context = new Repository<TModel>(connectionString);
        }

        private IQueryable<TModel> IncludeReference(DbSet<TModel> dbSet, params Expression<Func<TModel, object>>[] navigationProperties) 
        {
            IQueryable<TModel> query = dbSet;

            foreach (Expression<Func<TModel, object>> navigationProperty in navigationProperties)
                query = query.Include<TModel, object>(navigationProperty);

            return query;
        }

        public IList<TModel> SelectAll(
            params Expression<Func<TModel, object>>[] navigationProperties
        )
        {
            List<TModel> list;

            this.Context._dbQuery = IncludeReference(this.Context.DbObject, navigationProperties);

            list = this.Context._dbQuery
                .AsNoTracking()
                .ToList<TModel>();
            return list;
        }

        public IList<TModel> Select(
            Func<TModel, bool> where,
            params Expression<Func<TModel, object>>[] navigationProperties
        )
        {
            List<TModel> list;

            this.Context._dbQuery = IncludeReference(this.Context.DbObject, navigationProperties);

            list = this.Context._dbQuery
                .AsNoTracking()
                .Where(where)
                .ToList<TModel>();
            return list;
        }

        public TModel SelectSingle(
            Func<TModel, bool> where,
            params Expression<Func<TModel, object>>[] navigationProperties
        )
        {
            TModel item = null;

            this.Context._dbQuery = IncludeReference(this.Context.DbObject, navigationProperties);

            item = this.Context._dbQuery
                .AsNoTracking()
                .FirstOrDefault(where);
            return item;
        }

        public void Insert(params TModel[] items)
        {
            foreach (TModel item in items)
            {
                if (item is IBaseModel)
                {
                    var baseItem = (IBaseModel)item;
                    baseItem.Created = DateTime.Now;
                    baseItem.Activated = true;
                }
                this.Context.Entry(item).State = EntityState.Added;
            }
            this.Context.SaveChanges();
        }

        public void Update(params TModel[] items)
        {
            foreach (TModel item in items)
            {
                if (item is IBaseModel)
                {
                    ((IBaseModel)item).Updated = DateTime.Now;
                }
                this.Context.Entry(item).State = EntityState.Modified;
            }
            this.Context.SaveChanges();
        }

        public void Delete(params TModel[] items)
        {
            foreach (TModel item in items)
            {
                if (item is IBaseModel)
                {
                    var baseItem = (IBaseModel)item;
                    baseItem.Updated = DateTime.Now;
                    baseItem.Activated = false;
                    this.Context.Entry(item).State = EntityState.Modified;
                }
                else
	            {
                    this.Context.Entry(item).State = EntityState.Deleted;
	            }
            }
            this.Context.SaveChanges();
        }
    }
}
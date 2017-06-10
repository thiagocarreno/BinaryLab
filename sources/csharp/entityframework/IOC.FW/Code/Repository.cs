using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Configuration;

namespace IOC.FW.Code
{
    public class Repository<TModel>
        : DbContext
        where TModel : class
    {
        public DbSet<TModel> DbObject { get; set; }
        public IQueryable<TModel> _dbQuery;

        public Repository(string connectionString)
            : base(connectionString)
        {
            this._dbQuery = this.DbObject;
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
    }
}
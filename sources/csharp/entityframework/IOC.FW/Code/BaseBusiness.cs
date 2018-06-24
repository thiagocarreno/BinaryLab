using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOC.FW.Factory;
using IOC.FW.Abstraction.Business;
using IOC.FW.Abstraction.DAO;
using System.Linq.Expressions;

namespace IOC.FW.Code
{
    public abstract class BaseBusiness<TModel>
        : IBaseBusiness<TModel>
        where TModel : class
    {
        protected readonly IBaseDAO<TModel> _dao;

        public BaseBusiness(IBaseDAO<TModel> dao)
        {
            this._dao = dao;
        }

        public IList<TModel> SelectAll(
            params Expression<Func<TModel, object>>[] navigationProperties
        )
        {
            return this._dao.SelectAll(navigationProperties);
        }

        public IList<TModel> Select(
            Func<TModel, bool> where,
            params Expression<Func<TModel, object>>[] navigationProperties
        )
        {
            return this._dao.Select(where, navigationProperties);
        }

        public TModel SelectSingle(
            Func<TModel, bool> where,
            params Expression<Func<TModel, object>>[] navigationProperties
        )
        {
            return this._dao.SelectSingle(where, navigationProperties);
        }

        public void Insert(params TModel[] items)
        {
            this._dao.Insert(items);
        }

        public void Update(params TModel[] items)
        {
            this._dao.Update(items);
        }

        public void Delete(params TModel[] items)
        {
            this._dao.Delete(items);
        }
    }
}
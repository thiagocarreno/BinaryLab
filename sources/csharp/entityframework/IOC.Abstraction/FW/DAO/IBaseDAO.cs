using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace IOC.Interface.FW.DAO
{
    public interface IBaseDAO<TModel>
    {
        void TesteDAO();

        //IList<TModel> SelectAll(params Expression<Func<TModel, object>>[] navigationProperties);
        //IList<TModel> Select(Func<TModel, bool> where, params Expression<Func<TModel, object>>[] navigationProperties);
        //TModel SelectSingle(Func<TModel, bool> where, params Expression<Func<TModel, object>>[] navigationProperties);
        //void Insert(params TModel[] items);
        //void Update(params TModel[] items);
        //void Delete(params TModel[] items);
    }
}
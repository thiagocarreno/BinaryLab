﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using IOC.Interface.FW.DAO;

namespace IOC.Interface.FW.Business
{
    public interface IBaseBusiness<TModel>
    {
        void TesteBusiness();

        //IList<TModel> SelectAll(params Expression<Func<TModel, object>>[] navigationProperties);
        //IList<TModel> Select(Func<TModel, bool> where, params Expression<Func<TModel, object>>[] navigationProperties);
        //TModel SelectSingle(Func<TModel, bool> where, params Expression<Func<TModel, object>>[] navigationProperties);
        //void Insert(params TModel[] items);
        //void Update(params TModel[] items);
        //void Delete(params TModel[] items);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.OData;

namespace Study.Orderable.WebApiApp.Controllers
{
    public class Test2Controller : ApiController
    {
        private readonly IEnumerable<Test2Model> _values;

        public Test2Controller()
        {
            _values = new List<Test2Model>
            {
                new Test2Model
                {
                    Id = 1,
                    FirstName = "Thiago",
                    SurName = "Carreño"
                },
                new Test2Model
                {
                    Id = 2,
                    FirstName = "Lucas",
                    SurName = "Bertin"
                },
                new Test2Model
                {
                    Id = 3,
                    FirstName = "Lucas",
                    SurName = "Teles"
                }
            };
        }

        // GET api/values
        public IHttpActionResult Get()
        {
            var sortFields = "Name";

            var values = _values.AsQueryable()
                .OrderBy(sortFields.Split(','), QueryableOrder.ASC)
                .ToList();

            return Ok(values);
        }

        // GET api/values/5
        public IHttpActionResult Get(int id)
        {
            var value = _values.First(
                v => v.Id.Equals(id)
            );

            return Ok(value);
        }
    }

    public class Test2Model
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
    }

    public static class Extensions
    {
        public static Func<T, bool> AndAlso<T>(
            this Func<T, bool> predicate1,
            Func<T, bool> predicate2
        )
        {
            return arg => predicate1(arg) && predicate2(arg);
        }

        public static IQueryable<T> OrderBy<T>(this IQueryable<T> query, string[] sortFields, QueryableOrder queryableOrder)
        {
            var param = Expression.Parameter(typeof(T), "p");
            var prop = Expression.Property(param, sortFields[0]);
            LambdaExpression expression = Expression.Lambda(prop, param);

            //foreach (var sortField in sortFields)
            //{
            //    var param1 = Expression.Parameter(typeof(T), "p");
            //    var prop1 = Expression.Property(param1, sortField);
            //    var nextExpression = Expression.Lambda(prop1, param1);
            //}

            var types = new Type[] 
            {
                query.ElementType,
                expression.Body.Type
            };

            var rs = Expression.Call(
                typeof(Queryable),
                queryableOrder.Order,
                types,
                query.Expression,
                expression
            );

            return query.Provider.CreateQuery<T>(rs);
        }
    }

    public class QueryableOrder
        : IEquatable<QueryableOrder>
    {
        public static QueryableOrder ASC
        {
            get
            {
                return new QueryableOrder("OrderBy");
            }
        }
        public static QueryableOrder DESC
        {
            get
            {
                return new QueryableOrder("OrderByDescending");
            }
        }
        public string Order { get; private set; }    

        private QueryableOrder(string order)
        {
            Order = order;
        }

        public bool Equals(QueryableOrder other)
        {
            return Order.Equals(other);
        }
    }
}
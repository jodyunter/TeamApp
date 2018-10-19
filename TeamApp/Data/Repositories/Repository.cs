using NHibernate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TeamApp.Domain.Repositories;

namespace TeamApp.Data.Repositories
{
    public class Repository<T> : IRepository<T>, IQueryable<T>
    {
        private readonly ISession session;

        public Repository() { session = NHibernateHelper.OpenSession(); }

        public Type ElementType { get { return session.Query<T>().ElementType; } }

        public Expression Expression { get { return session.Query<T>().Expression; } }

        public IQueryProvider Provider { get { return session.Query<T>().Provider; } }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return session.Query<T>().GetEnumerator();
        }

        public long Add(T entity)
        {
            return (long)session.Save(entity);
        }

        public void Update(T entity)
        {
            session.Save(entity);
        }

        public void Remove(T entity)
        {
            session.Delete(entity);
        }

        public T Get(long id)
        {
            return session.Get<T>(id);
        }
    }
}

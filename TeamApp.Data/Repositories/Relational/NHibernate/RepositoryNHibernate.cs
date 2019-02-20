using NHibernate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TeamApp.Domain;
using TeamApp.Domain.Repositories;

namespace TeamApp.Data.Repositories.Relational.NHibernate
{
    public class RepositoryNHibernate<T> :IRelationalRepository<T>, IQueryable<T> where T : IDataObject
    {
        protected readonly ISession session;

        public RepositoryNHibernate() { session = NHibernateHelper.OpenSession(); }

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

        public object Add(T entity)
        { 
            return session.Save(entity);
        }

        public T Update(T entity)
        {
            try
            {
                session.SaveOrUpdate(entity);
            }
            catch (Exception)
            {
                session.Merge((IDataObject)entity);
            }

            return default(T);
        }

        public void Remove(T entity)
        {
            session.Delete(entity);
        }

        public T Get(long id)
        {
            return session.Get<T>(id);
        }

        public IEnumerable<T> GetAll()
        {
            return this.ToList();
        }

        public void Flush()
        {
            session.Flush();
        }

        public IDataObject GetById(long id)
        {
            throw new NotImplementedException();
        }
    }
}

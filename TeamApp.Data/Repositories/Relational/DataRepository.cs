using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TeamApp.Data.Repositories.Relational;
using TeamApp.Domain;
using TeamApp.Domain.Repositories;

namespace TeamApp.Data.Relational.Repositories
{
    public abstract class DataRepository<T> : IRelationalRepository<T> where T : IDataObject
    {
        private IRelationalRepository<T> baseRepo;
        public DataRepository(IRelationalRepository<T> baseImplementation)
        {
            baseRepo = baseImplementation;
        }        

        public Type ElementType { get { return baseRepo.ElementType; } }

        public Expression Expression { get { return baseRepo.Expression; } }

        public IQueryProvider Provider { get { return baseRepo.Provider; } }

        public object Add(T o)
        {            
            return baseRepo.Add(o);
        }

        public void Flush()
        {
            baseRepo.Flush();
        }

        public T Get(long id)
        {
            return baseRepo.Get(id);
        }

        public IEnumerable<T> GetAll()
        {
            return baseRepo.GetAll();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return baseRepo.GetEnumerator();
        }

        public void Remove(T o)
        {
            baseRepo.Remove(o);
        }

        public IDataObject Update(T o)
        {            
            return baseRepo.Update(o);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return baseRepo.GetEnumerator();
        }
    }
}

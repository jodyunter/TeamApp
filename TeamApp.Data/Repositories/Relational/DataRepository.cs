using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TeamApp.Domain;
using TeamApp.Domain.Repositories;

namespace TeamApp.Data.Relational.Repositories
{
    public abstract class DataRepository<T> : IRepository<T> where T : IDataObject
    {
        private IRepository<T> baseRepo;
        public DataRepository(IRepository<T> baseImplementation)
        {
            baseRepo = baseImplementation;
        }        

        public Type ElementType { get { return baseRepo.ElementType; } }

        public Expression Expression { get { return baseRepo.Expression; } }

        public IQueryProvider Provider { get { return baseRepo.Provider; } }

        public object Add(T team)
        {
            return baseRepo.Add(team);
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

        public void Remove(T team)
        {
            baseRepo.Remove(team);
        }

        public IDataObject Update(T team)
        {
            return baseRepo.Update(team);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return baseRepo.GetEnumerator();
        }
    }
}

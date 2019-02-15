using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamApp.Domain;
using TeamApp.Domain.Repositories;

namespace TeamApp.Data.Repositories.Relational
{
    public interface IRelationalRepository<T> : IQueryable<T> where T : IDataObject
    {
        object Add(T o);
        IDataObject Update(T o);
        void Remove(T o);
        T Get(long id);
        IEnumerable<T> GetAll();
        void Flush();

       
    }
}

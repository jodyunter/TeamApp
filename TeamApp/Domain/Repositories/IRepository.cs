using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamApp.Domain.Repositories
{
    public interface IRepository<T>: IQueryable<T> where T : IDataObject
    {
        object Add(T o, string user);
        IDataObject Update(T o, string user);
        void Remove(T o);
        T Get(long id);
        IEnumerable<T> GetAll();
        void Flush();
       
    }
}

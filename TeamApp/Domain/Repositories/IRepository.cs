using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamApp.Domain.Repositories
{
    public interface IRepository<T> where T : IDataObject
    {
        object Add(T team);
        void Update(T team);
        void Remove(T team);
        T Get(long id);
        IEnumerable<T> GetAll();
       
    }
}

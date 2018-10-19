using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamApp.Domain.Repositories
{
    public interface IRepository<T>:IQueryable<T>
    {
        long Add(T team);
        void Update(T team);
        void Remove(T team);
        T Get(long id);  
       
    }
}

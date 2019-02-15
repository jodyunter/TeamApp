using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamApp.Domain;
using TeamApp.Domain.Repositories;

namespace TeamApp.Data.Repositories.Relational
{
    public interface IRelationalRepository<T> :IRepository<T>, IQueryable<T> where T : IDataObject
    {
       
    }
}

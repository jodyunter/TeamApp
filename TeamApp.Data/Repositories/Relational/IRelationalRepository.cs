using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain;
using TeamApp.Domain.Repositories;

namespace TeamApp.Data.Repositories.Relational
{
    public interface IRelationalRepository<T>: IRepository<T> where T : IDataObject
    {
    }
}

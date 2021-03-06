﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamApp.Domain.Repositories
{
    public interface IRepository<T>
    {
        object Add(T o);
        T Update(T o);
        void Remove(T o);
        T Get(long id);
        IEnumerable<T> GetAll();
        void Flush();       
       
    }
}

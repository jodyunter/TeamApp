﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Repositories
{
    public interface ILeagueRepository:IRepository<League>
    {
        League GetByName(string name);
        IEnumerable<League> GetActiveLeagues(int year);
    }
}

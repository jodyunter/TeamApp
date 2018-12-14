using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain;
using TeamApp.Domain.Repositories;

namespace TeamApp.Data.Repositories.NHibernate
{
    public class LeagueRepository:RepositoryNHibernate<League>, ILeagueRepository
    {

    }
}

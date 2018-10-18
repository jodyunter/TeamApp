using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain;
using TeamApp.Domain.Repositories;
using NHibernate;

namespace TeamApp.Data.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        public void Add(Team team)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(team);
                transaction.Commit();
            }
        }

        public ICollection<Team> GetAll()
        {
            throw new NotImplementedException();
        }

        public Team GetById(Guid teamId)
        {
            throw new NotImplementedException();
        }

        public Team GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Remove(Team team)
        {
            throw new NotImplementedException();
        }

        public void Update(Team team)
        {
            throw new NotImplementedException();
        }
    }
}

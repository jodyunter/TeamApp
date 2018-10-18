using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Repositories
{
    public interface ITeamRepository
    {
        void Add(Team team);
        void Update(Team team);
        void Remove(Team team);
        Team GetById(Guid teamId);
        Team GetByName(string name);
        ICollection<Team> GetAll();
    }
}

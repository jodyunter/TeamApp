using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Data;
using TeamApp.Domain;
using System.Linq;

namespace TeamApp.Services
{
    public class TeamService
    {
        TeamAppContext db;
        public List<Team> GetAll()
        {
            return db.Teams.ToList<Team>();
        }
    }
}

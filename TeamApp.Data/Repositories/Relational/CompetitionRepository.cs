﻿using System;
using System.Collections.Generic;
using System.Linq;
using TeamApp.Data.Repositories.Relational;
using TeamApp.Domain;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Repositories;

namespace TeamApp.Data.Relational.Repositories
{
    public class CompetitionRepository : DataRepository<Competition>, ICompetitionRepository
    {
        public CompetitionRepository(IRelationalRepository<Competition> repo) : base(repo) { }

        public Competition GetByNameAndYear(string name, int year)
        {
            return this.Where(c => c.Name.Equals(name) && c.Year == year).FirstOrDefault();
        }

        public IList<Competition> GetByYear(int year)
        {
            return this.Where(c => c.Year == year).ToList();
        }

        public Competition GetCurrentCompetitionForLeagueAndYear(int leagueId, int year)
        {
            return this.Where(c => c.Year == year && c.CompetitionConfig.League.Id == leagueId && !c.IsComplete()).FirstOrDefault();
        }

        public int GetCurrentYearForLeague(League l)
        {
            var competitionList = this.Where(c => c.CompetitionConfig.League == l).ToList();

            return competitionList.Max(c => c.Year);
            
        }
        
    }
}

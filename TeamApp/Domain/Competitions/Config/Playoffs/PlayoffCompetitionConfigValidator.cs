﻿using System.Collections.Generic;
using System.Linq;
using TeamApp.Domain.Competitions.Config.Seasons;

namespace TeamApp.Domain.Competitions.Config.Playoffs
{
    public class PlayoffCompetitionConfigValidator
    {
        public List<string> Messages { get; set; }

        private string messageFormat = "{0}\t{1}\t{2}";

        public PlayoffCompetitionConfigValidator()
        {
            Messages = new List<string>();
        }

        public List<MockRanking> SetupMockRankings(PlayoffCompetitionConfig config, int year)
        {
            //make sure to go through all the winner and loser go to groups
            //make sure to check winner rank comes from.            

            var teams = new List<MockTeam>();

            config.Parents.ToList().ForEach(parentConfig =>
            {
                teams.AddRange(SetupMockTeams(parentConfig));
            });

            return null;

        }

        public List<MockTeam> SetupMockTeams(CompetitionConfig config)
        {
            if (config.GetType() == typeof(PlayoffCompetitionConfig))
                return SetupMockTeams((PlayoffCompetitionConfig)config);
            else if (config.GetType() == typeof(SeasonCompetitionConfig))
                return SetupMockTeams((SeasonCompetitionConfig)config);
            else
                return new List<MockTeam>();
        }
        public List<MockTeam> SetupMockTeams(PlayoffCompetitionConfig config)
        {
            //playoffs can't have team lists that aren't from other competitions

            return new List<MockTeam>();
        }
        public List<MockTeam> SetupMockTeams(SeasonCompetitionConfig config)
        {
            var list = new List<MockTeam>();

            config.TeamRules.ToList().ForEach(t =>
            {
                list.Add(new MockTeam(t.Team.Id, t.Team.Name));
            });

            return list;
        }
        
        public bool Validate(PlayoffCompetitionConfig config, int year)
        {
            bool valid = true;

            return valid;
        }

        public bool ConfigIsActive(PlayoffCompetitionConfig config, int year)
        {
            bool valid = true;

            if (!config.IsActive(year))
            {
                valid = false;

                var type = "PlayoffCompetitionConfig";
                var message = "Competition Configuration is not active for year.";
                var data = string.Format("Id:{0} Name:{1} Year:{2}", config.Id, config.Name, year);
                var result = string.Format(messageFormat, type, message, data);
                Messages.Add(result);
            }
            
            return valid;
        }

        public bool ValidateTeamsAreInGroupLevelOnlyOnce(PlayoffCompetitionConfig config, int year)
        {
            return false;
        }

        public bool DoesRankingExistForValue(string ruleName, List<MockRanking> rankingReps,string group, int value)
        {
            bool valid = false;

            var rank = rankingReps.Where(rankingRep => rankingRep.Rank == value).FirstOrDefault();

            if (rank == null)
            {
                var type = "PlayoffSeriesRule";
                var message = "Series Rule has a bad ranking value.";
                var data = string.Format("Series:{0} Group:{1} Rank:{2}", ruleName, group, value);
                var result = string.Format(messageFormat, type, message, data);
                Messages.Add(result);
            }
            else
            {
                valid = true;
            }

            return valid;
        }

        public bool DoesRankingExistForName(string ruleName, List<MockRanking> rankingReps, string group, int value)
        {
            bool valid = false;

            var rank = rankingReps.Where(rankingRep => rankingRep.GroupName.Equals(group)).FirstOrDefault();

            if (rank == null)
            {
                var type = "PlayoffSeriesRule";
                var message = "Series Rule has a bad ranking group.";
                var data = string.Format("Series:{0} Group:{1} Rank:{2}", ruleName, group, value);
                var result = string.Format(messageFormat, type, message, data);
                Messages.Add(result);
            }
            else
            {
                valid = true;
            }

            return valid;
        }

        public class MockRanking
        {
            public string GroupName { get; set; }
            public int Rank { get; set; }

            public MockRanking(string groupName, int rank)
            {
                GroupName = groupName;
                Rank = rank;
            }
        }

        public class MockTeam
        {
            public long Id { get; set; }
            public string Name { get; set; }

            public MockTeam(long id, string name)
            {
                Id = id;
                Name = name;
            }
        }
    }


}

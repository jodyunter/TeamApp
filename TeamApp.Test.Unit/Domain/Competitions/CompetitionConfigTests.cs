using System;
using System.Collections.Generic;
using System.Text;
using static Xunit.Assert;
using Xunit;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Schedules;
using TeamApp.Domain.Competitions.Config;
using TeamApp.Domain;

namespace TeamApp.Test.Domain.Competitions
{

    public class CompetitionConfigTests
    {
        [Fact]        
        public void ShouldNotStartCompetition()
        {
            MockCompetition p1 = new MockCompetition();
            MockCompetition p2 = new MockCompetition();

            p1.Finished = false;
            p2.Finished = true;

            MockCompetitionConfig config = new MockCompetitionConfig();            

            var message = "";
            
            try
            {
                var comp = config.CreateCompetition(1, 1, new List<Competition>() { p1, p2 });
                Null(comp);
                config.CompetitionStartingDay = 15;
                comp = config.CreateCompetition(1, 1, new List<Competition>() { p1, p2 });
            }
            catch (Exception e)
            {
                message = e.Message;
            }

            Equal("Not all parents are done!", message);

            
        }

        [Fact]
        public void ShouldStartCompetition()
        {
            MockCompetition p1 = new MockCompetition();
            MockCompetition p2 = new MockCompetition();

            p1.Finished = true;
            p2.Finished = true;

            MockCompetitionConfig config = new MockCompetitionConfig();

            var message = "";

            try
            {
                var comp = config.CreateCompetition(1, 1, new List<Competition>() { p1, p2 });
                NotNull(comp);
            }
            catch (Exception e)
            {
                message = e.Message;
            }            


        }

        [Fact]
        public void ShouldCopyCompetitionTeams()
        {
            True(false);
            //this is currently in playoff config, should move it here
        }
        [Fact]
        public void ShouldCopyCompetitionRankings()
        {
            True(false);
            //this is currently in playoff config, should mvoe it here
        }
        [Fact]
        public void ShouldCopyCompetitionRankingsFromMulitpleCompetitions()
        {
            True(false);
            //not sure what to do here but want a red mark until I figure it out.
        }

    }

    public class MockCompetitionConfig : CompetitionConfig
    {
        public override Competition CreateCompetitionDetails(int day, int year, IList<Competition> parents)
        {
            return new MockCompetition();
        }

        public override CompetitionTeam CreateCompetitionTeam(Competition competition, Team parent)
        {
            throw new NotImplementedException();
        }

        public override CompetitionTeam CreateCompetitionTeamDetails(Competition competition, Team parent)
        {
            throw new NotImplementedException();
        }
    }
    public class MockCompetition : Competition
    {
        public bool AreGamesCompleteValue { get; set; }

        public override bool AreGamesComplete()
        {
            return AreGamesCompleteValue;
        }

        public override void ProcessEndOfCompetitionDetails(int endingDay)
        {
            return;
        }

        public override IEnumerable<ScheduleGame> ProcessGame(ScheduleGame game, int currentDay)
        {
            return new List<ScheduleGame>();
        }

        public override List<TeamRanking> GetFinalRankings()
        {
            throw new NotImplementedException();
        }
    }
}

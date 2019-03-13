﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Competitions.Playoffs
{
    public class PlayoffTeam : SingleYearTeam
    {
        public PlayoffTeam() { }

        public PlayoffTeam(Competition competition, Team parent, string name, string nickName, string shortName, int skill, string owner, int? year)
            :base(competition, parent, name, nickName, shortName, skill, owner, year)
        {
        }

        public PlayoffTeam(Competition competition, Team parent, int year)
            :base(competition, parent, parent.Name, parent.NickName, parent.ShortName, parent.Skill, parent.Owner, year)
        {

        }

    }
}

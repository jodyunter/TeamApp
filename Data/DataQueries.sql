select c.Name,
 c.Year,
 case when bs.HomeWins > bs.AwayWins then syth.Name
	  when bs.HomeWins < bs.AwayWins then sytv.Name
	  else syth.Name
	end A,
case when bs.HomeWins > bs.AwayWins then bs.HomeWins
	  when bs.HomeWins < bs.AwayWins then bs.AwayWins
	  else bs.HomeWins
	end AWins,
 case when bs.HomeWins < bs.AwayWins then syth.Name
	  when bs.HomeWins > bs.AwayWins then sytv.Name
	  else sytv.Name
	end B,
case when bs.HomeWins < bs.AwayWins then bs.HomeWins
	  when bs.HomeWins > bs.AwayWins then bs.AwayWins
	  else bs.AwayWins
	end BWins
from BestOfSeries bs
join PlayoffSeries ps on ps.Id = bs.PlayoffSeries_id
join SingleYearTeam syth on syth.Id = ps.Hometeam_id
join SingleYearTeam sytv on sytv.Id = ps.Awayteam_id
join Playoff p on p.Competition_Id = ps.Playoff_id
join Competition c on c.Id = p.Competition_id
where ps.Name = 'Final'
order by Year desc

select tr.Rank, syt.Name, sts.Wins, sts.Loses, sts.Ties, sts.Wins *2 + sts.ties as Pts, sts.Wins + sts.Ties + sts.Loses as GP, sts.GoalsFor, sts.GoalsAgainst, sts.GoalsFor -sts.GoalsAgainst as GD, syt.Skill
from Season s
join SeasonDivision sd on sd.Season_id = s.Competition_Id
join Seasonteam st on st.Division_id = sd.Id
join Competition c on c.Id = s.Competition_id
join SeasonTeamStats sts on sts.id = st.stats_id
join SingleYearteam syt on syt.Id = st.SingleYearTeam_Id
join TeamRanking tr on (tr.SingleYearTeam_id = syt.Id and c.Id = tr.Competition_id and tr.GroupName = sd.Name)
where c.Year = (select max(year) from Competition c join Playoff p on p.Competition_Id = c.Id)
order by Pts desc, GP asc, GD desc, wins desc
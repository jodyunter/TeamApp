select * from PlayoffRankingRule

select * from Competition

select * from Competition

select * from PlayoffSeries

select c.Year, sd.Name, tr.Rank, t.Name, sts.Wins, sts.Loses, sts.Ties, sts.Wins *2 + sts.Ties as Points, sts.Wins + sts.Ties + sts.Loses as Games, sts.GoalsFor, sts.GoalsAgainst, sts.GoalsFor - sts.GoalsAgainst as 'Goal Diff'
from Team t
join SingleYearTeam syt on syt.Parent_id = t.Id
join SeasonTeam st on st.SingleYearTeam_id = syt.Id
join SeasonTeamStats sts on sts.Id = st.Stats_id
join SeasonDivision sd on sd.Id = st.Division_id
join Season s on s.Competition_id = sd.Season_id
join Competition c on c.Id = s.Competition_id
join TeamRanking tr on tr.Team_id = syt.Id
where tr.Rank = 1
order by Rank, Year

select c.Year, ps.Name,
 case when bos.HomeWins = 4 then ht.Name
 else at.Name
 end 'Champion',
 case when bos.HomeWins = 4 then bos.HomeWins
 else bos.AwayWins
 end ' ',
  case when bos.HomeWins = 4 then bos.AwayWins
 else bos.HomeWins
 end ' ',
 case when bos.HomeWins = 4 then at.Name
 else ht.Name
 end 'Runner Up'
from PlayoffSeries ps
join BestOfSeries bos on bos.PlayoffSeries_id = ps.Id
join PlayoffTeam hpt on hpt.SingleYearTeam_id = ps.HomeTeam_id
join SingleYearTeam hsyt on hsyt.Id =  hpt.SingleYearTeam_id
join Team ht on ht.Id = hsyt.Parent_id
join PlayoffTeam apt on apt.SingleYearTeam_id = ps.AwayTeam_id
join SingleYearTeam asyt on asyt.Id = apt.SingleYearTeam_id
join Team at on at.id = asyt.Parent_id
join Playoff p on p.Competition_id = ps.Playoff_id
join Competition c on c.Id = p.Competition_id
where ps.Name = 'Final'

select count(case when bos.HomeWins = 4 then ht.Name else at.Name end) 'Championships', case when bos.HomeWins = 4 then ht.Name else at.Name end 'Team'
from PlayoffSeries ps
join BestOfSeries bos on bos.PlayoffSeries_id = ps.Id
join PlayoffTeam hpt on hpt.SingleYearTeam_id = ps.HomeTeam_id
join SingleYearTeam hsyt on hsyt.Id =  hpt.SingleYearTeam_id
join Team ht on ht.Id = hsyt.Parent_id
join PlayoffTeam apt on apt.SingleYearTeam_id = ps.AwayTeam_id
join SingleYearTeam asyt on asyt.Id = apt.SingleYearTeam_id
join Team at on at.id = asyt.Parent_id
join Playoff p on p.Competition_id = ps.Playoff_id
join Competition c on c.Id = p.Competition_id
where ps.Name = 'Final'
group by case when bos.HomeWins = 4 then ht.Name else at.Name end
order by count(case when bos.HomeWins = 4 then ht.Name else at.Name end) desc


select  asyt.Id, hsyt.Id, c.Year, ps.Name,
 case when bos.HomeWins = 4 then ht.Name
 else at.Name
 end 'Champion',
 case when bos.HomeWins = 4 then bos.HomeWins
 else bos.AwayWins
 end ' ',
  case when bos.HomeWins = 4 then bos.AwayWins
 else bos.HomeWins
 end ' ',
 case when bos.HomeWins = 4 then at.Name
 else ht.Name
 end 'Runner Up'
from PlayoffSeries ps
join BestOfSeries bos on bos.PlayoffSeries_id = ps.Id
join PlayoffTeam hpt on hpt.SingleYearTeam_id = ps.HomeTeam_id
join SingleYearTeam hsyt on hsyt.Id =  hpt.SingleYearTeam_id
join Team ht on ht.Id = hsyt.Parent_id
join PlayoffTeam apt on apt.SingleYearTeam_id = ps.AwayTeam_id
join SingleYearTeam asyt on asyt.Id = apt.SingleYearTeam_id
join Team at on at.id = asyt.Parent_id
join Playoff p on p.Competition_id = ps.Playoff_id
join Competition c on c.Id = p.Competition_id
where c.Year = 51
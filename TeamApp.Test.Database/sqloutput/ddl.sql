
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK820A6365A45DA004]') and parent_object_id = OBJECT_ID(N'[Competition]'))
alter table [Competition]  drop constraint FK820A6365A45DA004


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC380C9DCF69B4DEE]') and parent_object_id = OBJECT_ID(N'Playoff'))
alter table Playoff  drop constraint FKC380C9DCF69B4DEE


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK4A09C2E4F69B4DEE]') and parent_object_id = OBJECT_ID(N'Season'))
alter table Season  drop constraint FK4A09C2E4F69B4DEE


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK35CBF9D5B65AD2BA]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FK35CBF9D5B65AD2BA


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK35CBF9D570448B3A]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FK35CBF9D570448B3A


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK35CBF9D5A45DA004]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FK35CBF9D5A45DA004


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK308A0374A45DA004]') and parent_object_id = OBJECT_ID(N'PlayoffCompetitionConfig'))
alter table PlayoffCompetitionConfig  drop constraint FK308A0374A45DA004


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK89185D3AA45DA004]') and parent_object_id = OBJECT_ID(N'SeasonCompetitionConfig'))
alter table SeasonCompetitionConfig  drop constraint FK89185D3AA45DA004


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK624375E127F49583]') and parent_object_id = OBJECT_ID(N'[PlayoffRankingRule]'))
alter table [PlayoffRankingRule]  drop constraint FK624375E127F49583


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK624375E1C2B85B55]') and parent_object_id = OBJECT_ID(N'[PlayoffRankingRule]'))
alter table [PlayoffRankingRule]  drop constraint FK624375E1C2B85B55


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD78B4D1827F49583]') and parent_object_id = OBJECT_ID(N'[PlayoffSeriesRule]'))
alter table [PlayoffSeriesRule]  drop constraint FKD78B4D1827F49583


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD78B4D1870448B3A]') and parent_object_id = OBJECT_ID(N'[PlayoffSeriesRule]'))
alter table [PlayoffSeriesRule]  drop constraint FKD78B4D1870448B3A


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK7B2F44178810A694]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FK7B2F44178810A694


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK7B2F44171561AC79]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FK7B2F44171561AC79


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK7B2F44171C53D527]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FK7B2F44171C53D527


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFE443BC27B6CE860]') and parent_object_id = OBJECT_ID(N'BestOfSeries'))
alter table BestOfSeries  drop constraint FKFE443BC27B6CE860


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKCF572F1B7B6CE860]') and parent_object_id = OBJECT_ID(N'TotalGoalsSeries'))
alter table TotalGoalsSeries  drop constraint FKCF572F1B7B6CE860


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKF0C61AF59C25C9B6]') and parent_object_id = OBJECT_ID(N'[SeasonDivisionRule]'))
alter table [SeasonDivisionRule]  drop constraint FKF0C61AF59C25C9B6


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKEE101FB49C25C9B6]') and parent_object_id = OBJECT_ID(N'[SeasonScheduleRule]'))
alter table [SeasonScheduleRule]  drop constraint FKEE101FB49C25C9B6


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9119C8F29C25C9B6]') and parent_object_id = OBJECT_ID(N'[SeasonTeamRule]'))
alter table [SeasonTeamRule]  drop constraint FK9119C8F29C25C9B6


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9119C8F21003E64D]') and parent_object_id = OBJECT_ID(N'[SeasonTeamRule]'))
alter table [SeasonTeamRule]  drop constraint FK9119C8F21003E64D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKEF4446D3FA212670]') and parent_object_id = OBJECT_ID(N'[SeasonDivision]'))
alter table [SeasonDivision]  drop constraint FKEF4446D3FA212670


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKEF4446D31D5863BE]') and parent_object_id = OBJECT_ID(N'[SeasonDivision]'))
alter table [SeasonDivision]  drop constraint FKEF4446D31D5863BE


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK3A320C4FD8EBF520]') and parent_object_id = OBJECT_ID(N'[TeamRanking]'))
alter table [TeamRanking]  drop constraint FK3A320C4FD8EBF520


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK3A320C4FF69B4DEE]') and parent_object_id = OBJECT_ID(N'[TeamRanking]'))
alter table [TeamRanking]  drop constraint FK3A320C4FF69B4DEE


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD65C803674807C35]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FKD65C803674807C35


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD65C80367DB2056B]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FKD65C80367DB2056B


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD65C8036BD126705]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FKD65C8036BD126705


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK40E2D6D6958CDDC1]') and parent_object_id = OBJECT_ID(N'ScheduleGame'))
alter table ScheduleGame  drop constraint FK40E2D6D6958CDDC1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK40E2D6D6F69B4DEE]') and parent_object_id = OBJECT_ID(N'ScheduleGame'))
alter table ScheduleGame  drop constraint FK40E2D6D6F69B4DEE


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK398496AEA976C1C5]') and parent_object_id = OBJECT_ID(N'PlayoffGame'))
alter table PlayoffGame  drop constraint FK398496AEA976C1C5


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK398496AE321F5103]') and parent_object_id = OBJECT_ID(N'PlayoffGame'))
alter table PlayoffGame  drop constraint FK398496AE321F5103


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKEC480F2BF69B4DEE]') and parent_object_id = OBJECT_ID(N'[SingleYearTeam]'))
alter table [SingleYearTeam]  drop constraint FKEC480F2BF69B4DEE


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKEC480F2B6EC73573]') and parent_object_id = OBJECT_ID(N'[SingleYearTeam]'))
alter table [SingleYearTeam]  drop constraint FKEC480F2B6EC73573


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFA3E1BFA690BC6FC]') and parent_object_id = OBJECT_ID(N'PlayoffTeam'))
alter table PlayoffTeam  drop constraint FKFA3E1BFA690BC6FC


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK66A0CE3D690BC6FC]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FK66A0CE3D690BC6FC


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK66A0CE3D3BBF1B93]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FK66A0CE3D3BBF1B93


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK66A0CE3D7EC8248A]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FK66A0CE3D7EC8248A


    if exists (select * from dbo.sysobjects where id = object_id(N'[Competition]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [Competition]

    if exists (select * from dbo.sysobjects where id = object_id(N'Playoff') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Playoff

    if exists (select * from dbo.sysobjects where id = object_id(N'Season') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Season

    if exists (select * from dbo.sysobjects where id = object_id(N'[CompetitionConfig]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [CompetitionConfig]

    if exists (select * from dbo.sysobjects where id = object_id(N'PlayoffCompetitionConfig') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table PlayoffCompetitionConfig

    if exists (select * from dbo.sysobjects where id = object_id(N'SeasonCompetitionConfig') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table SeasonCompetitionConfig

    if exists (select * from dbo.sysobjects where id = object_id(N'[PlayoffRankingRule]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [PlayoffRankingRule]

    if exists (select * from dbo.sysobjects where id = object_id(N'[PlayoffSeriesRule]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [PlayoffSeriesRule]

    if exists (select * from dbo.sysobjects where id = object_id(N'[PlayoffSeries]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [PlayoffSeries]

    if exists (select * from dbo.sysobjects where id = object_id(N'BestOfSeries') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table BestOfSeries

    if exists (select * from dbo.sysobjects where id = object_id(N'TotalGoalsSeries') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table TotalGoalsSeries

    if exists (select * from dbo.sysobjects where id = object_id(N'[SeasonDivisionRule]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [SeasonDivisionRule]

    if exists (select * from dbo.sysobjects where id = object_id(N'[SeasonScheduleRule]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [SeasonScheduleRule]

    if exists (select * from dbo.sysobjects where id = object_id(N'[SeasonTeamRule]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [SeasonTeamRule]

    if exists (select * from dbo.sysobjects where id = object_id(N'[SeasonDivision]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [SeasonDivision]

    if exists (select * from dbo.sysobjects where id = object_id(N'[SeasonTeamStats]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [SeasonTeamStats]

    if exists (select * from dbo.sysobjects where id = object_id(N'[TeamRanking]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [TeamRanking]

    if exists (select * from dbo.sysobjects where id = object_id(N'[Game]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [Game]

    if exists (select * from dbo.sysobjects where id = object_id(N'ScheduleGame') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table ScheduleGame

    if exists (select * from dbo.sysobjects where id = object_id(N'PlayoffGame') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table PlayoffGame

    if exists (select * from dbo.sysobjects where id = object_id(N'[GameData]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [GameData]

    if exists (select * from dbo.sysobjects where id = object_id(N'[GameRules]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [GameRules]

    if exists (select * from dbo.sysobjects where id = object_id(N'[League]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [League]

    if exists (select * from dbo.sysobjects where id = object_id(N'[SingleYearTeam]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [SingleYearTeam]

    if exists (select * from dbo.sysobjects where id = object_id(N'PlayoffTeam') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table PlayoffTeam

    if exists (select * from dbo.sysobjects where id = object_id(N'SeasonTeam') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table SeasonTeam

    if exists (select * from dbo.sysobjects where id = object_id(N'[Team]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [Team]

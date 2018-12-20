
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKA2BBD37734B0B4B5]') and parent_object_id = OBJECT_ID(N'[Competition]'))
alter table [Competition]  drop constraint FKA2BBD37734B0B4B5


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKDAE012B03C8C4C31]') and parent_object_id = OBJECT_ID(N'Playoff'))
alter table Playoff  drop constraint FKDAE012B03C8C4C31


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKACC53F413C8C4C31]') and parent_object_id = OBJECT_ID(N'Season'))
alter table Season  drop constraint FKACC53F413C8C4C31


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKB371CF3949A30146]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FKB371CF3949A30146


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKB371CF39FF4795F3]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FKB371CF39FF4795F3


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKB371CF3934B0B4B5]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FKB371CF3934B0B4B5


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK7DE59BC434B0B4B5]') and parent_object_id = OBJECT_ID(N'PlayoffCompetitionConfig'))
alter table PlayoffCompetitionConfig  drop constraint FK7DE59BC434B0B4B5


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK1FD3A45B34B0B4B5]') and parent_object_id = OBJECT_ID(N'SeasonCompetitionConfig'))
alter table SeasonCompetitionConfig  drop constraint FK1FD3A45B34B0B4B5


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9854E25C8A603C4C]') and parent_object_id = OBJECT_ID(N'[PlayoffRankingRule]'))
alter table [PlayoffRankingRule]  drop constraint FK9854E25C8A603C4C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9854E25C3FCD9710]') and parent_object_id = OBJECT_ID(N'[PlayoffRankingRule]'))
alter table [PlayoffRankingRule]  drop constraint FK9854E25C3FCD9710


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK51FF1C6F8A603C4C]') and parent_object_id = OBJECT_ID(N'[PlayoffSeriesRule]'))
alter table [PlayoffSeriesRule]  drop constraint FK51FF1C6F8A603C4C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK51FF1C6FFF4795F3]') and parent_object_id = OBJECT_ID(N'[PlayoffSeriesRule]'))
alter table [PlayoffSeriesRule]  drop constraint FK51FF1C6FFF4795F3


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKF706B673F9BE3474]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FKF706B673F9BE3474


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKF706B6732B1B4818]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FKF706B6732B1B4818


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKF706B6736D9A7241]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FKF706B6736D9A7241


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC5853D29C80CA00]') and parent_object_id = OBJECT_ID(N'BestOfSeries'))
alter table BestOfSeries  drop constraint FKC5853D29C80CA00


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK305D6E489C80CA00]') and parent_object_id = OBJECT_ID(N'TotalGoalsSeries'))
alter table TotalGoalsSeries  drop constraint FK305D6E489C80CA00


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK645228EF7EED830E]') and parent_object_id = OBJECT_ID(N'[SeasonDivisionRule]'))
alter table [SeasonDivisionRule]  drop constraint FK645228EF7EED830E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK19FCCE2C7EED830E]') and parent_object_id = OBJECT_ID(N'[SeasonScheduleRule]'))
alter table [SeasonScheduleRule]  drop constraint FK19FCCE2C7EED830E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK89CB83697EED830E]') and parent_object_id = OBJECT_ID(N'[SeasonTeamRule]'))
alter table [SeasonTeamRule]  drop constraint FK89CB83697EED830E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK89CB8369B72A78B8]') and parent_object_id = OBJECT_ID(N'[SeasonTeamRule]'))
alter table [SeasonTeamRule]  drop constraint FK89CB8369B72A78B8


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKCD13D139FA4A904F]') and parent_object_id = OBJECT_ID(N'[SeasonDivision]'))
alter table [SeasonDivision]  drop constraint FKCD13D139FA4A904F


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKCD13D139753FCB8F]') and parent_object_id = OBJECT_ID(N'[SeasonDivision]'))
alter table [SeasonDivision]  drop constraint FKCD13D139753FCB8F


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK74C96F11C39F4264]') and parent_object_id = OBJECT_ID(N'[TeamRanking]'))
alter table [TeamRanking]  drop constraint FK74C96F11C39F4264


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK74C96F113C8C4C31]') and parent_object_id = OBJECT_ID(N'[TeamRanking]'))
alter table [TeamRanking]  drop constraint FK74C96F113C8C4C31


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK46AB4D9F32D5D4C7]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FK46AB4D9F32D5D4C7


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK46AB4D9F7454EE9E]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FK46AB4D9F7454EE9E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK46AB4D9FCE0159FA]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FK46AB4D9FCE0159FA


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK51A581DB89BF6110]') and parent_object_id = OBJECT_ID(N'ScheduleGame'))
alter table ScheduleGame  drop constraint FK51A581DB89BF6110


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK51A581DB3C8C4C31]') and parent_object_id = OBJECT_ID(N'ScheduleGame'))
alter table ScheduleGame  drop constraint FK51A581DB3C8C4C31


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK3BEF8DE599E406DA]') and parent_object_id = OBJECT_ID(N'PlayoffGame'))
alter table PlayoffGame  drop constraint FK3BEF8DE599E406DA


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK3BEF8DE57AED937]') and parent_object_id = OBJECT_ID(N'PlayoffGame'))
alter table PlayoffGame  drop constraint FK3BEF8DE57AED937


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK64775A3A3C8C4C31]') and parent_object_id = OBJECT_ID(N'[SingleYearTeam]'))
alter table [SingleYearTeam]  drop constraint FK64775A3A3C8C4C31


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK64775A3A25340CD0]') and parent_object_id = OBJECT_ID(N'[SingleYearTeam]'))
alter table [SingleYearTeam]  drop constraint FK64775A3A25340CD0


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKF81CB6657A9639EA]') and parent_object_id = OBJECT_ID(N'PlayoffTeam'))
alter table PlayoffTeam  drop constraint FKF81CB6657A9639EA


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKA7575E877A9639EA]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FKA7575E877A9639EA


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKA7575E873A48A383]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FKA7575E873A48A383


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKA7575E87CECAE56A]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FKA7575E87CECAE56A


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

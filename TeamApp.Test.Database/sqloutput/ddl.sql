
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKA7D4BD3C81AE98C]') and parent_object_id = OBJECT_ID(N'[Competition]'))
alter table [Competition]  drop constraint FKA7D4BD3C81AE98C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKDDED5CBF9B1B35]') and parent_object_id = OBJECT_ID(N'Playoff'))
alter table Playoff  drop constraint FKDDED5CBF9B1B35


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK3DCA09AAF9B1B35]') and parent_object_id = OBJECT_ID(N'Season'))
alter table Season  drop constraint FK3DCA09AAF9B1B35


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC0072656DC8A478B]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FKC0072656DC8A478B


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC007265657E1E9C9]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FKC007265657E1E9C9


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC007265681AE98C]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FKC007265681AE98C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8F924BA081AE98C]') and parent_object_id = OBJECT_ID(N'PlayoffCompetitionConfig'))
alter table PlayoffCompetitionConfig  drop constraint FK8F924BA081AE98C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKCA392E3E81AE98C]') and parent_object_id = OBJECT_ID(N'SeasonCompetitionConfig'))
alter table SeasonCompetitionConfig  drop constraint FKCA392E3E81AE98C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC153464288FEED7C]') and parent_object_id = OBJECT_ID(N'[PlayoffRankingRule]'))
alter table [PlayoffRankingRule]  drop constraint FKC153464288FEED7C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC1534642C1A4E136]') and parent_object_id = OBJECT_ID(N'[PlayoffRankingRule]'))
alter table [PlayoffRankingRule]  drop constraint FKC1534642C1A4E136


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK7BD31D2D88FEED7C]') and parent_object_id = OBJECT_ID(N'[PlayoffSeriesRule]'))
alter table [PlayoffSeriesRule]  drop constraint FK7BD31D2D88FEED7C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK7BD31D2D57E1E9C9]') and parent_object_id = OBJECT_ID(N'[PlayoffSeriesRule]'))
alter table [PlayoffSeriesRule]  drop constraint FK7BD31D2D57E1E9C9


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK4860375A62EB5A6E]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FK4860375A62EB5A6E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK4860375AEA0B3F9]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FK4860375AEA0B3F9


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK4860375A2BE26690]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FK4860375A2BE26690


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK28D600D257291915]') and parent_object_id = OBJECT_ID(N'BestOfSeries'))
alter table BestOfSeries  drop constraint FK28D600D257291915


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC32A62FD57291915]') and parent_object_id = OBJECT_ID(N'TotalGoalsSeries'))
alter table TotalGoalsSeries  drop constraint FKC32A62FD57291915


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK200097DC5EEAA6B4]') and parent_object_id = OBJECT_ID(N'[SeasonDivisionRule]'))
alter table [SeasonDivisionRule]  drop constraint FK200097DC5EEAA6B4


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKDE1A71EA5EEAA6B4]') and parent_object_id = OBJECT_ID(N'[SeasonScheduleRule]'))
alter table [SeasonScheduleRule]  drop constraint FKDE1A71EA5EEAA6B4


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5CB512C85EEAA6B4]') and parent_object_id = OBJECT_ID(N'[SeasonTeamRule]'))
alter table [SeasonTeamRule]  drop constraint FK5CB512C85EEAA6B4


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5CB512C86FD90C05]') and parent_object_id = OBJECT_ID(N'[SeasonTeamRule]'))
alter table [SeasonTeamRule]  drop constraint FK5CB512C86FD90C05


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC21E858F3498F87B]') and parent_object_id = OBJECT_ID(N'[SeasonDivision]'))
alter table [SeasonDivision]  drop constraint FKC21E858F3498F87B


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC21E858F91BD08B4]') and parent_object_id = OBJECT_ID(N'[SeasonDivision]'))
alter table [SeasonDivision]  drop constraint FKC21E858F91BD08B4


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK78F369EF2AE0EF2C]') and parent_object_id = OBJECT_ID(N'[TeamRanking]'))
alter table [TeamRanking]  drop constraint FK78F369EF2AE0EF2C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK78F369EFF9B1B35]') and parent_object_id = OBJECT_ID(N'[TeamRanking]'))
alter table [TeamRanking]  drop constraint FK78F369EFF9B1B35


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK295F0897EF312C16]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FK295F0897EF312C16


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK295F0897CA73F97F]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FK295F0897CA73F97F


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK295F0897CEDDBDC9]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FK295F0897CEDDBDC9


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD6967FA2EB6A565]') and parent_object_id = OBJECT_ID(N'ScheduleGame'))
alter table ScheduleGame  drop constraint FKD6967FA2EB6A565


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD6967FA2F9B1B35]') and parent_object_id = OBJECT_ID(N'ScheduleGame'))
alter table ScheduleGame  drop constraint FKD6967FA2F9B1B35


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC95788A2F35FBE69]') and parent_object_id = OBJECT_ID(N'PlayoffGame'))
alter table PlayoffGame  drop constraint FKC95788A2F35FBE69


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC95788A256EF149F]') and parent_object_id = OBJECT_ID(N'PlayoffGame'))
alter table PlayoffGame  drop constraint FKC95788A256EF149F


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK7EFED25EF9B1B35]') and parent_object_id = OBJECT_ID(N'[SingleYearTeam]'))
alter table [SingleYearTeam]  drop constraint FK7EFED25EF9B1B35


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK7EFED25E5080B784]') and parent_object_id = OBJECT_ID(N'[SingleYearTeam]'))
alter table [SingleYearTeam]  drop constraint FK7EFED25E5080B784


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKEE5DF38862E1550D]') and parent_object_id = OBJECT_ID(N'PlayoffTeam'))
alter table PlayoffTeam  drop constraint FKEE5DF38862E1550D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6126DF5562E1550D]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FK6126DF5562E1550D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6126DF5572F4321F]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FK6126DF5572F4321F


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6126DF55E8F75E8F]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FK6126DF55E8F75E8F


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

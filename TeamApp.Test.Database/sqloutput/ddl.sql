
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD3C7A617A6BFD20F]') and parent_object_id = OBJECT_ID(N'[Competition]'))
alter table [Competition]  drop constraint FKD3C7A617A6BFD20F


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKF178CE934A0D51FC]') and parent_object_id = OBJECT_ID(N'Playoff'))
alter table Playoff  drop constraint FKF178CE934A0D51FC


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFD702DBC4A0D51FC]') and parent_object_id = OBJECT_ID(N'Season'))
alter table Season  drop constraint FKFD702DBC4A0D51FC


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8581FD54156C5D5]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FK8581FD54156C5D5


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8581FD5489539506]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FK8581FD5489539506


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8581FD54A6BFD20F]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FK8581FD54A6BFD20F


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFD14422A6BFD20F]') and parent_object_id = OBJECT_ID(N'PlayoffCompetitionConfig'))
alter table PlayoffCompetitionConfig  drop constraint FKFD14422A6BFD20F


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC617717CA6BFD20F]') and parent_object_id = OBJECT_ID(N'SeasonCompetitionConfig'))
alter table SeasonCompetitionConfig  drop constraint FKC617717CA6BFD20F


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKE8827EE5DF0F324F]') and parent_object_id = OBJECT_ID(N'[PlayoffRankingRule]'))
alter table [PlayoffRankingRule]  drop constraint FKE8827EE5DF0F324F


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKE8827EE538F547DD]') and parent_object_id = OBJECT_ID(N'[PlayoffRankingRule]'))
alter table [PlayoffRankingRule]  drop constraint FKE8827EE538F547DD


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6BA6B3A9DF0F324F]') and parent_object_id = OBJECT_ID(N'[PlayoffSeriesRule]'))
alter table [PlayoffSeriesRule]  drop constraint FK6BA6B3A9DF0F324F


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6BA6B3A989539506]') and parent_object_id = OBJECT_ID(N'[PlayoffSeriesRule]'))
alter table [PlayoffSeriesRule]  drop constraint FK6BA6B3A989539506


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFB989B84A23266FC]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FKFB989B84A23266FC


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFB989B84A48987B3]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FKFB989B84A48987B3


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFB989B842E385651]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FKFB989B842E385651


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK561511AACB4A4A40]') and parent_object_id = OBJECT_ID(N'BestOfSeries'))
alter table BestOfSeries  drop constraint FK561511AACB4A4A40


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK62B2EB2ACB4A4A40]') and parent_object_id = OBJECT_ID(N'TotalGoalsSeries'))
alter table TotalGoalsSeries  drop constraint FK62B2EB2ACB4A4A40


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKB422E294DDD01CD4]') and parent_object_id = OBJECT_ID(N'[SeasonDivisionRule]'))
alter table [SeasonDivisionRule]  drop constraint FKB422E294DDD01CD4


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC9801C48DDD01CD4]') and parent_object_id = OBJECT_ID(N'[SeasonScheduleRule]'))
alter table [SeasonScheduleRule]  drop constraint FKC9801C48DDD01CD4


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKE7058C3EDDD01CD4]') and parent_object_id = OBJECT_ID(N'[SeasonTeamRule]'))
alter table [SeasonTeamRule]  drop constraint FKE7058C3EDDD01CD4


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKE7058C3E92C8CD8A]') and parent_object_id = OBJECT_ID(N'[SeasonTeamRule]'))
alter table [SeasonTeamRule]  drop constraint FKE7058C3E92C8CD8A


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFD3859B970C1DADA]') and parent_object_id = OBJECT_ID(N'[SeasonDivision]'))
alter table [SeasonDivision]  drop constraint FKFD3859B970C1DADA


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFD3859B9E778F9B5]') and parent_object_id = OBJECT_ID(N'[SeasonDivision]'))
alter table [SeasonDivision]  drop constraint FKFD3859B9E778F9B5


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFD0A7E0C41674AA8]') and parent_object_id = OBJECT_ID(N'[TeamRanking]'))
alter table [TeamRanking]  drop constraint FKFD0A7E0C41674AA8


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFD0A7E0C4A0D51FC]') and parent_object_id = OBJECT_ID(N'[TeamRanking]'))
alter table [TeamRanking]  drop constraint FKFD0A7E0C4A0D51FC


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK1600CA9F735AB1B2]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FK1600CA9F735AB1B2


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK1600CA9FF9EB6050]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FK1600CA9FF9EB6050


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK1600CA9FF51AD65D]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FK1600CA9FF51AD65D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8DFE070EC63E767]') and parent_object_id = OBJECT_ID(N'ScheduleGame'))
alter table ScheduleGame  drop constraint FK8DFE070EC63E767


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8DFE0704A0D51FC]') and parent_object_id = OBJECT_ID(N'ScheduleGame'))
alter table ScheduleGame  drop constraint FK8DFE0704A0D51FC


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKA3B1FE57981A2DE0]') and parent_object_id = OBJECT_ID(N'PlayoffGame'))
alter table PlayoffGame  drop constraint FKA3B1FE57981A2DE0


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKA3B1FE57E6A846E]') and parent_object_id = OBJECT_ID(N'PlayoffGame'))
alter table PlayoffGame  drop constraint FKA3B1FE57E6A846E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6024FA894A0D51FC]') and parent_object_id = OBJECT_ID(N'[SingleYearTeam]'))
alter table [SingleYearTeam]  drop constraint FK6024FA894A0D51FC


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6024FA8919E6E14E]') and parent_object_id = OBJECT_ID(N'[SingleYearTeam]'))
alter table [SingleYearTeam]  drop constraint FK6024FA8919E6E14E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK3C1471BB7AFF7FD]') and parent_object_id = OBJECT_ID(N'PlayoffTeam'))
alter table PlayoffTeam  drop constraint FK3C1471BB7AFF7FD


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK44BE90E87AFF7FD]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FK44BE90E87AFF7FD


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK44BE90E8BFD0B798]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FK44BE90E8BFD0B798


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK44BE90E81A71DFED]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FK44BE90E81A71DFED


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


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK34A98DAB94F4DF53]') and parent_object_id = OBJECT_ID(N'[Competition]'))
alter table [Competition]  drop constraint FK34A98DAB94F4DF53


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK148C766EF5AC9AF7]') and parent_object_id = OBJECT_ID(N'Playoff'))
alter table Playoff  drop constraint FK148C766EF5AC9AF7


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKDD84B8B9F5AC9AF7]') and parent_object_id = OBJECT_ID(N'Season'))
alter table Season  drop constraint FKDD84B8B9F5AC9AF7


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK42F1332F1B8B46CE]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FK42F1332F1B8B46CE


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK42F1332F64C957ED]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FK42F1332F64C957ED


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK42F1332F94F4DF53]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FK42F1332F94F4DF53


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK7677B4AD94F4DF53]') and parent_object_id = OBJECT_ID(N'PlayoffCompetitionConfig'))
alter table PlayoffCompetitionConfig  drop constraint FK7677B4AD94F4DF53


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK4394BB6794F4DF53]') and parent_object_id = OBJECT_ID(N'SeasonCompetitionConfig'))
alter table SeasonCompetitionConfig  drop constraint FK4394BB6794F4DF53


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK7E6C16776AC78257]') and parent_object_id = OBJECT_ID(N'[PlayoffRankingRule]'))
alter table [PlayoffRankingRule]  drop constraint FK7E6C16776AC78257


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK7E6C1677D6CF4406]') and parent_object_id = OBJECT_ID(N'[PlayoffRankingRule]'))
alter table [PlayoffRankingRule]  drop constraint FK7E6C1677D6CF4406


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKF9E578B96AC78257]') and parent_object_id = OBJECT_ID(N'[PlayoffSeriesRule]'))
alter table [PlayoffSeriesRule]  drop constraint FKF9E578B96AC78257


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKF9E578B964C957ED]') and parent_object_id = OBJECT_ID(N'[PlayoffSeriesRule]'))
alter table [PlayoffSeriesRule]  drop constraint FKF9E578B964C957ED


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5CD41F278783AE81]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FK5CD41F278783AE81


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5CD41F274F4BF29E]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FK5CD41F274F4BF29E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5CD41F2796C2972C]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FK5CD41F2796C2972C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD019A99B13F46BD9]') and parent_object_id = OBJECT_ID(N'BestOfSeries'))
alter table BestOfSeries  drop constraint FKD019A99B13F46BD9


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK186E6EF113F46BD9]') and parent_object_id = OBJECT_ID(N'TotalGoalsSeries'))
alter table TotalGoalsSeries  drop constraint FK186E6EF113F46BD9


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK3E90D28775AA50FE]') and parent_object_id = OBJECT_ID(N'[SeasonDivisionRule]'))
alter table [SeasonDivisionRule]  drop constraint FK3E90D28775AA50FE


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK660D6E275AA50FE]') and parent_object_id = OBJECT_ID(N'[SeasonScheduleRule]'))
alter table [SeasonScheduleRule]  drop constraint FK660D6E275AA50FE


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKF0F1EC775AA50FE]') and parent_object_id = OBJECT_ID(N'[SeasonTeamRule]'))
alter table [SeasonTeamRule]  drop constraint FKF0F1EC775AA50FE


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKF0F1EC7E8ECBB20]') and parent_object_id = OBJECT_ID(N'[SeasonTeamRule]'))
alter table [SeasonTeamRule]  drop constraint FKF0F1EC7E8ECBB20


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD94D535C828CB45]') and parent_object_id = OBJECT_ID(N'[SeasonDivision]'))
alter table [SeasonDivision]  drop constraint FKD94D535C828CB45


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD94D535753FB9CF]') and parent_object_id = OBJECT_ID(N'[SeasonDivision]'))
alter table [SeasonDivision]  drop constraint FKD94D535753FB9CF


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKDDD5D2623E4DA431]') and parent_object_id = OBJECT_ID(N'[TeamRanking]'))
alter table [TeamRanking]  drop constraint FKDDD5D2623E4DA431


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKDDD5D262F5AC9AF7]') and parent_object_id = OBJECT_ID(N'[TeamRanking]'))
alter table [TeamRanking]  drop constraint FKDDD5D262F5AC9AF7


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK40835D4AE2263B35]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FK40835D4AE2263B35


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK40835D4A3BAF5E87]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FK40835D4A3BAF5E87


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK40835D4AB4B42124]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FK40835D4AB4B42124


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK765D40AF6C436BE2]') and parent_object_id = OBJECT_ID(N'ScheduleGame'))
alter table ScheduleGame  drop constraint FK765D40AF6C436BE2


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK765D40AFF5AC9AF7]') and parent_object_id = OBJECT_ID(N'ScheduleGame'))
alter table ScheduleGame  drop constraint FK765D40AFF5AC9AF7


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKE94A6EA2BC5734C]') and parent_object_id = OBJECT_ID(N'PlayoffGame'))
alter table PlayoffGame  drop constraint FKE94A6EA2BC5734C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKE94A6EA2F81D435E]') and parent_object_id = OBJECT_ID(N'PlayoffGame'))
alter table PlayoffGame  drop constraint FKE94A6EA2F81D435E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKAF3DB057F5AC9AF7]') and parent_object_id = OBJECT_ID(N'[SingleYearTeam]'))
alter table [SingleYearTeam]  drop constraint FKAF3DB057F5AC9AF7


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKAF3DB057D0E712D8]') and parent_object_id = OBJECT_ID(N'[SingleYearTeam]'))
alter table [SingleYearTeam]  drop constraint FKAF3DB057D0E712D8


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKB0D90EC0E0340C44]') and parent_object_id = OBJECT_ID(N'PlayoffTeam'))
alter table PlayoffTeam  drop constraint FKB0D90EC0E0340C44


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFAE906CE0340C44]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FKFAE906CE0340C44


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFAE906CF37759C8]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FKFAE906CF37759C8


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFAE906C33195E72]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FKFAE906C33195E72


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

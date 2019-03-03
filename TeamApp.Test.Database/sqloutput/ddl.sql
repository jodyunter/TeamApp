
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5BEC6A62CC134208]') and parent_object_id = OBJECT_ID(N'[Competition]'))
alter table [Competition]  drop constraint FK5BEC6A62CC134208


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK3CA4E94891B4BC43]') and parent_object_id = OBJECT_ID(N'Playoff'))
alter table Playoff  drop constraint FK3CA4E94891B4BC43


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK2977D34591B4BC43]') and parent_object_id = OBJECT_ID(N'Season'))
alter table Season  drop constraint FK2977D34591B4BC43


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK284D61B14208E008]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FK284D61B14208E008


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK284D61B1E8B89087]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FK284D61B1E8B89087


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK284D61B1CC134208]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FK284D61B1CC134208


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK217515C5CC134208]') and parent_object_id = OBJECT_ID(N'PlayoffCompetitionConfig'))
alter table PlayoffCompetitionConfig  drop constraint FK217515C5CC134208


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK985EBF2ECC134208]') and parent_object_id = OBJECT_ID(N'SeasonCompetitionConfig'))
alter table SeasonCompetitionConfig  drop constraint FK985EBF2ECC134208


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKAB2B6496805C471F]') and parent_object_id = OBJECT_ID(N'[PlayoffRankingRule]'))
alter table [PlayoffRankingRule]  drop constraint FKAB2B6496805C471F


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK3559C71C805C471F]') and parent_object_id = OBJECT_ID(N'[PlayoffSeriesRule]'))
alter table [PlayoffSeriesRule]  drop constraint FK3559C71C805C471F


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK3559C71CE8B89087]') and parent_object_id = OBJECT_ID(N'[PlayoffSeriesRule]'))
alter table [PlayoffSeriesRule]  drop constraint FK3559C71CE8B89087


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5AFE707AA095081]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FK5AFE707AA095081


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5AFE70741B59D8A]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FK5AFE70741B59D8A


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5AFE707F8979DE]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FK5AFE707F8979DE


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK2D20A8525B99A23F]') and parent_object_id = OBJECT_ID(N'BestOfSeries'))
alter table BestOfSeries  drop constraint FK2D20A8525B99A23F


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK38E84F685B99A23F]') and parent_object_id = OBJECT_ID(N'TotalGoalsSeries'))
alter table TotalGoalsSeries  drop constraint FK38E84F685B99A23F


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9B860183C2CDA54F]') and parent_object_id = OBJECT_ID(N'[SeasonDivisionRule]'))
alter table [SeasonDivisionRule]  drop constraint FK9B860183C2CDA54F


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC6C7FBA5C2CDA54F]') and parent_object_id = OBJECT_ID(N'[SeasonScheduleRule]'))
alter table [SeasonScheduleRule]  drop constraint FKC6C7FBA5C2CDA54F


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC39908E9C2CDA54F]') and parent_object_id = OBJECT_ID(N'[SeasonTeamRule]'))
alter table [SeasonTeamRule]  drop constraint FKC39908E9C2CDA54F


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC39908E93A33CA7C]') and parent_object_id = OBJECT_ID(N'[SeasonTeamRule]'))
alter table [SeasonTeamRule]  drop constraint FKC39908E93A33CA7C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK2D1F9DFC2689CE92]') and parent_object_id = OBJECT_ID(N'[SeasonDivision]'))
alter table [SeasonDivision]  drop constraint FK2D1F9DFC2689CE92


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK2D1F9DFCA2CE7F98]') and parent_object_id = OBJECT_ID(N'[SeasonDivision]'))
alter table [SeasonDivision]  drop constraint FK2D1F9DFCA2CE7F98


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKAA7B1B2321831A2D]') and parent_object_id = OBJECT_ID(N'[TeamRanking]'))
alter table [TeamRanking]  drop constraint FKAA7B1B2321831A2D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKAA7B1B2391B4BC43]') and parent_object_id = OBJECT_ID(N'[TeamRanking]'))
alter table [TeamRanking]  drop constraint FKAA7B1B2391B4BC43


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKE7711DF677732DF6]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FKE7711DF677732DF6


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKE7711DF6394FC9A2]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FKE7711DF6394FC9A2


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKE7711DF662F57865]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FKE7711DF662F57865


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD36A9C645343309C]') and parent_object_id = OBJECT_ID(N'ScheduleGame'))
alter table ScheduleGame  drop constraint FKD36A9C645343309C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD36A9C6491B4BC43]') and parent_object_id = OBJECT_ID(N'ScheduleGame'))
alter table ScheduleGame  drop constraint FKD36A9C6491B4BC43


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC38C1E9E59D93D35]') and parent_object_id = OBJECT_ID(N'PlayoffGame'))
alter table PlayoffGame  drop constraint FKC38C1E9E59D93D35


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC38C1E9E85F432E9]') and parent_object_id = OBJECT_ID(N'PlayoffGame'))
alter table PlayoffGame  drop constraint FKC38C1E9E85F432E9


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5BEA16EE91B4BC43]') and parent_object_id = OBJECT_ID(N'[SingleYearTeam]'))
alter table [SingleYearTeam]  drop constraint FK5BEA16EE91B4BC43


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5BEA16EEB9BDDB18]') and parent_object_id = OBJECT_ID(N'[SingleYearTeam]'))
alter table [SingleYearTeam]  drop constraint FK5BEA16EEB9BDDB18


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKB59CB7DBD8A3890D]') and parent_object_id = OBJECT_ID(N'PlayoffTeam'))
alter table PlayoffTeam  drop constraint FKB59CB7DBD8A3890D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK29FEB898D8A3890D]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FK29FEB898D8A3890D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK29FEB898C6795B5C]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FK29FEB898C6795B5C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK29FEB8984E743780]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FK29FEB8984E743780


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

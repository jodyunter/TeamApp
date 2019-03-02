
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKE3D3F10F8C49AF0]') and parent_object_id = OBJECT_ID(N'[Competition]'))
alter table [Competition]  drop constraint FKE3D3F10F8C49AF0


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKCF874EA01D37B5ED]') and parent_object_id = OBJECT_ID(N'Playoff'))
alter table Playoff  drop constraint FKCF874EA01D37B5ED


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKDF56F65A1D37B5ED]') and parent_object_id = OBJECT_ID(N'Season'))
alter table Season  drop constraint FKDF56F65A1D37B5ED


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKCBF85E455CE3D87A]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FKCBF85E455CE3D87A


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKCBF85E45FAFA5D61]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FKCBF85E45FAFA5D61


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKCBF85E45F8C49AF0]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FKCBF85E45F8C49AF0


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9548DA10F8C49AF0]') and parent_object_id = OBJECT_ID(N'PlayoffCompetitionConfig'))
alter table PlayoffCompetitionConfig  drop constraint FK9548DA10F8C49AF0


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKA787BAFF8C49AF0]') and parent_object_id = OBJECT_ID(N'SeasonCompetitionConfig'))
alter table SeasonCompetitionConfig  drop constraint FKA787BAFF8C49AF0


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKF11EF1BD1D164A67]') and parent_object_id = OBJECT_ID(N'[PlayoffRankingRule]'))
alter table [PlayoffRankingRule]  drop constraint FKF11EF1BD1D164A67


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK46A453E11D164A67]') and parent_object_id = OBJECT_ID(N'[PlayoffSeriesRule]'))
alter table [PlayoffSeriesRule]  drop constraint FK46A453E11D164A67


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK46A453E1FAFA5D61]') and parent_object_id = OBJECT_ID(N'[PlayoffSeriesRule]'))
alter table [PlayoffSeriesRule]  drop constraint FK46A453E1FAFA5D61


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKE285BE6F8A96D356]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FKE285BE6F8A96D356


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKE285BE6FA556E2FD]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FKE285BE6FA556E2FD


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKE285BE6FE01D8E3E]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FKE285BE6FE01D8E3E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK33F0AE1A075DD00]') and parent_object_id = OBJECT_ID(N'BestOfSeries'))
alter table BestOfSeries  drop constraint FK33F0AE1A075DD00


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8336BC46A075DD00]') and parent_object_id = OBJECT_ID(N'TotalGoalsSeries'))
alter table TotalGoalsSeries  drop constraint FK8336BC46A075DD00


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK231358FD54D314C]') and parent_object_id = OBJECT_ID(N'[SeasonDivisionRule]'))
alter table [SeasonDivisionRule]  drop constraint FK231358FD54D314C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8035834354D314C]') and parent_object_id = OBJECT_ID(N'[SeasonScheduleRule]'))
alter table [SeasonScheduleRule]  drop constraint FK8035834354D314C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK75B7F5C654D314C]') and parent_object_id = OBJECT_ID(N'[SeasonTeamRule]'))
alter table [SeasonTeamRule]  drop constraint FK75B7F5C654D314C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK75B7F5C6582265AF]') and parent_object_id = OBJECT_ID(N'[SeasonTeamRule]'))
alter table [SeasonTeamRule]  drop constraint FK75B7F5C6582265AF


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK58B2E240140479F2]') and parent_object_id = OBJECT_ID(N'[SeasonDivision]'))
alter table [SeasonDivision]  drop constraint FK58B2E240140479F2


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK58B2E240B040D986]') and parent_object_id = OBJECT_ID(N'[SeasonDivision]'))
alter table [SeasonDivision]  drop constraint FK58B2E240B040D986


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKB8138CA9AEA8A117]') and parent_object_id = OBJECT_ID(N'[TeamRanking]'))
alter table [TeamRanking]  drop constraint FKB8138CA9AEA8A117


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKB8138CA91D37B5ED]') and parent_object_id = OBJECT_ID(N'[TeamRanking]'))
alter table [TeamRanking]  drop constraint FKB8138CA91D37B5ED


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK7E72311A7D00CE4A]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FK7E72311A7D00CE4A


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK7E72311A384BA289]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FK7E72311A384BA289


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK7E72311A7EAE5A94]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FK7E72311A7EAE5A94


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKAC60361098261D]') and parent_object_id = OBJECT_ID(N'ScheduleGame'))
alter table ScheduleGame  drop constraint FKAC60361098261D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKAC60361D37B5ED]') and parent_object_id = OBJECT_ID(N'ScheduleGame'))
alter table ScheduleGame  drop constraint FKAC60361D37B5ED


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKBD10AA5BE37BEC8A]') and parent_object_id = OBJECT_ID(N'PlayoffGame'))
alter table PlayoffGame  drop constraint FKBD10AA5BE37BEC8A


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKBD10AA5BCACF7FA4]') and parent_object_id = OBJECT_ID(N'PlayoffGame'))
alter table PlayoffGame  drop constraint FKBD10AA5BCACF7FA4


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK42D834F11D37B5ED]') and parent_object_id = OBJECT_ID(N'[SingleYearTeam]'))
alter table [SingleYearTeam]  drop constraint FK42D834F11D37B5ED


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK42D834F1BBCF8ED0]') and parent_object_id = OBJECT_ID(N'[SingleYearTeam]'))
alter table [SingleYearTeam]  drop constraint FK42D834F1BBCF8ED0


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK246987269E9AFFE6]') and parent_object_id = OBJECT_ID(N'PlayoffTeam'))
alter table PlayoffTeam  drop constraint FK246987269E9AFFE6


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKF2E587859E9AFFE6]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FKF2E587859E9AFFE6


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKF2E58785D27CE1D8]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FKF2E58785D27CE1D8


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKF2E58785D62CC059]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FKF2E58785D62CC059


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

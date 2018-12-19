
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6E8060A169B5166A]') and parent_object_id = OBJECT_ID(N'[Competition]'))
alter table [Competition]  drop constraint FK6E8060A169B5166A


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK7CA62AC844E7AF31]') and parent_object_id = OBJECT_ID(N'Playoff'))
alter table Playoff  drop constraint FK7CA62AC844E7AF31


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK169600FB44E7AF31]') and parent_object_id = OBJECT_ID(N'Season'))
alter table Season  drop constraint FK169600FB44E7AF31


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD19D34C4FEC7E673]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FKD19D34C4FEC7E673


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD19D34C442F4627C]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FKD19D34C442F4627C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD19D34C469B5166A]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FKD19D34C469B5166A


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK91379ADC69B5166A]') and parent_object_id = OBJECT_ID(N'PlayoffCompetitionConfig'))
alter table PlayoffCompetitionConfig  drop constraint FK91379ADC69B5166A


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9484280869B5166A]') and parent_object_id = OBJECT_ID(N'SeasonCompetitionConfig'))
alter table SeasonCompetitionConfig  drop constraint FK9484280869B5166A


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK3C36A07B7BA2E443]') and parent_object_id = OBJECT_ID(N'[PlayoffRankingRule]'))
alter table [PlayoffRankingRule]  drop constraint FK3C36A07B7BA2E443


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK3C36A07BB1B3C54C]') and parent_object_id = OBJECT_ID(N'[PlayoffRankingRule]'))
alter table [PlayoffRankingRule]  drop constraint FK3C36A07BB1B3C54C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK904E71937BA2E443]') and parent_object_id = OBJECT_ID(N'[PlayoffSeriesRule]'))
alter table [PlayoffSeriesRule]  drop constraint FK904E71937BA2E443


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK904E719342F4627C]') and parent_object_id = OBJECT_ID(N'[PlayoffSeriesRule]'))
alter table [PlayoffSeriesRule]  drop constraint FK904E719342F4627C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK7CFCB64584ADC3BB]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FK7CFCB64584ADC3BB


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK7CFCB6452AD54A25]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FK7CFCB6452AD54A25


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK7CFCB645EA3537C6]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FK7CFCB645EA3537C6


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKA61D9F4032CB8427]') and parent_object_id = OBJECT_ID(N'BestOfSeries'))
alter table BestOfSeries  drop constraint FKA61D9F4032CB8427


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9E2C61AF32CB8427]') and parent_object_id = OBJECT_ID(N'TotalGoalsSeries'))
alter table TotalGoalsSeries  drop constraint FK9E2C61AF32CB8427


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK84DE961BC35744BB]') and parent_object_id = OBJECT_ID(N'[SeasonDivisionRule]'))
alter table [SeasonDivisionRule]  drop constraint FK84DE961BC35744BB


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK2A31BFF0C35744BB]') and parent_object_id = OBJECT_ID(N'[SeasonScheduleRule]'))
alter table [SeasonScheduleRule]  drop constraint FK2A31BFF0C35744BB


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK4F558FF5C35744BB]') and parent_object_id = OBJECT_ID(N'[SeasonTeamRule]'))
alter table [SeasonTeamRule]  drop constraint FK4F558FF5C35744BB


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK4F558FF530EB101F]') and parent_object_id = OBJECT_ID(N'[SeasonTeamRule]'))
alter table [SeasonTeamRule]  drop constraint FK4F558FF530EB101F


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC32D8BEBDCE239D5]') and parent_object_id = OBJECT_ID(N'[SeasonDivision]'))
alter table [SeasonDivision]  drop constraint FKC32D8BEBDCE239D5


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC32D8BEB972819E4]') and parent_object_id = OBJECT_ID(N'[SeasonDivision]'))
alter table [SeasonDivision]  drop constraint FKC32D8BEB972819E4


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK91FC6B9FC49721FE]') and parent_object_id = OBJECT_ID(N'[TeamRanking]'))
alter table [TeamRanking]  drop constraint FK91FC6B9FC49721FE


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK91FC6B9F44E7AF31]') and parent_object_id = OBJECT_ID(N'[TeamRanking]'))
alter table [TeamRanking]  drop constraint FK91FC6B9F44E7AF31


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKACD647689AA48E1E]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FKACD647689AA48E1E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKACD647685A44F3FD]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FKACD647685A44F3FD


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKACD64768F44914A1]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FKACD64768F44914A1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK544478A3D8099EF4]') and parent_object_id = OBJECT_ID(N'ScheduleGame'))
alter table ScheduleGame  drop constraint FK544478A3D8099EF4


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK544478A344E7AF31]') and parent_object_id = OBJECT_ID(N'ScheduleGame'))
alter table ScheduleGame  drop constraint FK544478A344E7AF31


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK2CA0143E5D568895]') and parent_object_id = OBJECT_ID(N'PlayoffGame'))
alter table PlayoffGame  drop constraint FK2CA0143E5D568895


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK2CA0143E93E74C6D]') and parent_object_id = OBJECT_ID(N'PlayoffGame'))
alter table PlayoffGame  drop constraint FK2CA0143E93E74C6D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKB95EA37744E7AF31]') and parent_object_id = OBJECT_ID(N'[SingleYearTeam]'))
alter table [SingleYearTeam]  drop constraint FKB95EA37744E7AF31


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKB95EA377F163AEB7]') and parent_object_id = OBJECT_ID(N'[SingleYearTeam]'))
alter table [SingleYearTeam]  drop constraint FKB95EA377F163AEB7


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK45668B6CE81CCF70]') and parent_object_id = OBJECT_ID(N'PlayoffTeam'))
alter table PlayoffTeam  drop constraint FK45668B6CE81CCF70


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK7B8827A2E81CCF70]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FK7B8827A2E81CCF70


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK7B8827A259B769E0]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FK7B8827A259B769E0


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK7B8827A2974AA01C]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FK7B8827A2974AA01C


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


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKAA50249F7849C2C]') and parent_object_id = OBJECT_ID(N'[Competition]'))
alter table [Competition]  drop constraint FKAA50249F7849C2C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK674EBC1B21B40AAD]') and parent_object_id = OBJECT_ID(N'Playoff'))
alter table Playoff  drop constraint FK674EBC1B21B40AAD


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKA1FF5AC921B40AAD]') and parent_object_id = OBJECT_ID(N'Season'))
alter table Season  drop constraint FKA1FF5AC921B40AAD


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9AF7E707C6818C8A]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FK9AF7E707C6818C8A


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9AF7E707BB59EAA7]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FK9AF7E707BB59EAA7


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9AF7E7077849C2C]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FK9AF7E7077849C2C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK154435C57849C2C]') and parent_object_id = OBJECT_ID(N'PlayoffCompetitionConfig'))
alter table PlayoffCompetitionConfig  drop constraint FK154435C57849C2C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKE0D371A87849C2C]') and parent_object_id = OBJECT_ID(N'SeasonCompetitionConfig'))
alter table SeasonCompetitionConfig  drop constraint FKE0D371A87849C2C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6A6B68B143E9BD46]') and parent_object_id = OBJECT_ID(N'[PlayoffRankingRule]'))
alter table [PlayoffRankingRule]  drop constraint FK6A6B68B143E9BD46


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6A6B68B15E0C7B44]') and parent_object_id = OBJECT_ID(N'[PlayoffRankingRule]'))
alter table [PlayoffRankingRule]  drop constraint FK6A6B68B15E0C7B44


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKB53AA2043E9BD46]') and parent_object_id = OBJECT_ID(N'[PlayoffSeriesRule]'))
alter table [PlayoffSeriesRule]  drop constraint FKB53AA2043E9BD46


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKB53AA20BB59EAA7]') and parent_object_id = OBJECT_ID(N'[PlayoffSeriesRule]'))
alter table [PlayoffSeriesRule]  drop constraint FKB53AA20BB59EAA7


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK1F0CCC78719E476C]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FK1F0CCC78719E476C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK1F0CCC78DB943030]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FK1F0CCC78DB943030


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK1F0CCC78A06432C1]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FK1F0CCC78A06432C1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKBBAA19603412C2C1]') and parent_object_id = OBJECT_ID(N'BestOfSeries'))
alter table BestOfSeries  drop constraint FKBBAA19603412C2C1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKDDAA8FE33412C2C1]') and parent_object_id = OBJECT_ID(N'TotalGoalsSeries'))
alter table TotalGoalsSeries  drop constraint FKDDAA8FE33412C2C1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK121BA16D6349DAEA]') and parent_object_id = OBJECT_ID(N'[SeasonDivisionRule]'))
alter table [SeasonDivisionRule]  drop constraint FK121BA16D6349DAEA


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKACAF0EC86349DAEA]') and parent_object_id = OBJECT_ID(N'[SeasonScheduleRule]'))
alter table [SeasonScheduleRule]  drop constraint FKACAF0EC86349DAEA


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKA978AD3D6349DAEA]') and parent_object_id = OBJECT_ID(N'[SeasonTeamRule]'))
alter table [SeasonTeamRule]  drop constraint FKA978AD3D6349DAEA


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKA978AD3DFC7CD1B0]') and parent_object_id = OBJECT_ID(N'[SeasonTeamRule]'))
alter table [SeasonTeamRule]  drop constraint FKA978AD3DFC7CD1B0


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKE2D03D2AE949E3A6]') and parent_object_id = OBJECT_ID(N'[SeasonDivision]'))
alter table [SeasonDivision]  drop constraint FKE2D03D2AE949E3A6


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKE2D03D2A34FB2A32]') and parent_object_id = OBJECT_ID(N'[SeasonDivision]'))
alter table [SeasonDivision]  drop constraint FKE2D03D2A34FB2A32


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK64CD56F3956BB8C9]') and parent_object_id = OBJECT_ID(N'[TeamRanking]'))
alter table [TeamRanking]  drop constraint FK64CD56F3956BB8C9


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK64CD56F321B40AAD]') and parent_object_id = OBJECT_ID(N'[TeamRanking]'))
alter table [TeamRanking]  drop constraint FK64CD56F321B40AAD


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK36C8C3785AB90AA8]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FK36C8C3785AB90AA8


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK36C8C37821490859]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FK36C8C37821490859


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK36C8C37873A29D31]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FK36C8C37873A29D31


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK4FF099CB7846CC8]') and parent_object_id = OBJECT_ID(N'ScheduleGame'))
alter table ScheduleGame  drop constraint FK4FF099CB7846CC8


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK4FF099CB21B40AAD]') and parent_object_id = OBJECT_ID(N'ScheduleGame'))
alter table ScheduleGame  drop constraint FK4FF099CB21B40AAD


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK2D3398287AB91588]') and parent_object_id = OBJECT_ID(N'PlayoffGame'))
alter table PlayoffGame  drop constraint FK2D3398287AB91588


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK2D339828DC114D77]') and parent_object_id = OBJECT_ID(N'PlayoffGame'))
alter table PlayoffGame  drop constraint FK2D339828DC114D77


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD74003BA21B40AAD]') and parent_object_id = OBJECT_ID(N'[SingleYearTeam]'))
alter table [SingleYearTeam]  drop constraint FKD74003BA21B40AAD


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD74003BA8DD96688]') and parent_object_id = OBJECT_ID(N'[SingleYearTeam]'))
alter table [SingleYearTeam]  drop constraint FKD74003BA8DD96688


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK28D49C766FAF95A2]') and parent_object_id = OBJECT_ID(N'PlayoffTeam'))
alter table PlayoffTeam  drop constraint FK28D49C766FAF95A2


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKCC3402D6FAF95A2]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FKCC3402D6FAF95A2


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKCC3402D11C0495E]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FKCC3402D11C0495E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKCC3402D2AA7AF93]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FKCC3402D2AA7AF93


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

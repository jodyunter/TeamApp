
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK2BD176B97EB6978F]') and parent_object_id = OBJECT_ID(N'[Competition]'))
alter table [Competition]  drop constraint FK2BD176B97EB6978F


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFCFE887BEA9339FF]') and parent_object_id = OBJECT_ID(N'Playoff'))
alter table Playoff  drop constraint FKFCFE887BEA9339FF


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK87C2EDF3EA9339FF]') and parent_object_id = OBJECT_ID(N'Season'))
alter table Season  drop constraint FK87C2EDF3EA9339FF


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC22CAF64AF86D035]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FKC22CAF64AF86D035


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC22CAF64203CC9B4]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FKC22CAF64203CC9B4


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC22CAF647EB6978F]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FKC22CAF647EB6978F


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKBBD3DDDA7EB6978F]') and parent_object_id = OBJECT_ID(N'PlayoffCompetitionConfig'))
alter table PlayoffCompetitionConfig  drop constraint FKBBD3DDDA7EB6978F


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6B8B838C7EB6978F]') and parent_object_id = OBJECT_ID(N'SeasonCompetitionConfig'))
alter table SeasonCompetitionConfig  drop constraint FK6B8B838C7EB6978F


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKA919BCDD50A42025]') and parent_object_id = OBJECT_ID(N'[PlayoffRankingRule]'))
alter table [PlayoffRankingRule]  drop constraint FKA919BCDD50A42025


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKA919BCDD54C5FC04]') and parent_object_id = OBJECT_ID(N'[PlayoffRankingRule]'))
alter table [PlayoffRankingRule]  drop constraint FKA919BCDD54C5FC04


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6FBE729A50A42025]') and parent_object_id = OBJECT_ID(N'[PlayoffSeriesRule]'))
alter table [PlayoffSeriesRule]  drop constraint FK6FBE729A50A42025


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6FBE729A203CC9B4]') and parent_object_id = OBJECT_ID(N'[PlayoffSeriesRule]'))
alter table [PlayoffSeriesRule]  drop constraint FK6FBE729A203CC9B4


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5335EE0675A08A3]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FK5335EE0675A08A3


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5335EE06A1E56CEC]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FK5335EE06A1E56CEC


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5335EE06449826F9]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FK5335EE06449826F9


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKE9EEA4E413AB5312]') and parent_object_id = OBJECT_ID(N'BestOfSeries'))
alter table BestOfSeries  drop constraint FKE9EEA4E413AB5312


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK53D0BA2D13AB5312]') and parent_object_id = OBJECT_ID(N'TotalGoalsSeries'))
alter table TotalGoalsSeries  drop constraint FK53D0BA2D13AB5312


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5D139797E5715C43]') and parent_object_id = OBJECT_ID(N'[SeasonDivisionRule]'))
alter table [SeasonDivisionRule]  drop constraint FK5D139797E5715C43


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8DDA0B26E5715C43]') and parent_object_id = OBJECT_ID(N'[SeasonScheduleRule]'))
alter table [SeasonScheduleRule]  drop constraint FK8DDA0B26E5715C43


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK55A2FF6CE5715C43]') and parent_object_id = OBJECT_ID(N'[SeasonTeamRule]'))
alter table [SeasonTeamRule]  drop constraint FK55A2FF6CE5715C43


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK55A2FF6C658A534D]') and parent_object_id = OBJECT_ID(N'[SeasonTeamRule]'))
alter table [SeasonTeamRule]  drop constraint FK55A2FF6C658A534D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK83C4285872D9B553]') and parent_object_id = OBJECT_ID(N'[SeasonDivision]'))
alter table [SeasonDivision]  drop constraint FK83C4285872D9B553


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK83C428588DA6462E]') and parent_object_id = OBJECT_ID(N'[SeasonDivision]'))
alter table [SeasonDivision]  drop constraint FK83C428588DA6462E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD4CDCAC4698BBE7]') and parent_object_id = OBJECT_ID(N'[TeamRanking]'))
alter table [TeamRanking]  drop constraint FKD4CDCAC4698BBE7


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD4CDCACEA9339FF]') and parent_object_id = OBJECT_ID(N'[TeamRanking]'))
alter table [TeamRanking]  drop constraint FKD4CDCACEA9339FF


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK804FE2AE514D8485]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FK804FE2AE514D8485


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK804FE2AEB430CE90]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FK804FE2AEB430CE90


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK804FE2AE9887C99C]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FK804FE2AE9887C99C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKB7EAA014565239F9]') and parent_object_id = OBJECT_ID(N'ScheduleGame'))
alter table ScheduleGame  drop constraint FKB7EAA014565239F9


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKB7EAA014EA9339FF]') and parent_object_id = OBJECT_ID(N'ScheduleGame'))
alter table ScheduleGame  drop constraint FKB7EAA014EA9339FF


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK3FF6E74CD6BCBCF3]') and parent_object_id = OBJECT_ID(N'PlayoffGame'))
alter table PlayoffGame  drop constraint FK3FF6E74CD6BCBCF3


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK3FF6E74CBD124319]') and parent_object_id = OBJECT_ID(N'PlayoffGame'))
alter table PlayoffGame  drop constraint FK3FF6E74CBD124319


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK695890EAEA9339FF]') and parent_object_id = OBJECT_ID(N'[SingleYearTeam]'))
alter table [SingleYearTeam]  drop constraint FK695890EAEA9339FF


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK695890EA801335D1]') and parent_object_id = OBJECT_ID(N'[SingleYearTeam]'))
alter table [SingleYearTeam]  drop constraint FK695890EA801335D1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK7FF14AC1E6EAF275]') and parent_object_id = OBJECT_ID(N'PlayoffTeam'))
alter table PlayoffTeam  drop constraint FK7FF14AC1E6EAF275


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKF55572A2E6EAF275]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FKF55572A2E6EAF275


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKF55572A28A186ED9]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FKF55572A28A186ED9


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKF55572A2DB25E183]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FKF55572A2DB25E183


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

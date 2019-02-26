
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKDD9FA7245E54DF51]') and parent_object_id = OBJECT_ID(N'[Competition]'))
alter table [Competition]  drop constraint FKDD9FA7245E54DF51


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK96144CD69FDEB3DA]') and parent_object_id = OBJECT_ID(N'Playoff'))
alter table Playoff  drop constraint FK96144CD69FDEB3DA


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5CD1D4C19FDEB3DA]') and parent_object_id = OBJECT_ID(N'Season'))
alter table Season  drop constraint FK5CD1D4C19FDEB3DA


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK33A0AAB7990DC2D5]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FK33A0AAB7990DC2D5


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK33A0AAB78EF7C8CD]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FK33A0AAB78EF7C8CD


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK33A0AAB75E54DF51]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FK33A0AAB75E54DF51


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKF1542ADD5E54DF51]') and parent_object_id = OBJECT_ID(N'PlayoffCompetitionConfig'))
alter table PlayoffCompetitionConfig  drop constraint FKF1542ADD5E54DF51


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK362921DD5E54DF51]') and parent_object_id = OBJECT_ID(N'SeasonCompetitionConfig'))
alter table SeasonCompetitionConfig  drop constraint FK362921DD5E54DF51


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK2844E4E32A9BE325]') and parent_object_id = OBJECT_ID(N'[PlayoffRankingRule]'))
alter table [PlayoffRankingRule]  drop constraint FK2844E4E32A9BE325


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK2844E4E3992DF378]') and parent_object_id = OBJECT_ID(N'[PlayoffRankingRule]'))
alter table [PlayoffRankingRule]  drop constraint FK2844E4E3992DF378


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKBE17B96D2A9BE325]') and parent_object_id = OBJECT_ID(N'[PlayoffSeriesRule]'))
alter table [PlayoffSeriesRule]  drop constraint FKBE17B96D2A9BE325


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKBE17B96D8EF7C8CD]') and parent_object_id = OBJECT_ID(N'[PlayoffSeriesRule]'))
alter table [PlayoffSeriesRule]  drop constraint FKBE17B96D8EF7C8CD


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK484C7744E04E4A4C]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FK484C7744E04E4A4C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK484C7744A045DE27]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FK484C7744A045DE27


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK484C77445A04B383]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FK484C77445A04B383


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKB71E2123E5E70307]') and parent_object_id = OBJECT_ID(N'BestOfSeries'))
alter table BestOfSeries  drop constraint FKB71E2123E5E70307


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK495C7E1E5E70307]') and parent_object_id = OBJECT_ID(N'TotalGoalsSeries'))
alter table TotalGoalsSeries  drop constraint FK495C7E1E5E70307


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKEBEB7C7BAE70844E]') and parent_object_id = OBJECT_ID(N'[SeasonDivisionRule]'))
alter table [SeasonDivisionRule]  drop constraint FKEBEB7C7BAE70844E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD1D70061AE70844E]') and parent_object_id = OBJECT_ID(N'[SeasonScheduleRule]'))
alter table [SeasonScheduleRule]  drop constraint FKD1D70061AE70844E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK4E35A86FAE70844E]') and parent_object_id = OBJECT_ID(N'[SeasonTeamRule]'))
alter table [SeasonTeamRule]  drop constraint FK4E35A86FAE70844E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK4E35A86F358E47C3]') and parent_object_id = OBJECT_ID(N'[SeasonTeamRule]'))
alter table [SeasonTeamRule]  drop constraint FK4E35A86F358E47C3


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK2007879CE2EF6E03]') and parent_object_id = OBJECT_ID(N'[SeasonDivision]'))
alter table [SeasonDivision]  drop constraint FK2007879CE2EF6E03


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK2007879CB63B04FF]') and parent_object_id = OBJECT_ID(N'[SeasonDivision]'))
alter table [SeasonDivision]  drop constraint FK2007879CB63B04FF


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK4C86B38CAF79B54]') and parent_object_id = OBJECT_ID(N'[TeamRanking]'))
alter table [TeamRanking]  drop constraint FK4C86B38CAF79B54


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK4C86B389FDEB3DA]') and parent_object_id = OBJECT_ID(N'[TeamRanking]'))
alter table [TeamRanking]  drop constraint FK4C86B389FDEB3DA


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKCDB9F5058735A84D]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FKCDB9F5058735A84D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKCDB9F5057D74C5E9]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FKCDB9F5057D74C5E9


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKCDB9F505929BD0AA]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FKCDB9F505929BD0AA


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKEFB945D7DF132B56]') and parent_object_id = OBJECT_ID(N'ScheduleGame'))
alter table ScheduleGame  drop constraint FKEFB945D7DF132B56


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKEFB945D79FDEB3DA]') and parent_object_id = OBJECT_ID(N'ScheduleGame'))
alter table ScheduleGame  drop constraint FKEFB945D79FDEB3DA


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5CA371B56C31E25E]') and parent_object_id = OBJECT_ID(N'PlayoffGame'))
alter table PlayoffGame  drop constraint FK5CA371B56C31E25E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5CA371B5FE609A47]') and parent_object_id = OBJECT_ID(N'PlayoffGame'))
alter table PlayoffGame  drop constraint FK5CA371B5FE609A47


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6E11A8E29FDEB3DA]') and parent_object_id = OBJECT_ID(N'[SingleYearTeam]'))
alter table [SingleYearTeam]  drop constraint FK6E11A8E29FDEB3DA


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6E11A8E2A7D49F80]') and parent_object_id = OBJECT_ID(N'[SingleYearTeam]'))
alter table [SingleYearTeam]  drop constraint FK6E11A8E2A7D49F80


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK118022772ECA8230]') and parent_object_id = OBJECT_ID(N'PlayoffTeam'))
alter table PlayoffTeam  drop constraint FK118022772ECA8230


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFEF83EF92ECA8230]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FKFEF83EF92ECA8230


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFEF83EF9BABFD02D]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FKFEF83EF9BABFD02D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFEF83EF9CE117ECA]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FKFEF83EF9CE117ECA


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

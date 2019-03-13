
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKDF3C6B56D26F43DF]') and parent_object_id = OBJECT_ID(N'[Competition]'))
alter table [Competition]  drop constraint FKDF3C6B56D26F43DF


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK454F5492D444096D]') and parent_object_id = OBJECT_ID(N'Playoff'))
alter table Playoff  drop constraint FK454F5492D444096D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK11A252B5D444096D]') and parent_object_id = OBJECT_ID(N'Season'))
alter table Season  drop constraint FK11A252B5D444096D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFD84702C8B09C90]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FKFD84702C8B09C90


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFD84702CEF571E07]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FKFD84702CEF571E07


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFD84702CD26F43DF]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FKFD84702CD26F43DF


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC46062BCD26F43DF]') and parent_object_id = OBJECT_ID(N'PlayoffCompetitionConfig'))
alter table PlayoffCompetitionConfig  drop constraint FKC46062BCD26F43DF


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKEB45863BD26F43DF]') and parent_object_id = OBJECT_ID(N'SeasonCompetitionConfig'))
alter table SeasonCompetitionConfig  drop constraint FKEB45863BD26F43DF


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5D0347301049A69]') and parent_object_id = OBJECT_ID(N'[PlayoffRankingRule]'))
alter table [PlayoffRankingRule]  drop constraint FK5D0347301049A69


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK4FF9611D1049A69]') and parent_object_id = OBJECT_ID(N'[PlayoffSeriesRule]'))
alter table [PlayoffSeriesRule]  drop constraint FK4FF9611D1049A69


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK4FF9611DEF571E07]') and parent_object_id = OBJECT_ID(N'[PlayoffSeriesRule]'))
alter table [PlayoffSeriesRule]  drop constraint FK4FF9611DEF571E07


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK23D20D6FD77ACAC7]') and parent_object_id = OBJECT_ID(N'[SeasonDivisionRule]'))
alter table [SeasonDivisionRule]  drop constraint FK23D20D6FD77ACAC7


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK49E4E9A3D77ACAC7]') and parent_object_id = OBJECT_ID(N'[SeasonScheduleRule]'))
alter table [SeasonScheduleRule]  drop constraint FK49E4E9A3D77ACAC7


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK49E4E9A36DDD149A]') and parent_object_id = OBJECT_ID(N'[SeasonScheduleRule]'))
alter table [SeasonScheduleRule]  drop constraint FK49E4E9A36DDD149A


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK49E4E9A32494E92C]') and parent_object_id = OBJECT_ID(N'[SeasonScheduleRule]'))
alter table [SeasonScheduleRule]  drop constraint FK49E4E9A32494E92C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK49E4E9A3ADFAC6EA]') and parent_object_id = OBJECT_ID(N'[SeasonScheduleRule]'))
alter table [SeasonScheduleRule]  drop constraint FK49E4E9A3ADFAC6EA


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK49E4E9A3CB7B191A]') and parent_object_id = OBJECT_ID(N'[SeasonScheduleRule]'))
alter table [SeasonScheduleRule]  drop constraint FK49E4E9A3CB7B191A


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK368F7322D77ACAC7]') and parent_object_id = OBJECT_ID(N'[SeasonTeamRule]'))
alter table [SeasonTeamRule]  drop constraint FK368F7322D77ACAC7


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK368F7322D187418B]') and parent_object_id = OBJECT_ID(N'[SeasonTeamRule]'))
alter table [SeasonTeamRule]  drop constraint FK368F7322D187418B


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK953627E5AD2E23B5]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FK953627E5AD2E23B5


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK953627E588E04F5D]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FK953627E588E04F5D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK953627E548C79D2D]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FK953627E548C79D2D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK89C99E622CD77E52]') and parent_object_id = OBJECT_ID(N'BestOfSeries'))
alter table BestOfSeries  drop constraint FK89C99E622CD77E52


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK77988B082CD77E52]') and parent_object_id = OBJECT_ID(N'TotalGoalsSeries'))
alter table TotalGoalsSeries  drop constraint FK77988B082CD77E52


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKF8646BAC41D59B11]') and parent_object_id = OBJECT_ID(N'[SeasonDivision]'))
alter table [SeasonDivision]  drop constraint FKF8646BAC41D59B11


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKF8646BAC7E108970]') and parent_object_id = OBJECT_ID(N'[SeasonDivision]'))
alter table [SeasonDivision]  drop constraint FKF8646BAC7E108970


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD68558508C90BC9D]') and parent_object_id = OBJECT_ID(N'[TeamRanking]'))
alter table [TeamRanking]  drop constraint FKD68558508C90BC9D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD6855850D444096D]') and parent_object_id = OBJECT_ID(N'[TeamRanking]'))
alter table [TeamRanking]  drop constraint FKD6855850D444096D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK440542F96DDD149A]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FK440542F96DDD149A


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK440542F9ADFAC6EA]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FK440542F9ADFAC6EA


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK440542F94D0E4208]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FK440542F94D0E4208


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK257DE5DF8E6B429E]') and parent_object_id = OBJECT_ID(N'ScheduleGame'))
alter table ScheduleGame  drop constraint FK257DE5DF8E6B429E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK257DE5DFD444096D]') and parent_object_id = OBJECT_ID(N'ScheduleGame'))
alter table ScheduleGame  drop constraint FK257DE5DFD444096D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKB6594108EC08CA72]') and parent_object_id = OBJECT_ID(N'PlayoffGame'))
alter table PlayoffGame  drop constraint FKB6594108EC08CA72


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKB659410839FF40D3]') and parent_object_id = OBJECT_ID(N'PlayoffGame'))
alter table PlayoffGame  drop constraint FKB659410839FF40D3


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9FDC52F4D444096D]') and parent_object_id = OBJECT_ID(N'[SingleYearTeam]'))
alter table [SingleYearTeam]  drop constraint FK9FDC52F4D444096D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9FDC52F4815A8CE3]') and parent_object_id = OBJECT_ID(N'[SingleYearTeam]'))
alter table [SingleYearTeam]  drop constraint FK9FDC52F4815A8CE3


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK71B47F1FA0AD5288]') and parent_object_id = OBJECT_ID(N'PlayoffTeam'))
alter table PlayoffTeam  drop constraint FK71B47F1FA0AD5288


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC9E81843A0AD5288]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FKC9E81843A0AD5288


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC9E81843CEBC67BC]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FKC9E81843CEBC67BC


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC9E81843F7EC981D]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FKC9E81843F7EC981D


    if exists (select * from dbo.sysobjects where id = object_id(N'[Competition]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [Competition]

    if exists (select * from dbo.sysobjects where id = object_id(N'Playoff') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Playoff

    if exists (select * from dbo.sysobjects where id = object_id(N'Season') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Season

    if exists (select * from dbo.sysobjects where id = object_id(N'[CompetitionConfig]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [CompetitionConfig]

    if exists (select * from dbo.sysobjects where id = object_id(N'PlayoffCompetitionConfig') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table PlayoffCompetitionConfig

    if exists (select * from dbo.sysobjects where id = object_id(N'SeasonCompetitionConfig') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table SeasonCompetitionConfig

    if exists (select * from dbo.sysobjects where id = object_id(N'[PlayoffRankingRule]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [PlayoffRankingRule]

    if exists (select * from dbo.sysobjects where id = object_id(N'[PlayoffSeriesRule]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [PlayoffSeriesRule]

    if exists (select * from dbo.sysobjects where id = object_id(N'[SeasonDivisionRule]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [SeasonDivisionRule]

    if exists (select * from dbo.sysobjects where id = object_id(N'[SeasonScheduleRule]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [SeasonScheduleRule]

    if exists (select * from dbo.sysobjects where id = object_id(N'[SeasonTeamRule]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [SeasonTeamRule]

    if exists (select * from dbo.sysobjects where id = object_id(N'[PlayoffSeries]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [PlayoffSeries]

    if exists (select * from dbo.sysobjects where id = object_id(N'BestOfSeries') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table BestOfSeries

    if exists (select * from dbo.sysobjects where id = object_id(N'TotalGoalsSeries') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table TotalGoalsSeries

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

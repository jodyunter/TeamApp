
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKBFC689B86585EC94]') and parent_object_id = OBJECT_ID(N'[Competition]'))
alter table [Competition]  drop constraint FKBFC689B86585EC94


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC27FCBCB4857F611]') and parent_object_id = OBJECT_ID(N'Playoff'))
alter table Playoff  drop constraint FKC27FCBCB4857F611


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK7EF2DE694857F611]') and parent_object_id = OBJECT_ID(N'Season'))
alter table Season  drop constraint FK7EF2DE694857F611


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKE3FDFFA1CF0C2CC0]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FKE3FDFFA1CF0C2CC0


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKE3FDFFA176EE2073]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FKE3FDFFA176EE2073


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKE3FDFFA16585EC94]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FKE3FDFFA16585EC94


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8DD54DD06585EC94]') and parent_object_id = OBJECT_ID(N'PlayoffCompetitionConfig'))
alter table PlayoffCompetitionConfig  drop constraint FK8DD54DD06585EC94


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK1DEAB5456585EC94]') and parent_object_id = OBJECT_ID(N'SeasonCompetitionConfig'))
alter table SeasonCompetitionConfig  drop constraint FK1DEAB5456585EC94


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK1D12917FDE6D01F5]') and parent_object_id = OBJECT_ID(N'[PlayoffRankingRule]'))
alter table [PlayoffRankingRule]  drop constraint FK1D12917FDE6D01F5


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK415DAEBFDE6D01F5]') and parent_object_id = OBJECT_ID(N'[PlayoffSeriesRule]'))
alter table [PlayoffSeriesRule]  drop constraint FK415DAEBFDE6D01F5


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK415DAEBF76EE2073]') and parent_object_id = OBJECT_ID(N'[PlayoffSeriesRule]'))
alter table [PlayoffSeriesRule]  drop constraint FK415DAEBF76EE2073


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKE1811D1AF757B1BC]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FKE1811D1AF757B1BC


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKE1811D1A60550BC3]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FKE1811D1A60550BC3


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKE1811D1AFFA4E0F7]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FKE1811D1AFFA4E0F7


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK42A9A35E8BD76AB5]') and parent_object_id = OBJECT_ID(N'BestOfSeries'))
alter table BestOfSeries  drop constraint FK42A9A35E8BD76AB5


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK7283F8E8BD76AB5]') and parent_object_id = OBJECT_ID(N'TotalGoalsSeries'))
alter table TotalGoalsSeries  drop constraint FK7283F8E8BD76AB5


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKBE15D188D16058E9]') and parent_object_id = OBJECT_ID(N'[SeasonDivisionRule]'))
alter table [SeasonDivisionRule]  drop constraint FKBE15D188D16058E9


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK10D0FD45D16058E9]') and parent_object_id = OBJECT_ID(N'[SeasonScheduleRule]'))
alter table [SeasonScheduleRule]  drop constraint FK10D0FD45D16058E9


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK60EF7EBBD16058E9]') and parent_object_id = OBJECT_ID(N'[SeasonTeamRule]'))
alter table [SeasonTeamRule]  drop constraint FK60EF7EBBD16058E9


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK60EF7EBB6D91526]') and parent_object_id = OBJECT_ID(N'[SeasonTeamRule]'))
alter table [SeasonTeamRule]  drop constraint FK60EF7EBB6D91526


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK4B0C8DBC98E1C95]') and parent_object_id = OBJECT_ID(N'[SeasonDivision]'))
alter table [SeasonDivision]  drop constraint FK4B0C8DBC98E1C95


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK4B0C8DBCDCC72888]') and parent_object_id = OBJECT_ID(N'[SeasonDivision]'))
alter table [SeasonDivision]  drop constraint FK4B0C8DBCDCC72888


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK35DF650A505BD133]') and parent_object_id = OBJECT_ID(N'[TeamRanking]'))
alter table [TeamRanking]  drop constraint FK35DF650A505BD133


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK35DF650A4857F611]') and parent_object_id = OBJECT_ID(N'[TeamRanking]'))
alter table [TeamRanking]  drop constraint FK35DF650A4857F611


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK1062C2CB1403085E]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FK1062C2CB1403085E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK1062C2CB8BF2E36A]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FK1062C2CB8BF2E36A


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK1062C2CBFD95E26C]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FK1062C2CBFD95E26C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6FADB6561469AC25]') and parent_object_id = OBJECT_ID(N'ScheduleGame'))
alter table ScheduleGame  drop constraint FK6FADB6561469AC25


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6FADB6564857F611]') and parent_object_id = OBJECT_ID(N'ScheduleGame'))
alter table ScheduleGame  drop constraint FK6FADB6564857F611


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK66C17CF9877BFA8B]') and parent_object_id = OBJECT_ID(N'PlayoffGame'))
alter table PlayoffGame  drop constraint FK66C17CF9877BFA8B


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK66C17CF91D335932]') and parent_object_id = OBJECT_ID(N'PlayoffGame'))
alter table PlayoffGame  drop constraint FK66C17CF91D335932


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK392D4E264857F611]') and parent_object_id = OBJECT_ID(N'[SingleYearTeam]'))
alter table [SingleYearTeam]  drop constraint FK392D4E264857F611


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK392D4E26EA50714D]') and parent_object_id = OBJECT_ID(N'[SingleYearTeam]'))
alter table [SingleYearTeam]  drop constraint FK392D4E26EA50714D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK2BBBFE2FDF165509]') and parent_object_id = OBJECT_ID(N'PlayoffTeam'))
alter table PlayoffTeam  drop constraint FK2BBBFE2FDF165509


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5DAC2B40DF165509]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FK5DAC2B40DF165509


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5DAC2B40984BECAD]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FK5DAC2B40984BECAD


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5DAC2B407BD119A8]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FK5DAC2B407BD119A8


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

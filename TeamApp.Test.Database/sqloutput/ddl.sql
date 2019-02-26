
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKF0FBAE7640C4DF18]') and parent_object_id = OBJECT_ID(N'[Competition]'))
alter table [Competition]  drop constraint FKF0FBAE7640C4DF18


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK95B6B2AEF474E55C]') and parent_object_id = OBJECT_ID(N'Playoff'))
alter table Playoff  drop constraint FK95B6B2AEF474E55C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKF8474F9FF474E55C]') and parent_object_id = OBJECT_ID(N'Season'))
alter table Season  drop constraint FKF8474F9FF474E55C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8975DE1382EDF47F]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FK8975DE1382EDF47F


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8975DE13AA7074D0]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FK8975DE13AA7074D0


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8975DE1340C4DF18]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FK8975DE1340C4DF18


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKB162DC6640C4DF18]') and parent_object_id = OBJECT_ID(N'PlayoffCompetitionConfig'))
alter table PlayoffCompetitionConfig  drop constraint FKB162DC6640C4DF18


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK10545F6040C4DF18]') and parent_object_id = OBJECT_ID(N'SeasonCompetitionConfig'))
alter table SeasonCompetitionConfig  drop constraint FK10545F6040C4DF18


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK49B7D0F37636E7F1]') and parent_object_id = OBJECT_ID(N'[PlayoffRankingRule]'))
alter table [PlayoffRankingRule]  drop constraint FK49B7D0F37636E7F1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK49B7D0F3693C6C9E]') and parent_object_id = OBJECT_ID(N'[PlayoffRankingRule]'))
alter table [PlayoffRankingRule]  drop constraint FK49B7D0F3693C6C9E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK1B7F9DB87636E7F1]') and parent_object_id = OBJECT_ID(N'[PlayoffSeriesRule]'))
alter table [PlayoffSeriesRule]  drop constraint FK1B7F9DB87636E7F1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK1B7F9DB8AA7074D0]') and parent_object_id = OBJECT_ID(N'[PlayoffSeriesRule]'))
alter table [PlayoffSeriesRule]  drop constraint FK1B7F9DB8AA7074D0


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8A1FB5A820977A3F]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FK8A1FB5A820977A3F


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8A1FB5A881CB0B4A]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FK8A1FB5A881CB0B4A


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8A1FB5A84EAAD1A1]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FK8A1FB5A84EAAD1A1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC7A780C6E7F9971E]') and parent_object_id = OBJECT_ID(N'BestOfSeries'))
alter table BestOfSeries  drop constraint FKC7A780C6E7F9971E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK132E02B6E7F9971E]') and parent_object_id = OBJECT_ID(N'TotalGoalsSeries'))
alter table TotalGoalsSeries  drop constraint FK132E02B6E7F9971E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKCB0194EBCAC779AB]') and parent_object_id = OBJECT_ID(N'[SeasonDivisionRule]'))
alter table [SeasonDivisionRule]  drop constraint FKCB0194EBCAC779AB


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK1A182156CAC779AB]') and parent_object_id = OBJECT_ID(N'[SeasonScheduleRule]'))
alter table [SeasonScheduleRule]  drop constraint FK1A182156CAC779AB


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK7F0D9C66CAC779AB]') and parent_object_id = OBJECT_ID(N'[SeasonTeamRule]'))
alter table [SeasonTeamRule]  drop constraint FK7F0D9C66CAC779AB


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK7F0D9C66A7606A9C]') and parent_object_id = OBJECT_ID(N'[SeasonTeamRule]'))
alter table [SeasonTeamRule]  drop constraint FK7F0D9C66A7606A9C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK61A285B6E747D000]') and parent_object_id = OBJECT_ID(N'[SeasonDivision]'))
alter table [SeasonDivision]  drop constraint FK61A285B6E747D000


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK61A285B6D2030F6F]') and parent_object_id = OBJECT_ID(N'[SeasonDivision]'))
alter table [SeasonDivision]  drop constraint FK61A285B6D2030F6F


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK217DA6EB23452FC6]') and parent_object_id = OBJECT_ID(N'[TeamRanking]'))
alter table [TeamRanking]  drop constraint FK217DA6EB23452FC6


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK217DA6EBF474E55C]') and parent_object_id = OBJECT_ID(N'[TeamRanking]'))
alter table [TeamRanking]  drop constraint FK217DA6EBF474E55C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKEDD544C883D7A6DE]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FKEDD544C883D7A6DE


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKEDD544C84CB67C35]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FKEDD544C84CB67C35


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKEDD544C8332063B2]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FKEDD544C8332063B2


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKDE032A3FE6E8EFDE]') and parent_object_id = OBJECT_ID(N'ScheduleGame'))
alter table ScheduleGame  drop constraint FKDE032A3FE6E8EFDE


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKDE032A3FF474E55C]') and parent_object_id = OBJECT_ID(N'ScheduleGame'))
alter table ScheduleGame  drop constraint FKDE032A3FF474E55C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5842F85945D52019]') and parent_object_id = OBJECT_ID(N'PlayoffGame'))
alter table PlayoffGame  drop constraint FK5842F85945D52019


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5842F859B375C2C1]') and parent_object_id = OBJECT_ID(N'PlayoffGame'))
alter table PlayoffGame  drop constraint FK5842F859B375C2C1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC39C025FF474E55C]') and parent_object_id = OBJECT_ID(N'[SingleYearTeam]'))
alter table [SingleYearTeam]  drop constraint FKC39C025FF474E55C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC39C025F5DFC5E73]') and parent_object_id = OBJECT_ID(N'[SingleYearTeam]'))
alter table [SingleYearTeam]  drop constraint FKC39C025F5DFC5E73


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKE01E8208AD65E14]') and parent_object_id = OBJECT_ID(N'PlayoffTeam'))
alter table PlayoffTeam  drop constraint FKE01E8208AD65E14


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK655D0A85AD65E14]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FK655D0A85AD65E14


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK655D0A85EFCB610F]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FK655D0A85EFCB610F


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK655D0A85B1C81E50]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FK655D0A85B1C81E50


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

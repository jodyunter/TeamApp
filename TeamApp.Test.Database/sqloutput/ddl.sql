
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKAB9494C2E6B94E68]') and parent_object_id = OBJECT_ID(N'[Competition]'))
alter table [Competition]  drop constraint FKAB9494C2E6B94E68


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK45D912DCD488EE47]') and parent_object_id = OBJECT_ID(N'Playoff'))
alter table Playoff  drop constraint FK45D912DCD488EE47


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKCD8F25A6D488EE47]') and parent_object_id = OBJECT_ID(N'Season'))
alter table Season  drop constraint FKCD8F25A6D488EE47


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK184F5873B54F50C9]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FK184F5873B54F50C9


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK184F587342AC8057]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FK184F587342AC8057


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK184F5873E6B94E68]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FK184F5873E6B94E68


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK40076F98E6B94E68]') and parent_object_id = OBJECT_ID(N'PlayoffCompetitionConfig'))
alter table PlayoffCompetitionConfig  drop constraint FK40076F98E6B94E68


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFD084AB4E6B94E68]') and parent_object_id = OBJECT_ID(N'SeasonCompetitionConfig'))
alter table SeasonCompetitionConfig  drop constraint FKFD084AB4E6B94E68


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC8205F73B1A06E69]') and parent_object_id = OBJECT_ID(N'[PlayoffRankingRule]'))
alter table [PlayoffRankingRule]  drop constraint FKC8205F73B1A06E69


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC8205F7318433D5A]') and parent_object_id = OBJECT_ID(N'[PlayoffRankingRule]'))
alter table [PlayoffRankingRule]  drop constraint FKC8205F7318433D5A


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK59C5C8FEB1A06E69]') and parent_object_id = OBJECT_ID(N'[PlayoffSeriesRule]'))
alter table [PlayoffSeriesRule]  drop constraint FK59C5C8FEB1A06E69


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK59C5C8FE42AC8057]') and parent_object_id = OBJECT_ID(N'[PlayoffSeriesRule]'))
alter table [PlayoffSeriesRule]  drop constraint FK59C5C8FE42AC8057


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK50B4636173EDC08A]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FK50B4636173EDC08A


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK50B46361AC2E2024]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FK50B46361AC2E2024


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK50B4636166391554]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FK50B4636166391554


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK79BF030E8B31DD69]') and parent_object_id = OBJECT_ID(N'BestOfSeries'))
alter table BestOfSeries  drop constraint FK79BF030E8B31DD69


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK726CDD558B31DD69]') and parent_object_id = OBJECT_ID(N'TotalGoalsSeries'))
alter table TotalGoalsSeries  drop constraint FK726CDD558B31DD69


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK796E9EE334E80653]') and parent_object_id = OBJECT_ID(N'[SeasonDivisionRule]'))
alter table [SeasonDivisionRule]  drop constraint FK796E9EE334E80653


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6B5DEE1134E80653]') and parent_object_id = OBJECT_ID(N'[SeasonScheduleRule]'))
alter table [SeasonScheduleRule]  drop constraint FK6B5DEE1134E80653


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKA24D17D734E80653]') and parent_object_id = OBJECT_ID(N'[SeasonTeamRule]'))
alter table [SeasonTeamRule]  drop constraint FKA24D17D734E80653


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKA24D17D7C98B26EE]') and parent_object_id = OBJECT_ID(N'[SeasonTeamRule]'))
alter table [SeasonTeamRule]  drop constraint FKA24D17D7C98B26EE


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKEFE5B7AB130C7074]') and parent_object_id = OBJECT_ID(N'[SeasonDivision]'))
alter table [SeasonDivision]  drop constraint FKEFE5B7AB130C7074


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKEFE5B7AB259FA9FD]') and parent_object_id = OBJECT_ID(N'[SeasonDivision]'))
alter table [SeasonDivision]  drop constraint FKEFE5B7AB259FA9FD


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK2352FC66493201C2]') and parent_object_id = OBJECT_ID(N'[TeamRanking]'))
alter table [TeamRanking]  drop constraint FK2352FC66493201C2


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK2352FC66D488EE47]') and parent_object_id = OBJECT_ID(N'[TeamRanking]'))
alter table [TeamRanking]  drop constraint FK2352FC66D488EE47


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK576383608CD759D8]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FK576383608CD759D8


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5763836046C06CA8]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FK5763836046C06CA8


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK57638360B5876F84]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FK57638360B5876F84


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5D330F0D29E327F3]') and parent_object_id = OBJECT_ID(N'ScheduleGame'))
alter table ScheduleGame  drop constraint FK5D330F0D29E327F3


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5D330F0DD488EE47]') and parent_object_id = OBJECT_ID(N'ScheduleGame'))
alter table ScheduleGame  drop constraint FK5D330F0DD488EE47


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKA46B1B7B6622E0D4]') and parent_object_id = OBJECT_ID(N'PlayoffGame'))
alter table PlayoffGame  drop constraint FKA46B1B7B6622E0D4


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKA46B1B7B7D1912BC]') and parent_object_id = OBJECT_ID(N'PlayoffGame'))
alter table PlayoffGame  drop constraint FKA46B1B7B7D1912BC


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK933FC5ECD488EE47]') and parent_object_id = OBJECT_ID(N'[SingleYearTeam]'))
alter table [SingleYearTeam]  drop constraint FK933FC5ECD488EE47


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK933FC5EC8286F7FD]') and parent_object_id = OBJECT_ID(N'[SingleYearTeam]'))
alter table [SingleYearTeam]  drop constraint FK933FC5EC8286F7FD


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK276731354A4ABE12]') and parent_object_id = OBJECT_ID(N'PlayoffTeam'))
alter table PlayoffTeam  drop constraint FK276731354A4ABE12


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKBDFA40044A4ABE12]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FKBDFA40044A4ABE12


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKBDFA4004BBE766FB]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FKBDFA4004BBE766FB


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKBDFA40045BD359A9]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FKBDFA40045BD359A9


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

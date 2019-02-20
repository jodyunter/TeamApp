
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC25A6E3623F9BDCD]') and parent_object_id = OBJECT_ID(N'[Competition]'))
alter table [Competition]  drop constraint FKC25A6E3623F9BDCD


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKA3F10832B76BA051]') and parent_object_id = OBJECT_ID(N'Playoff'))
alter table Playoff  drop constraint FKA3F10832B76BA051


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6A83F33B76BA051]') and parent_object_id = OBJECT_ID(N'Season'))
alter table Season  drop constraint FK6A83F33B76BA051


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFC0B582696CA030A]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FKFC0B582696CA030A


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFC0B582650DED98E]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FKFC0B582650DED98E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFC0B582623F9BDCD]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FKFC0B582623F9BDCD


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKEF952DA123F9BDCD]') and parent_object_id = OBJECT_ID(N'PlayoffCompetitionConfig'))
alter table PlayoffCompetitionConfig  drop constraint FKEF952DA123F9BDCD


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKEBDB065323F9BDCD]') and parent_object_id = OBJECT_ID(N'SeasonCompetitionConfig'))
alter table SeasonCompetitionConfig  drop constraint FKEBDB065323F9BDCD


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKE87CCC22DECE4A2F]') and parent_object_id = OBJECT_ID(N'[PlayoffRankingRule]'))
alter table [PlayoffRankingRule]  drop constraint FKE87CCC22DECE4A2F


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKE87CCC22708581E7]') and parent_object_id = OBJECT_ID(N'[PlayoffRankingRule]'))
alter table [PlayoffRankingRule]  drop constraint FKE87CCC22708581E7


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK397F2137DECE4A2F]') and parent_object_id = OBJECT_ID(N'[PlayoffSeriesRule]'))
alter table [PlayoffSeriesRule]  drop constraint FK397F2137DECE4A2F


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK397F213750DED98E]') and parent_object_id = OBJECT_ID(N'[PlayoffSeriesRule]'))
alter table [PlayoffSeriesRule]  drop constraint FK397F213750DED98E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK21C3E2D0307B2137]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FK21C3E2D0307B2137


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK21C3E2D09F79D7CA]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FK21C3E2D09F79D7CA


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK21C3E2D0CE2DF76C]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FK21C3E2D0CE2DF76C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC265FBA1FAA3D135]') and parent_object_id = OBJECT_ID(N'BestOfSeries'))
alter table BestOfSeries  drop constraint FKC265FBA1FAA3D135


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK19DF0BB1FAA3D135]') and parent_object_id = OBJECT_ID(N'TotalGoalsSeries'))
alter table TotalGoalsSeries  drop constraint FK19DF0BB1FAA3D135


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC9F8C9388A3770AD]') and parent_object_id = OBJECT_ID(N'[SeasonDivisionRule]'))
alter table [SeasonDivisionRule]  drop constraint FKC9F8C9388A3770AD


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK71AC783F8A3770AD]') and parent_object_id = OBJECT_ID(N'[SeasonScheduleRule]'))
alter table [SeasonScheduleRule]  drop constraint FK71AC783F8A3770AD


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK379A1CD78A3770AD]') and parent_object_id = OBJECT_ID(N'[SeasonTeamRule]'))
alter table [SeasonTeamRule]  drop constraint FK379A1CD78A3770AD


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK379A1CD742A52E78]') and parent_object_id = OBJECT_ID(N'[SeasonTeamRule]'))
alter table [SeasonTeamRule]  drop constraint FK379A1CD742A52E78


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK92002CE4518D4E15]') and parent_object_id = OBJECT_ID(N'[SeasonDivision]'))
alter table [SeasonDivision]  drop constraint FK92002CE4518D4E15


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK92002CE4F32B41E4]') and parent_object_id = OBJECT_ID(N'[SeasonDivision]'))
alter table [SeasonDivision]  drop constraint FK92002CE4F32B41E4


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK95604C27A9B2AB6E]') and parent_object_id = OBJECT_ID(N'[TeamRanking]'))
alter table [TeamRanking]  drop constraint FK95604C27A9B2AB6E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK95604C27B76BA051]') and parent_object_id = OBJECT_ID(N'[TeamRanking]'))
alter table [TeamRanking]  drop constraint FK95604C27B76BA051


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK456A12249A0F0745]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FK456A12249A0F0745


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK456A1224CB5B27E3]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FK456A1224CB5B27E3


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK456A1224997BCAB6]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FK456A1224997BCAB6


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK2C83EFE36B1E4AC7]') and parent_object_id = OBJECT_ID(N'ScheduleGame'))
alter table ScheduleGame  drop constraint FK2C83EFE36B1E4AC7


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK2C83EFE3B76BA051]') and parent_object_id = OBJECT_ID(N'ScheduleGame'))
alter table ScheduleGame  drop constraint FK2C83EFE3B76BA051


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKA1AD4B6A127DAC7D]') and parent_object_id = OBJECT_ID(N'PlayoffGame'))
alter table PlayoffGame  drop constraint FKA1AD4B6A127DAC7D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKA1AD4B6A380B1A7]') and parent_object_id = OBJECT_ID(N'PlayoffGame'))
alter table PlayoffGame  drop constraint FKA1AD4B6A380B1A7


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK81B99BF2B76BA051]') and parent_object_id = OBJECT_ID(N'[SingleYearTeam]'))
alter table [SingleYearTeam]  drop constraint FK81B99BF2B76BA051


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK81B99BF23053237F]') and parent_object_id = OBJECT_ID(N'[SingleYearTeam]'))
alter table [SingleYearTeam]  drop constraint FK81B99BF23053237F


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK7900E25D110E1FC2]') and parent_object_id = OBJECT_ID(N'PlayoffTeam'))
alter table PlayoffTeam  drop constraint FK7900E25D110E1FC2


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8F100DF2110E1FC2]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FK8F100DF2110E1FC2


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8F100DF2CBEF8BAA]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FK8F100DF2CBEF8BAA


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8F100DF2E24E1579]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FK8F100DF2E24E1579


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

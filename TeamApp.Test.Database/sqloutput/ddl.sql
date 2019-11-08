
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK2DFF6FDCB415A475]') and parent_object_id = OBJECT_ID(N'[Competition]'))
alter table [Competition]  drop constraint FK2DFF6FDCB415A475


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK1FFB23F34A8B8FD6]') and parent_object_id = OBJECT_ID(N'Playoff'))
alter table Playoff  drop constraint FK1FFB23F34A8B8FD6


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKB6B78D8D4A8B8FD6]') and parent_object_id = OBJECT_ID(N'Season'))
alter table Season  drop constraint FKB6B78D8D4A8B8FD6


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK249D08C248DBBC5F]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FK249D08C248DBBC5F


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK249D08C2F079C384]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FK249D08C2F079C384


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK249D08C2B415A475]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FK249D08C2B415A475


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD9348682B415A475]') and parent_object_id = OBJECT_ID(N'PlayoffCompetitionConfig'))
alter table PlayoffCompetitionConfig  drop constraint FKD9348682B415A475


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKDDA800A4B415A475]') and parent_object_id = OBJECT_ID(N'SeasonCompetitionConfig'))
alter table SeasonCompetitionConfig  drop constraint FKDDA800A4B415A475


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8CEDA121B415A475]') and parent_object_id = OBJECT_ID(N'[CompetitionConfigFinalRankingRule]'))
alter table [CompetitionConfigFinalRankingRule]  drop constraint FK8CEDA121B415A475


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKEB0C0F1C7A50BC11]') and parent_object_id = OBJECT_ID(N'SeasonCompetitionConfigFinalRankingRule'))
alter table SeasonCompetitionConfigFinalRankingRule  drop constraint FKEB0C0F1C7A50BC11


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKE718A32C5189803B]') and parent_object_id = OBJECT_ID(N'[PlayoffRankingRule]'))
alter table [PlayoffRankingRule]  drop constraint FKE718A32C5189803B


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK80F2B8CC5189803B]') and parent_object_id = OBJECT_ID(N'[PlayoffSeriesRule]'))
alter table [PlayoffSeriesRule]  drop constraint FK80F2B8CC5189803B


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK80F2B8CCF079C384]') and parent_object_id = OBJECT_ID(N'[PlayoffSeriesRule]'))
alter table [PlayoffSeriesRule]  drop constraint FK80F2B8CCF079C384


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK38AF1BA0DCFB6B9B]') and parent_object_id = OBJECT_ID(N'[SeasonDivisionRule]'))
alter table [SeasonDivisionRule]  drop constraint FK38AF1BA0DCFB6B9B


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK38AF1BA09C437384]') and parent_object_id = OBJECT_ID(N'[SeasonDivisionRule]'))
alter table [SeasonDivisionRule]  drop constraint FK38AF1BA09C437384


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK4A3EA11BDCFB6B9B]') and parent_object_id = OBJECT_ID(N'[SeasonScheduleRule]'))
alter table [SeasonScheduleRule]  drop constraint FK4A3EA11BDCFB6B9B


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK4A3EA11BC3401D7B]') and parent_object_id = OBJECT_ID(N'[SeasonScheduleRule]'))
alter table [SeasonScheduleRule]  drop constraint FK4A3EA11BC3401D7B


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK4A3EA11B38182332]') and parent_object_id = OBJECT_ID(N'[SeasonScheduleRule]'))
alter table [SeasonScheduleRule]  drop constraint FK4A3EA11B38182332


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK4A3EA11B6F196E85]') and parent_object_id = OBJECT_ID(N'[SeasonScheduleRule]'))
alter table [SeasonScheduleRule]  drop constraint FK4A3EA11B6F196E85


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK4A3EA11B690BAEF]') and parent_object_id = OBJECT_ID(N'[SeasonScheduleRule]'))
alter table [SeasonScheduleRule]  drop constraint FK4A3EA11B690BAEF


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKE8DCC500DCFB6B9B]') and parent_object_id = OBJECT_ID(N'[SeasonTeamRule]'))
alter table [SeasonTeamRule]  drop constraint FKE8DCC500DCFB6B9B


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKE8DCC500782DA5F3]') and parent_object_id = OBJECT_ID(N'[SeasonTeamRule]'))
alter table [SeasonTeamRule]  drop constraint FKE8DCC500782DA5F3


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKE8DCC500BB3A4007]') and parent_object_id = OBJECT_ID(N'[SeasonTeamRule]'))
alter table [SeasonTeamRule]  drop constraint FKE8DCC500BB3A4007


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK3D5354F412FB810C]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FK3D5354F412FB810C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK3D5354F4A69CBCAA]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FK3D5354F4A69CBCAA


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK3D5354F4AC5CF54]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FK3D5354F4AC5CF54


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK95E91038B035AA0C]') and parent_object_id = OBJECT_ID(N'BestOfSeries'))
alter table BestOfSeries  drop constraint FK95E91038B035AA0C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK317EFE97B035AA0C]') and parent_object_id = OBJECT_ID(N'TotalGoalsSeries'))
alter table TotalGoalsSeries  drop constraint FK317EFE97B035AA0C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKA8F5178882804EE9]') and parent_object_id = OBJECT_ID(N'[SeasonDivision]'))
alter table [SeasonDivision]  drop constraint FKA8F5178882804EE9


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKA8F517881A7A340]') and parent_object_id = OBJECT_ID(N'[SeasonDivision]'))
alter table [SeasonDivision]  drop constraint FKA8F517881A7A340


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK7FACEAA135796475]') and parent_object_id = OBJECT_ID(N'[TeamRanking]'))
alter table [TeamRanking]  drop constraint FK7FACEAA135796475


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK7FACEAA14A8B8FD6]') and parent_object_id = OBJECT_ID(N'[TeamRanking]'))
alter table [TeamRanking]  drop constraint FK7FACEAA14A8B8FD6


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFC5CA3F2C3401D7B]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FKFC5CA3F2C3401D7B


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFC5CA3F26F196E85]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FKFC5CA3F26F196E85


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFC5CA3F2D29F1A0F]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FKFC5CA3F2D29F1A0F


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD6B153DC2C3A96E5]') and parent_object_id = OBJECT_ID(N'ScheduleGame'))
alter table ScheduleGame  drop constraint FKD6B153DC2C3A96E5


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD6B153DC4A8B8FD6]') and parent_object_id = OBJECT_ID(N'ScheduleGame'))
alter table ScheduleGame  drop constraint FKD6B153DC4A8B8FD6


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKF4ACF60A8D0E43E4]') and parent_object_id = OBJECT_ID(N'PlayoffGame'))
alter table PlayoffGame  drop constraint FKF4ACF60A8D0E43E4


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKF4ACF60AEDBB5DF2]') and parent_object_id = OBJECT_ID(N'PlayoffGame'))
alter table PlayoffGame  drop constraint FKF4ACF60AEDBB5DF2


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC0F3FD16718A7AC4]') and parent_object_id = OBJECT_ID(N'[Player]'))
alter table [Player]  drop constraint FKC0F3FD16718A7AC4


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9984B51BD1A0AE34]') and parent_object_id = OBJECT_ID(N'GamePlayer'))
alter table GamePlayer  drop constraint FK9984B51BD1A0AE34


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9984B51B2C3A96E5]') and parent_object_id = OBJECT_ID(N'GamePlayer'))
alter table GamePlayer  drop constraint FK9984B51B2C3A96E5


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9984B51BDACC4E60]') and parent_object_id = OBJECT_ID(N'GamePlayer'))
alter table GamePlayer  drop constraint FK9984B51BDACC4E60


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9984B51BFEB53D18]') and parent_object_id = OBJECT_ID(N'GamePlayer'))
alter table GamePlayer  drop constraint FK9984B51BFEB53D18


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9984B51B782DA5F3]') and parent_object_id = OBJECT_ID(N'GamePlayer'))
alter table GamePlayer  drop constraint FK9984B51B782DA5F3


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFD5CC5114A8B8FD6]') and parent_object_id = OBJECT_ID(N'[SingleYearTeam]'))
alter table [SingleYearTeam]  drop constraint FKFD5CC5114A8B8FD6


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFD5CC511453A40E2]') and parent_object_id = OBJECT_ID(N'[SingleYearTeam]'))
alter table [SingleYearTeam]  drop constraint FKFD5CC511453A40E2


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD3F9AD4135796475]') and parent_object_id = OBJECT_ID(N'PlayoffTeam'))
alter table PlayoffTeam  drop constraint FKD3F9AD4135796475


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK516C7B9835796475]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FK516C7B9835796475


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK516C7B98B15E8F5A]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FK516C7B98B15E8F5A


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK516C7B982EE9CCE5]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FK516C7B982EE9CCE5


    if exists (select * from dbo.sysobjects where id = object_id(N'[Competition]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [Competition]

    if exists (select * from dbo.sysobjects where id = object_id(N'Playoff') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Playoff

    if exists (select * from dbo.sysobjects where id = object_id(N'Season') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Season

    if exists (select * from dbo.sysobjects where id = object_id(N'[CompetitionConfig]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [CompetitionConfig]

    if exists (select * from dbo.sysobjects where id = object_id(N'PlayoffCompetitionConfig') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table PlayoffCompetitionConfig

    if exists (select * from dbo.sysobjects where id = object_id(N'SeasonCompetitionConfig') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table SeasonCompetitionConfig

    if exists (select * from dbo.sysobjects where id = object_id(N'[CompetitionConfigFinalRankingRule]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [CompetitionConfigFinalRankingRule]

    if exists (select * from dbo.sysobjects where id = object_id(N'SeasonCompetitionConfigFinalRankingRule') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table SeasonCompetitionConfigFinalRankingRule

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

    if exists (select * from dbo.sysobjects where id = object_id(N'[GameData]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [GameData]

    if exists (select * from dbo.sysobjects where id = object_id(N'[Game]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [Game]

    if exists (select * from dbo.sysobjects where id = object_id(N'ScheduleGame') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table ScheduleGame

    if exists (select * from dbo.sysobjects where id = object_id(N'PlayoffGame') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table PlayoffGame

    if exists (select * from dbo.sysobjects where id = object_id(N'[GameRules]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [GameRules]

    if exists (select * from dbo.sysobjects where id = object_id(N'[League]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [League]

    if exists (select * from dbo.sysobjects where id = object_id(N'[Player]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [Player]

    if exists (select * from dbo.sysobjects where id = object_id(N'GamePlayer') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table GamePlayer

    if exists (select * from dbo.sysobjects where id = object_id(N'[PlayerStats]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [PlayerStats]

    if exists (select * from dbo.sysobjects where id = object_id(N'[SingleYearTeam]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [SingleYearTeam]

    if exists (select * from dbo.sysobjects where id = object_id(N'PlayoffTeam') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table PlayoffTeam

    if exists (select * from dbo.sysobjects where id = object_id(N'SeasonTeam') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table SeasonTeam

    if exists (select * from dbo.sysobjects where id = object_id(N'[Team]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [Team]

    create table [Competition] (
        Id BIGINT IDENTITY NOT NULL,
       Name NVARCHAR(255) null,
       Year INT null,
       Started BIT null,
       Finished BIT null,
       StartDay INT null,
       EndDay INT null,
       CreatedBy NVARCHAR(255) null,
       CreatedOn DATETIME2 null,
       LastModifiedBy NVARCHAR(255) null,
       LastModifiedOn DATETIME2 null,
       CompetitionConfig_id BIGINT null,
       primary key (Id)
    )

    create table Playoff (
        Competition_id BIGINT not null,
       CurrentRound INT null,
       primary key (Competition_id)
    )

    create table Season (
        Competition_id BIGINT not null,
       primary key (Competition_id)
    )

    create table [CompetitionConfig] (
        Id BIGINT IDENTITY NOT NULL,
       Name NVARCHAR(255) null,
       Ordering INT null,
       FirstYear INT null,
       LastYear INT null,
       CompetitionStartingDay INT null,
       FinalRankingGroupName NVARCHAR(255) null,
       CreatedBy NVARCHAR(255) null,
       CreatedOn DATETIME2 null,
       LastModifiedBy NVARCHAR(255) null,
       LastModifiedOn DATETIME2 null,
       League_id BIGINT null,
       GameRules_id BIGINT null,
       CompetitionConfig_id BIGINT null,
       primary key (Id)
    )

    create table PlayoffCompetitionConfig (
        CompetitionConfig_id BIGINT not null,
       primary key (CompetitionConfig_id)
    )

    create table SeasonCompetitionConfig (
        CompetitionConfig_id BIGINT not null,
       primary key (CompetitionConfig_id)
    )

    create table [CompetitionConfigFinalRankingRule] (
        Id BIGINT IDENTITY NOT NULL,
       Name NVARCHAR(255) null,
       FirstYear INT null,
       LastYear INT null,
       Rank INT null,
       CreatedBy NVARCHAR(255) null,
       CreatedOn DATETIME2 null,
       LastModifiedBy NVARCHAR(255) null,
       LastModifiedOn DATETIME2 null,
       CompetitionConfig_id BIGINT null,
       primary key (Id)
    )

    create table SeasonCompetitionConfigFinalRankingRule (
        CompetitionConfigFinalRankingRule_id BIGINT not null,
       TeamsComeFromGroup NVARCHAR(255) null,
       StartingRank INT null,
       EndingRank INT null,
       primary key (CompetitionConfigFinalRankingRule_id)
    )

    create table [PlayoffRankingRule] (
        Id BIGINT IDENTITY NOT NULL,
       GroupName NVARCHAR(255) null,
       RankingGroupName NVARCHAR(255) null,
       SourceGroupName NVARCHAR(255) null,
       SourceFirstRank INT null,
       SourceLastRank INT null,
       DestinationFirstRank INT null,
       GroupSetupLevel INT null,
       FirstYear INT null,
       LastYear INT null,
       CreatedBy NVARCHAR(255) null,
       CreatedOn DATETIME2 null,
       LastModifiedBy NVARCHAR(255) null,
       LastModifiedOn DATETIME2 null,
       PlayoffConfig_id BIGINT null,
       primary key (Id)
    )

    create table [PlayoffSeriesRule] (
        Id BIGINT IDENTITY NOT NULL,
       Name NVARCHAR(255) null,
       Round INT null,
       SeriesType NVARCHAR(255) null,
       SeriesNumber INT null,
       HomeFromName NVARCHAR(255) null,
       HomeFromValue INT null,
       AwayFromName NVARCHAR(255) null,
       AwayFromValue INT null,
       FirstYear INT null,
       LastYear INT null,
       HomeGameProgression VARBINARY(MAX) null,
       WinnerGroupName NVARCHAR(255) null,
       WinnerRankFrom NVARCHAR(255) null,
       LoserGroupName NVARCHAR(255) null,
       LoserRankFrom NVARCHAR(255) null,
       CreatedBy NVARCHAR(255) null,
       CreatedOn DATETIME2 null,
       LastModifiedBy NVARCHAR(255) null,
       LastModifiedOn DATETIME2 null,
       PlayoffConfig_id BIGINT null,
       GameRules_id BIGINT null,
       primary key (Id)
    )

    create table [SeasonDivisionRule] (
        Id BIGINT IDENTITY NOT NULL,
       DivisionName NVARCHAR(255) null,
       Level INT null,
       Ordering INT null,
       FirstYear INT null,
       LastYear INT null,
       CreatedBy NVARCHAR(255) null,
       CreatedOn DATETIME2 null,
       LastModifiedBy NVARCHAR(255) null,
       LastModifiedOn DATETIME2 null,
       Competition_id BIGINT null,
       Parent_id BIGINT null,
       primary key (Id)
    )

    create table [SeasonScheduleRule] (
        Id BIGINT IDENTITY NOT NULL,
       Iterations INT null,
       HomeAndAway BIT null,
       FirstYear INT null,
       LastYear INT null,
       CreatedBy NVARCHAR(255) null,
       CreatedOn DATETIME2 null,
       LastModifiedBy NVARCHAR(255) null,
       LastModifiedOn DATETIME2 null,
       Competition_id BIGINT null,
       HomeTeam_id BIGINT null,
       HomeDivisionRule_id BIGINT null,
       AwayTeam_id BIGINT null,
       AwayDivisionRule_id BIGINT null,
       primary key (Id)
    )

    create table [SeasonTeamRule] (
        Id BIGINT IDENTITY NOT NULL,
       FirstYear INT null,
       LastYear INT null,
       CreatedBy NVARCHAR(255) null,
       CreatedOn DATETIME2 null,
       LastModifiedBy NVARCHAR(255) null,
       LastModifiedOn DATETIME2 null,
       Competition_id BIGINT null,
       Team_id BIGINT null,
       Division_id BIGINT null,
       primary key (Id)
    )

    create table [PlayoffSeries] (
        Id BIGINT IDENTITY NOT NULL,
       Name NVARCHAR(255) null,
       Round INT null,
       StartingDay INT null,
       HomeGameProgression VARBINARY(MAX) null,
       CreatedBy NVARCHAR(255) null,
       CreatedOn DATETIME2 null,
       LastModifiedBy NVARCHAR(255) null,
       LastModifiedOn DATETIME2 null,
       Playoff_id BIGINT null,
       HomeTeam_id BIGINT null,
       AwayTeam_id BIGINT null,
       primary key (Id)
    )

    create table BestOfSeries (
        PlayoffSeries_id BIGINT not null,
       HomeWins INT null,
       AwayWins INT null,
       RequiredWins INT null,
       primary key (PlayoffSeries_id)
    )

    create table TotalGoalsSeries (
        PlayoffSeries_id BIGINT not null,
       GamesPlayed INT null,
       HomeScore INT null,
       AwayScore INT null,
       MinimumGames INT null,
       primary key (PlayoffSeries_id)
    )

    create table [SeasonDivision] (
        Id BIGINT IDENTITY NOT NULL,
       Year INT null,
       Name NVARCHAR(255) null,
       Level INT null,
       Ordering INT null,
       CreatedBy NVARCHAR(255) null,
       CreatedOn DATETIME2 null,
       LastModifiedBy NVARCHAR(255) null,
       LastModifiedOn DATETIME2 null,
       Season_id BIGINT null,
       ParentDivision_id BIGINT null,
       primary key (Id)
    )

    create table [SeasonTeamStats] (
        Id BIGINT IDENTITY NOT NULL,
       Wins INT null,
       Loses INT null,
       Ties INT null,
       GoalsFor INT null,
       GoalsAgainst INT null,
       CreatedBy NVARCHAR(255) null,
       CreatedOn DATETIME2 null,
       LastModifiedBy NVARCHAR(255) null,
       LastModifiedOn DATETIME2 null,
       primary key (Id)
    )

    create table [TeamRanking] (
        Id BIGINT IDENTITY NOT NULL,
       Rank INT null,
       GroupName NVARCHAR(255) null,
       GroupLevel INT null,
       CreatedBy NVARCHAR(255) null,
       CreatedOn DATETIME2 null,
       LastModifiedBy NVARCHAR(255) null,
       LastModifiedOn DATETIME2 null,
       SingleYearTeam_id BIGINT null,
       Competition_id BIGINT null,
       primary key (Id)
    )

    create table [GameData] (
        Id BIGINT IDENTITY NOT NULL,
       CurrentYear INT null,
       CurrentDay INT null,
       CreatedBy NVARCHAR(255) null,
       CreatedOn DATETIME2 null,
       LastModifiedBy NVARCHAR(255) null,
       LastModifiedOn DATETIME2 null,
       primary key (Id)
    )

    create table [Game] (
        Id BIGINT IDENTITY NOT NULL,
       HomeScore INT null,
       AwayScore INT null,
       Complete BIT null,
       CurrentPeriod INT null,
       CreatedBy NVARCHAR(255) null,
       CreatedOn DATETIME2 null,
       LastModifiedBy NVARCHAR(255) null,
       LastModifiedOn DATETIME2 null,
       HomeTeam_id BIGINT null,
       AwayTeam_id BIGINT null,
       Rules_id BIGINT null,
       primary key (Id)
    )

    create table ScheduleGame (
        Game_id BIGINT not null,
       GameNumber INT null,
       Day INT null,
       Year INT null,
       Processed BIT null,
       Competition_id BIGINT null,
       primary key (Game_id)
    )

    create table PlayoffGame (
        ScheduleGame_id BIGINT not null,
       Series_id BIGINT null,
       primary key (ScheduleGame_id)
    )

    create table [GameRules] (
        Id BIGINT IDENTITY NOT NULL,
       Name NVARCHAR(255) null,
       CanTie BIT null,
       MaxOverTimePeriods INT null,
       MinimumPeriods INT null,
       HomeRange INT null,
       AwayRange INT null,
       CreatedBy NVARCHAR(255) null,
       CreatedOn DATETIME2 null,
       LastModifiedBy NVARCHAR(255) null,
       LastModifiedOn DATETIME2 null,
       primary key (Id)
    )

    create table [League] (
        Id BIGINT IDENTITY NOT NULL,
       Name NVARCHAR(255) null,
       FirstYear INT null,
       LastYear INT null,
       CreatedBy NVARCHAR(255) null,
       CreatedOn DATETIME2 null,
       LastModifiedBy NVARCHAR(255) null,
       LastModifiedOn DATETIME2 null,
       primary key (Id)
    )

    create table [Player] (
        Id BIGINT IDENTITY NOT NULL,
       Name NVARCHAR(255) null,
       Age INT null,
       Offense INT null,
       Defense INT null,
       Goaltending INT null,
       FirstYear INT null,
       LastYear INT null,
       CreatedBy NVARCHAR(255) null,
       CreatedOn DATETIME2 null,
       LastModifiedBy NVARCHAR(255) null,
       LastModifiedOn DATETIME2 null,
       CurrentTeam_id BIGINT null,
       primary key (Id)
    )

    create table GamePlayer (
        Player_id BIGINT not null,
       Game_id BIGINT null,
       Parent_id BIGINT null,
       Stats_id BIGINT null,
       Team_id BIGINT null,
       primary key (Player_id)
    )

    create table [PlayerStats] (
        Id BIGINT IDENTITY NOT NULL,
       FaceOffsWon INT null,
       FaceOffsLoses INT null,
       CarrySuccess INT null,
       CarryFail INT null,
       CheckingSuccess INT null,
       CheckingFail INT null,
       ShotsOnGoal INT null,
       ShotsBlocked INT null,
       BlockingSuccess INT null,
       BlockingFail INT null,
       Goals INT null,
       Assists INT null,
       Saves INT null,
       GoalsAgainst INT null,
       PassSuccess INT null,
       PassFail INT null,
       PassReceived INT null,
       PassMissed INT null,
       InterceptionSuccess INT null,
       InterceptionFail INT null,
       CoverSuccess INT null,
       CoverFail INT null,
       Rebounds INT null,
       GamesPlayed INT null,
       Wins INT null,
       Loses INT null,
       Ties INT null,
       CreatedBy NVARCHAR(255) null,
       CreatedOn DATETIME2 null,
       LastModifiedBy NVARCHAR(255) null,
       LastModifiedOn DATETIME2 null,
       primary key (Id)
    )

    create table [SingleYearTeam] (
        Id BIGINT IDENTITY NOT NULL,
       Name NVARCHAR(255) null,
       NickName NVARCHAR(255) null,
       ShortName NVARCHAR(255) null,
       Skill INT null,
       Owner NVARCHAR(255) null,
       FirstYear INT null,
       LastYear INT null,
       CreatedBy NVARCHAR(255) null,
       CreatedOn DATETIME2 null,
       LastModifiedBy NVARCHAR(255) null,
       LastModifiedOn DATETIME2 null,
       Competition_id BIGINT null,
       Parent_id BIGINT null,
       primary key (Id)
    )

    create table PlayoffTeam (
        SingleYearTeam_id BIGINT not null,
       primary key (SingleYearTeam_id)
    )

    create table SeasonTeam (
        SingleYearTeam_id BIGINT not null,
       Division_id BIGINT null,
       Stats_id BIGINT null,
       primary key (SingleYearTeam_id)
    )

    create table [Team] (
        Id BIGINT IDENTITY NOT NULL,
       Name NVARCHAR(255) null,
       NickName NVARCHAR(255) null,
       ShortName NVARCHAR(255) null,
       Skill INT null,
       Owner NVARCHAR(255) null,
       FirstYear INT null,
       LastYear INT null,
       Active BIT null,
       Wins INT null,
       Loses INT null,
       Ties INT null,
       GoalsFor INT null,
       GoalsAgainst INT null,
       CreatedBy NVARCHAR(255) null,
       CreatedOn DATETIME2 null,
       LastModifiedBy NVARCHAR(255) null,
       LastModifiedOn DATETIME2 null,
       primary key (Id)
    )

    alter table [Competition] 
        add constraint FK2DFF6FDCB415A475 
        foreign key (CompetitionConfig_id) 
        references [CompetitionConfig]

    alter table Playoff 
        add constraint FK1FFB23F34A8B8FD6 
        foreign key (Competition_id) 
        references [Competition]

    alter table Season 
        add constraint FKB6B78D8D4A8B8FD6 
        foreign key (Competition_id) 
        references [Competition]

    alter table [CompetitionConfig] 
        add constraint FK249D08C248DBBC5F 
        foreign key (League_id) 
        references [League]

    alter table [CompetitionConfig] 
        add constraint FK249D08C2F079C384 
        foreign key (GameRules_id) 
        references [GameRules]

    alter table [CompetitionConfig] 
        add constraint FK249D08C2B415A475 
        foreign key (CompetitionConfig_id) 
        references [CompetitionConfig]

    alter table PlayoffCompetitionConfig 
        add constraint FKD9348682B415A475 
        foreign key (CompetitionConfig_id) 
        references [CompetitionConfig]

    alter table SeasonCompetitionConfig 
        add constraint FKDDA800A4B415A475 
        foreign key (CompetitionConfig_id) 
        references [CompetitionConfig]

    alter table [CompetitionConfigFinalRankingRule] 
        add constraint FK8CEDA121B415A475 
        foreign key (CompetitionConfig_id) 
        references [CompetitionConfig]

    alter table SeasonCompetitionConfigFinalRankingRule 
        add constraint FKEB0C0F1C7A50BC11 
        foreign key (CompetitionConfigFinalRankingRule_id) 
        references [CompetitionConfigFinalRankingRule]

    alter table [PlayoffRankingRule] 
        add constraint FKE718A32C5189803B 
        foreign key (PlayoffConfig_id) 
        references PlayoffCompetitionConfig

    alter table [PlayoffSeriesRule] 
        add constraint FK80F2B8CC5189803B 
        foreign key (PlayoffConfig_id) 
        references PlayoffCompetitionConfig

    alter table [PlayoffSeriesRule] 
        add constraint FK80F2B8CCF079C384 
        foreign key (GameRules_id) 
        references [GameRules]

    alter table [SeasonDivisionRule] 
        add constraint FK38AF1BA0DCFB6B9B 
        foreign key (Competition_id) 
        references SeasonCompetitionConfig

    alter table [SeasonDivisionRule] 
        add constraint FK38AF1BA09C437384 
        foreign key (Parent_id) 
        references [SeasonDivisionRule]

    alter table [SeasonScheduleRule] 
        add constraint FK4A3EA11BDCFB6B9B 
        foreign key (Competition_id) 
        references SeasonCompetitionConfig

    alter table [SeasonScheduleRule] 
        add constraint FK4A3EA11BC3401D7B 
        foreign key (HomeTeam_id) 
        references [Team]

    alter table [SeasonScheduleRule] 
        add constraint FK4A3EA11B38182332 
        foreign key (HomeDivisionRule_id) 
        references [SeasonDivisionRule]

    alter table [SeasonScheduleRule] 
        add constraint FK4A3EA11B6F196E85 
        foreign key (AwayTeam_id) 
        references [Team]

    alter table [SeasonScheduleRule] 
        add constraint FK4A3EA11B690BAEF 
        foreign key (AwayDivisionRule_id) 
        references [SeasonDivisionRule]

    alter table [SeasonTeamRule] 
        add constraint FKE8DCC500DCFB6B9B 
        foreign key (Competition_id) 
        references SeasonCompetitionConfig

    alter table [SeasonTeamRule] 
        add constraint FKE8DCC500782DA5F3 
        foreign key (Team_id) 
        references [Team]

    alter table [SeasonTeamRule] 
        add constraint FKE8DCC500BB3A4007 
        foreign key (Division_id) 
        references [SeasonDivisionRule]

    alter table [PlayoffSeries] 
        add constraint FK3D5354F412FB810C 
        foreign key (Playoff_id) 
        references Playoff

    alter table [PlayoffSeries] 
        add constraint FK3D5354F4A69CBCAA 
        foreign key (HomeTeam_id) 
        references PlayoffTeam

    alter table [PlayoffSeries] 
        add constraint FK3D5354F4AC5CF54 
        foreign key (AwayTeam_id) 
        references PlayoffTeam

    alter table BestOfSeries 
        add constraint FK95E91038B035AA0C 
        foreign key (PlayoffSeries_id) 
        references [PlayoffSeries]

    alter table TotalGoalsSeries 
        add constraint FK317EFE97B035AA0C 
        foreign key (PlayoffSeries_id) 
        references [PlayoffSeries]

    alter table [SeasonDivision] 
        add constraint FKA8F5178882804EE9 
        foreign key (Season_id) 
        references Season

    alter table [SeasonDivision] 
        add constraint FKA8F517881A7A340 
        foreign key (ParentDivision_id) 
        references [SeasonDivision]

    alter table [TeamRanking] 
        add constraint FK7FACEAA135796475 
        foreign key (SingleYearTeam_id) 
        references [SingleYearTeam]

    alter table [TeamRanking] 
        add constraint FK7FACEAA14A8B8FD6 
        foreign key (Competition_id) 
        references [Competition]

    alter table [Game] 
        add constraint FKFC5CA3F2C3401D7B 
        foreign key (HomeTeam_id) 
        references [Team]

    alter table [Game] 
        add constraint FKFC5CA3F26F196E85 
        foreign key (AwayTeam_id) 
        references [Team]

    alter table [Game] 
        add constraint FKFC5CA3F2D29F1A0F 
        foreign key (Rules_id) 
        references [GameRules]

    alter table ScheduleGame 
        add constraint FKD6B153DC2C3A96E5 
        foreign key (Game_id) 
        references [Game]

    alter table ScheduleGame 
        add constraint FKD6B153DC4A8B8FD6 
        foreign key (Competition_id) 
        references [Competition]

    alter table PlayoffGame 
        add constraint FKF4ACF60A8D0E43E4 
        foreign key (ScheduleGame_id) 
        references ScheduleGame

    alter table PlayoffGame 
        add constraint FKF4ACF60AEDBB5DF2 
        foreign key (Series_id) 
        references [PlayoffSeries]

    alter table [Player] 
        add constraint FKC0F3FD16718A7AC4 
        foreign key (CurrentTeam_id) 
        references [Team]

    alter table GamePlayer 
        add constraint FK9984B51BD1A0AE34 
        foreign key (Player_id) 
        references [Player]

    alter table GamePlayer 
        add constraint FK9984B51B2C3A96E5 
        foreign key (Game_id) 
        references [Game]

    alter table GamePlayer 
        add constraint FK9984B51BDACC4E60 
        foreign key (Parent_id) 
        references [Player]

    alter table GamePlayer 
        add constraint FK9984B51BFEB53D18 
        foreign key (Stats_id) 
        references [PlayerStats]

    alter table GamePlayer 
        add constraint FK9984B51B782DA5F3 
        foreign key (Team_id) 
        references [Team]

    alter table [SingleYearTeam] 
        add constraint FKFD5CC5114A8B8FD6 
        foreign key (Competition_id) 
        references [Competition]

    alter table [SingleYearTeam] 
        add constraint FKFD5CC511453A40E2 
        foreign key (Parent_id) 
        references [Team]

    alter table PlayoffTeam 
        add constraint FKD3F9AD4135796475 
        foreign key (SingleYearTeam_id) 
        references [SingleYearTeam]

    alter table SeasonTeam 
        add constraint FK516C7B9835796475 
        foreign key (SingleYearTeam_id) 
        references [SingleYearTeam]

    alter table SeasonTeam 
        add constraint FK516C7B98B15E8F5A 
        foreign key (Division_id) 
        references [SeasonDivision]

    alter table SeasonTeam 
        add constraint FK516C7B982EE9CCE5 
        foreign key (Stats_id) 
        references [SeasonTeamStats]

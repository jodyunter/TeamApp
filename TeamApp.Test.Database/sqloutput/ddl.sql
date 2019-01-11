
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD0F619DF43CCC130]') and parent_object_id = OBJECT_ID(N'[Competition]'))
alter table [Competition]  drop constraint FKD0F619DF43CCC130


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKA0E4CF02EDFB7772]') and parent_object_id = OBJECT_ID(N'Playoff'))
alter table Playoff  drop constraint FKA0E4CF02EDFB7772


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK79ECA831EDFB7772]') and parent_object_id = OBJECT_ID(N'Season'))
alter table Season  drop constraint FK79ECA831EDFB7772


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKEB095BDA8F494224]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FKEB095BDA8F494224


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKEB095BDA262EFB4D]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FKEB095BDA262EFB4D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKEB095BDA43CCC130]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FKEB095BDA43CCC130


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKDF10770743CCC130]') and parent_object_id = OBJECT_ID(N'PlayoffCompetitionConfig'))
alter table PlayoffCompetitionConfig  drop constraint FKDF10770743CCC130


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKEE61AC0D43CCC130]') and parent_object_id = OBJECT_ID(N'SeasonCompetitionConfig'))
alter table SeasonCompetitionConfig  drop constraint FKEE61AC0D43CCC130


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6261C9DC631DF43B]') and parent_object_id = OBJECT_ID(N'[PlayoffRankingRule]'))
alter table [PlayoffRankingRule]  drop constraint FK6261C9DC631DF43B


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6261C9DCCBCFC67B]') and parent_object_id = OBJECT_ID(N'[PlayoffRankingRule]'))
alter table [PlayoffRankingRule]  drop constraint FK6261C9DCCBCFC67B


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK913B846E631DF43B]') and parent_object_id = OBJECT_ID(N'[PlayoffSeriesRule]'))
alter table [PlayoffSeriesRule]  drop constraint FK913B846E631DF43B


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK913B846E262EFB4D]') and parent_object_id = OBJECT_ID(N'[PlayoffSeriesRule]'))
alter table [PlayoffSeriesRule]  drop constraint FK913B846E262EFB4D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKE23C5E88DE0D1E46]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FKE23C5E88DE0D1E46


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKE23C5E88E988B454]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FKE23C5E88E988B454


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKE23C5E88752D794E]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FKE23C5E88752D794E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8CE2ABF813D14077]') and parent_object_id = OBJECT_ID(N'BestOfSeries'))
alter table BestOfSeries  drop constraint FK8CE2ABF813D14077


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKBD287C1613D14077]') and parent_object_id = OBJECT_ID(N'TotalGoalsSeries'))
alter table TotalGoalsSeries  drop constraint FKBD287C1613D14077


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKF444F5233CF71D02]') and parent_object_id = OBJECT_ID(N'[SeasonDivisionRule]'))
alter table [SeasonDivisionRule]  drop constraint FKF444F5233CF71D02


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKEDC4590A3CF71D02]') and parent_object_id = OBJECT_ID(N'[SeasonScheduleRule]'))
alter table [SeasonScheduleRule]  drop constraint FKEDC4590A3CF71D02


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKE88CDD6F3CF71D02]') and parent_object_id = OBJECT_ID(N'[SeasonTeamRule]'))
alter table [SeasonTeamRule]  drop constraint FKE88CDD6F3CF71D02


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKE88CDD6F99D92040]') and parent_object_id = OBJECT_ID(N'[SeasonTeamRule]'))
alter table [SeasonTeamRule]  drop constraint FKE88CDD6F99D92040


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK74003C4FE35F9E02]') and parent_object_id = OBJECT_ID(N'[SeasonDivision]'))
alter table [SeasonDivision]  drop constraint FK74003C4FE35F9E02


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK74003C4F1DF89C36]') and parent_object_id = OBJECT_ID(N'[SeasonDivision]'))
alter table [SeasonDivision]  drop constraint FK74003C4F1DF89C36


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK56474BA02D102EBF]') and parent_object_id = OBJECT_ID(N'[TeamRanking]'))
alter table [TeamRanking]  drop constraint FK56474BA02D102EBF


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK56474BA0EDFB7772]') and parent_object_id = OBJECT_ID(N'[TeamRanking]'))
alter table [TeamRanking]  drop constraint FK56474BA0EDFB7772


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6BA3485D1CFD4DB4]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FK6BA3485D1CFD4DB4


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6BA3485D805880AE]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FK6BA3485D805880AE


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6BA3485D129C143B]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FK6BA3485D129C143B


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKF8585C701310B7A]') and parent_object_id = OBJECT_ID(N'ScheduleGame'))
alter table ScheduleGame  drop constraint FKF8585C701310B7A


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKF8585C70EDFB7772]') and parent_object_id = OBJECT_ID(N'ScheduleGame'))
alter table ScheduleGame  drop constraint FKF8585C70EDFB7772


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK55978784CCF0848]') and parent_object_id = OBJECT_ID(N'PlayoffGame'))
alter table PlayoffGame  drop constraint FK55978784CCF0848


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5597878458B93306]') and parent_object_id = OBJECT_ID(N'PlayoffGame'))
alter table PlayoffGame  drop constraint FK5597878458B93306


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD8489921EDFB7772]') and parent_object_id = OBJECT_ID(N'[SingleYearTeam]'))
alter table [SingleYearTeam]  drop constraint FKD8489921EDFB7772


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD8489921A4CB9371]') and parent_object_id = OBJECT_ID(N'[SingleYearTeam]'))
alter table [SingleYearTeam]  drop constraint FKD8489921A4CB9371


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKEB8C8DC3D4B3661A]') and parent_object_id = OBJECT_ID(N'PlayoffTeam'))
alter table PlayoffTeam  drop constraint FKEB8C8DC3D4B3661A


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFB79B8F1D4B3661A]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FKFB79B8F1D4B3661A


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFB79B8F136C5E43B]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FKFB79B8F136C5E43B


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFB79B8F12B74C062]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FKFB79B8F12B74C062


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

    create table [Competition] (
        Id BIGINT IDENTITY NOT NULL,
       Name NVARCHAR(255) null,
       Year INT null,
       CreatedBy NVARCHAR(255) null,
       CreatedOn DATETIME2 null,
       LastModifiedBy NVARCHAR(255) null,
       LastModifiedOn DATETIME2 null,
       CompetitionConfig_id BIGINT null,
       primary key (Id)
    )

    create table Playoff (
        Competition_id BIGINT not null,
       StartingDay INT null,
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

    create table [PlayoffRankingRule] (
        Id BIGINT IDENTITY NOT NULL,
       GroupName NVARCHAR(255) null,
       StartingRank INT null,
       SourceGroupName NVARCHAR(255) null,
       SourceFirstRank INT null,
       SourceLastRank INT null,
       CreatedBy NVARCHAR(255) null,
       CreatedOn DATETIME2 null,
       LastModifiedBy NVARCHAR(255) null,
       LastModifiedOn DATETIME2 null,
       PlayoffConfig_id BIGINT null,
       SourceCompetition_id BIGINT null,
       primary key (Id)
    )

    create table [PlayoffSeriesRule] (
        Id BIGINT IDENTITY NOT NULL,
       Name NVARCHAR(255) null,
       Round INT null,
       SeriesType INT null,
       SeriesNumber INT null,
       HomeFromType INT null,
       HomeFromName NVARCHAR(255) null,
       HomeFromValue INT null,
       AwayFromType INT null,
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

    create table [SeasonDivisionRule] (
        Id BIGINT IDENTITY NOT NULL,
       DivisionName NVARCHAR(255) null,
       ParentName NVARCHAR(255) null,
       Level INT null,
       Ordering INT null,
       FirstYear INT null,
       LastYear INT null,
       CreatedBy NVARCHAR(255) null,
       CreatedOn DATETIME2 null,
       LastModifiedBy NVARCHAR(255) null,
       LastModifiedOn DATETIME2 null,
       Competition_id BIGINT null,
       primary key (Id)
    )

    create table [SeasonScheduleRule] (
        Id BIGINT IDENTITY NOT NULL,
       HomeTeamType INT null,
       HomeTeamValue NVARCHAR(255) null,
       AwayTeamType INT null,
       AwayTeamValue NVARCHAR(255) null,
       Iterations INT null,
       HomeAndAway BIT null,
       FirstYear INT null,
       LastYear INT null,
       CreatedBy NVARCHAR(255) null,
       CreatedOn DATETIME2 null,
       LastModifiedBy NVARCHAR(255) null,
       LastModifiedOn DATETIME2 null,
       Competition_id BIGINT null,
       primary key (Id)
    )

    create table [SeasonTeamRule] (
        Id BIGINT IDENTITY NOT NULL,
       Division NVARCHAR(255) null,
       FirstYear INT null,
       LastYear INT null,
       CreatedBy NVARCHAR(255) null,
       CreatedOn DATETIME2 null,
       LastModifiedBy NVARCHAR(255) null,
       LastModifiedOn DATETIME2 null,
       Competition_id BIGINT null,
       Team_id BIGINT null,
       primary key (Id)
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
       Team_id BIGINT null,
       Competition_id BIGINT null,
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
       FirstYear INT null,
       LastYear INT null,
       Name NVARCHAR(255) null,
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
       CreatedBy NVARCHAR(255) null,
       CreatedOn DATETIME2 null,
       LastModifiedBy NVARCHAR(255) null,
       LastModifiedOn DATETIME2 null,
       primary key (Id)
    )

    alter table [Competition] 
        add constraint FKD0F619DF43CCC130 
        foreign key (CompetitionConfig_id) 
        references [CompetitionConfig]

    alter table Playoff 
        add constraint FKA0E4CF02EDFB7772 
        foreign key (Competition_id) 
        references [Competition]

    alter table Season 
        add constraint FK79ECA831EDFB7772 
        foreign key (Competition_id) 
        references [Competition]

    alter table [CompetitionConfig] 
        add constraint FKEB095BDA8F494224 
        foreign key (League_id) 
        references [League]

    alter table [CompetitionConfig] 
        add constraint FKEB095BDA262EFB4D 
        foreign key (GameRules_id) 
        references [GameRules]

    alter table [CompetitionConfig] 
        add constraint FKEB095BDA43CCC130 
        foreign key (CompetitionConfig_id) 
        references [CompetitionConfig]

    alter table PlayoffCompetitionConfig 
        add constraint FKDF10770743CCC130 
        foreign key (CompetitionConfig_id) 
        references [CompetitionConfig]

    alter table SeasonCompetitionConfig 
        add constraint FKEE61AC0D43CCC130 
        foreign key (CompetitionConfig_id) 
        references [CompetitionConfig]

    alter table [PlayoffRankingRule] 
        add constraint FK6261C9DC631DF43B 
        foreign key (PlayoffConfig_id) 
        references PlayoffCompetitionConfig

    alter table [PlayoffRankingRule] 
        add constraint FK6261C9DCCBCFC67B 
        foreign key (SourceCompetition_id) 
        references [CompetitionConfig]

    alter table [PlayoffSeriesRule] 
        add constraint FK913B846E631DF43B 
        foreign key (PlayoffConfig_id) 
        references PlayoffCompetitionConfig

    alter table [PlayoffSeriesRule] 
        add constraint FK913B846E262EFB4D 
        foreign key (GameRules_id) 
        references [GameRules]

    alter table [PlayoffSeries] 
        add constraint FKE23C5E88DE0D1E46 
        foreign key (Playoff_id) 
        references Playoff

    alter table [PlayoffSeries] 
        add constraint FKE23C5E88E988B454 
        foreign key (HomeTeam_id) 
        references PlayoffTeam

    alter table [PlayoffSeries] 
        add constraint FKE23C5E88752D794E 
        foreign key (AwayTeam_id) 
        references PlayoffTeam

    alter table BestOfSeries 
        add constraint FK8CE2ABF813D14077 
        foreign key (PlayoffSeries_id) 
        references [PlayoffSeries]

    alter table TotalGoalsSeries 
        add constraint FKBD287C1613D14077 
        foreign key (PlayoffSeries_id) 
        references [PlayoffSeries]

    alter table [SeasonDivisionRule] 
        add constraint FKF444F5233CF71D02 
        foreign key (Competition_id) 
        references SeasonCompetitionConfig

    alter table [SeasonScheduleRule] 
        add constraint FKEDC4590A3CF71D02 
        foreign key (Competition_id) 
        references SeasonCompetitionConfig

    alter table [SeasonTeamRule] 
        add constraint FKE88CDD6F3CF71D02 
        foreign key (Competition_id) 
        references SeasonCompetitionConfig

    alter table [SeasonTeamRule] 
        add constraint FKE88CDD6F99D92040 
        foreign key (Team_id) 
        references [Team]

    alter table [SeasonDivision] 
        add constraint FK74003C4FE35F9E02 
        foreign key (Season_id) 
        references Season

    alter table [SeasonDivision] 
        add constraint FK74003C4F1DF89C36 
        foreign key (ParentDivision_id) 
        references [SeasonDivision]

    alter table [TeamRanking] 
        add constraint FK56474BA02D102EBF 
        foreign key (Team_id) 
        references [SingleYearTeam]

    alter table [TeamRanking] 
        add constraint FK56474BA0EDFB7772 
        foreign key (Competition_id) 
        references [Competition]

    alter table [Game] 
        add constraint FK6BA3485D1CFD4DB4 
        foreign key (HomeTeam_id) 
        references [Team]

    alter table [Game] 
        add constraint FK6BA3485D805880AE 
        foreign key (AwayTeam_id) 
        references [Team]

    alter table [Game] 
        add constraint FK6BA3485D129C143B 
        foreign key (Rules_id) 
        references [GameRules]

    alter table ScheduleGame 
        add constraint FKF8585C701310B7A 
        foreign key (Game_id) 
        references [Game]

    alter table ScheduleGame 
        add constraint FKF8585C70EDFB7772 
        foreign key (Competition_id) 
        references [Competition]

    alter table PlayoffGame 
        add constraint FK55978784CCF0848 
        foreign key (ScheduleGame_id) 
        references ScheduleGame

    alter table PlayoffGame 
        add constraint FK5597878458B93306 
        foreign key (Series_id) 
        references [PlayoffSeries]

    alter table [SingleYearTeam] 
        add constraint FKD8489921EDFB7772 
        foreign key (Competition_id) 
        references [Competition]

    alter table [SingleYearTeam] 
        add constraint FKD8489921A4CB9371 
        foreign key (Parent_id) 
        references [Team]

    alter table PlayoffTeam 
        add constraint FKEB8C8DC3D4B3661A 
        foreign key (SingleYearTeam_id) 
        references [SingleYearTeam]

    alter table SeasonTeam 
        add constraint FKFB79B8F1D4B3661A 
        foreign key (SingleYearTeam_id) 
        references [SingleYearTeam]

    alter table SeasonTeam 
        add constraint FKFB79B8F136C5E43B 
        foreign key (Division_id) 
        references [SeasonDivision]

    alter table SeasonTeam 
        add constraint FKFB79B8F12B74C062 
        foreign key (Stats_id) 
        references [SeasonTeamStats]

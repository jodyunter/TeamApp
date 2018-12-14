
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKCAE220877B9FB10E]') and parent_object_id = OBJECT_ID(N'[Competition]'))
alter table [Competition]  drop constraint FKCAE220877B9FB10E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK70FD8E70AEEB0F74]') and parent_object_id = OBJECT_ID(N'Playoff'))
alter table Playoff  drop constraint FK70FD8E70AEEB0F74


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK87D6FE8EAEEB0F74]') and parent_object_id = OBJECT_ID(N'Season'))
alter table Season  drop constraint FK87D6FE8EAEEB0F74


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8AE6379F347D923]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FK8AE6379F347D923


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8AE6379D63442F6]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FK8AE6379D63442F6


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8AE63797B9FB10E]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FK8AE63797B9FB10E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD86215377B9FB10E]') and parent_object_id = OBJECT_ID(N'PlayoffCompetitionConfig'))
alter table PlayoffCompetitionConfig  drop constraint FKD86215377B9FB10E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK702B00017B9FB10E]') and parent_object_id = OBJECT_ID(N'SeasonCompetitionConfig'))
alter table SeasonCompetitionConfig  drop constraint FK702B00017B9FB10E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKE935B59E258B9CD]') and parent_object_id = OBJECT_ID(N'[PlayoffRankingRule]'))
alter table [PlayoffRankingRule]  drop constraint FKE935B59E258B9CD


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKE935B59EEFAE44F0]') and parent_object_id = OBJECT_ID(N'[PlayoffRankingRule]'))
alter table [PlayoffRankingRule]  drop constraint FKE935B59EEFAE44F0


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKADF48EA5258B9CD]') and parent_object_id = OBJECT_ID(N'[PlayoffSeriesRule]'))
alter table [PlayoffSeriesRule]  drop constraint FKADF48EA5258B9CD


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKADF48EA5D63442F6]') and parent_object_id = OBJECT_ID(N'[PlayoffSeriesRule]'))
alter table [PlayoffSeriesRule]  drop constraint FKADF48EA5D63442F6


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8C50325A1E61C4]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FK8C50325A1E61C4


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8C50325AAA3EA50E]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FK8C50325AAA3EA50E


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8C50325AF3B56F84]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FK8C50325AF3B56F84


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK3F2DAE359C52C6F6]') and parent_object_id = OBJECT_ID(N'BestOfSeries'))
alter table BestOfSeries  drop constraint FK3F2DAE359C52C6F6


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK807A54E9C52C6F6]') and parent_object_id = OBJECT_ID(N'TotalGoalsSeries'))
alter table TotalGoalsSeries  drop constraint FK807A54E9C52C6F6


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5D79E78CA3D47D2A]') and parent_object_id = OBJECT_ID(N'[SeasonDivisionRule]'))
alter table [SeasonDivisionRule]  drop constraint FK5D79E78CA3D47D2A


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKE1A3C1A6A3D47D2A]') and parent_object_id = OBJECT_ID(N'[SeasonScheduleRule]'))
alter table [SeasonScheduleRule]  drop constraint FKE1A3C1A6A3D47D2A


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK95A69050A3D47D2A]') and parent_object_id = OBJECT_ID(N'[SeasonTeamRule]'))
alter table [SeasonTeamRule]  drop constraint FK95A69050A3D47D2A


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK95A69050973AA0AB]') and parent_object_id = OBJECT_ID(N'[SeasonTeamRule]'))
alter table [SeasonTeamRule]  drop constraint FK95A69050973AA0AB


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6D0C7DA8248CF50]') and parent_object_id = OBJECT_ID(N'[SeasonDivision]'))
alter table [SeasonDivision]  drop constraint FK6D0C7DA8248CF50


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6D0C7DA866AF732D]') and parent_object_id = OBJECT_ID(N'[SeasonDivision]'))
alter table [SeasonDivision]  drop constraint FK6D0C7DA866AF732D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFC7E20F6CF5A11FA]') and parent_object_id = OBJECT_ID(N'[TeamRanking]'))
alter table [TeamRanking]  drop constraint FKFC7E20F6CF5A11FA


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFC7E20F6AEEB0F74]') and parent_object_id = OBJECT_ID(N'[TeamRanking]'))
alter table [TeamRanking]  drop constraint FKFC7E20F6AEEB0F74


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKB46CD18A8589315C]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FKB46CD18A8589315C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKB46CD18ADC02FBD6]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FKB46CD18ADC02FBD6


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKB46CD18AA8C53C82]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FKB46CD18AA8C53C82


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKA742947837122A5F]') and parent_object_id = OBJECT_ID(N'ScheduleGame'))
alter table ScheduleGame  drop constraint FKA742947837122A5F


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKA7429478AEEB0F74]') and parent_object_id = OBJECT_ID(N'ScheduleGame'))
alter table ScheduleGame  drop constraint FKA7429478AEEB0F74


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK1B310BA9B017421F]') and parent_object_id = OBJECT_ID(N'PlayoffGame'))
alter table PlayoffGame  drop constraint FK1B310BA9B017421F


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK1B310BA9A972680D]') and parent_object_id = OBJECT_ID(N'PlayoffGame'))
alter table PlayoffGame  drop constraint FK1B310BA9A972680D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9E509A31AEEB0F74]') and parent_object_id = OBJECT_ID(N'[SingleYearTeam]'))
alter table [SingleYearTeam]  drop constraint FK9E509A31AEEB0F74


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9E509A31B0F19ABC]') and parent_object_id = OBJECT_ID(N'[SingleYearTeam]'))
alter table [SingleYearTeam]  drop constraint FK9E509A31B0F19ABC


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK39052534FBA224B0]') and parent_object_id = OBJECT_ID(N'PlayoffTeam'))
alter table PlayoffTeam  drop constraint FK39052534FBA224B0


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKBB47D4EFFBA224B0]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FKBB47D4EFFBA224B0


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKBB47D4EF598DE0A6]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FKBB47D4EF598DE0A6


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKBB47D4EF9468A261]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FKBB47D4EF9468A261


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
        add constraint FKCAE220877B9FB10E 
        foreign key (CompetitionConfig_id) 
        references [CompetitionConfig]

    alter table Playoff 
        add constraint FK70FD8E70AEEB0F74 
        foreign key (Competition_id) 
        references [Competition]

    alter table Season 
        add constraint FK87D6FE8EAEEB0F74 
        foreign key (Competition_id) 
        references [Competition]

    alter table [CompetitionConfig] 
        add constraint FK8AE6379F347D923 
        foreign key (League_id) 
        references [League]

    alter table [CompetitionConfig] 
        add constraint FK8AE6379D63442F6 
        foreign key (GameRules_id) 
        references [GameRules]

    alter table [CompetitionConfig] 
        add constraint FK8AE63797B9FB10E 
        foreign key (CompetitionConfig_id) 
        references [CompetitionConfig]

    alter table PlayoffCompetitionConfig 
        add constraint FKD86215377B9FB10E 
        foreign key (CompetitionConfig_id) 
        references [CompetitionConfig]

    alter table SeasonCompetitionConfig 
        add constraint FK702B00017B9FB10E 
        foreign key (CompetitionConfig_id) 
        references [CompetitionConfig]

    alter table [PlayoffRankingRule] 
        add constraint FKE935B59E258B9CD 
        foreign key (PlayoffConfig_id) 
        references PlayoffCompetitionConfig

    alter table [PlayoffRankingRule] 
        add constraint FKE935B59EEFAE44F0 
        foreign key (SourceCompetition_id) 
        references [CompetitionConfig]

    alter table [PlayoffSeriesRule] 
        add constraint FKADF48EA5258B9CD 
        foreign key (PlayoffConfig_id) 
        references PlayoffCompetitionConfig

    alter table [PlayoffSeriesRule] 
        add constraint FKADF48EA5D63442F6 
        foreign key (GameRules_id) 
        references [GameRules]

    alter table [PlayoffSeries] 
        add constraint FK8C50325A1E61C4 
        foreign key (Playoff_id) 
        references Playoff

    alter table [PlayoffSeries] 
        add constraint FK8C50325AAA3EA50E 
        foreign key (HomeTeam_id) 
        references PlayoffTeam

    alter table [PlayoffSeries] 
        add constraint FK8C50325AF3B56F84 
        foreign key (AwayTeam_id) 
        references PlayoffTeam

    alter table BestOfSeries 
        add constraint FK3F2DAE359C52C6F6 
        foreign key (PlayoffSeries_id) 
        references [PlayoffSeries]

    alter table TotalGoalsSeries 
        add constraint FK807A54E9C52C6F6 
        foreign key (PlayoffSeries_id) 
        references [PlayoffSeries]

    alter table [SeasonDivisionRule] 
        add constraint FK5D79E78CA3D47D2A 
        foreign key (Competition_id) 
        references SeasonCompetitionConfig

    alter table [SeasonScheduleRule] 
        add constraint FKE1A3C1A6A3D47D2A 
        foreign key (Competition_id) 
        references SeasonCompetitionConfig

    alter table [SeasonTeamRule] 
        add constraint FK95A69050A3D47D2A 
        foreign key (Competition_id) 
        references SeasonCompetitionConfig

    alter table [SeasonTeamRule] 
        add constraint FK95A69050973AA0AB 
        foreign key (Team_id) 
        references [Team]

    alter table [SeasonDivision] 
        add constraint FK6D0C7DA8248CF50 
        foreign key (Season_id) 
        references Season

    alter table [SeasonDivision] 
        add constraint FK6D0C7DA866AF732D 
        foreign key (ParentDivision_id) 
        references [SeasonDivision]

    alter table [TeamRanking] 
        add constraint FKFC7E20F6CF5A11FA 
        foreign key (Team_id) 
        references [SingleYearTeam]

    alter table [TeamRanking] 
        add constraint FKFC7E20F6AEEB0F74 
        foreign key (Competition_id) 
        references [Competition]

    alter table [Game] 
        add constraint FKB46CD18A8589315C 
        foreign key (HomeTeam_id) 
        references [Team]

    alter table [Game] 
        add constraint FKB46CD18ADC02FBD6 
        foreign key (AwayTeam_id) 
        references [Team]

    alter table [Game] 
        add constraint FKB46CD18AA8C53C82 
        foreign key (Rules_id) 
        references [GameRules]

    alter table ScheduleGame 
        add constraint FKA742947837122A5F 
        foreign key (Game_id) 
        references [Game]

    alter table ScheduleGame 
        add constraint FKA7429478AEEB0F74 
        foreign key (Competition_id) 
        references [Competition]

    alter table PlayoffGame 
        add constraint FK1B310BA9B017421F 
        foreign key (ScheduleGame_id) 
        references ScheduleGame

    alter table PlayoffGame 
        add constraint FK1B310BA9A972680D 
        foreign key (Series_id) 
        references [PlayoffSeries]

    alter table [SingleYearTeam] 
        add constraint FK9E509A31AEEB0F74 
        foreign key (Competition_id) 
        references [Competition]

    alter table [SingleYearTeam] 
        add constraint FK9E509A31B0F19ABC 
        foreign key (Parent_id) 
        references [Team]

    alter table PlayoffTeam 
        add constraint FK39052534FBA224B0 
        foreign key (SingleYearTeam_id) 
        references [SingleYearTeam]

    alter table SeasonTeam 
        add constraint FKBB47D4EFFBA224B0 
        foreign key (SingleYearTeam_id) 
        references [SingleYearTeam]

    alter table SeasonTeam 
        add constraint FKBB47D4EF598DE0A6 
        foreign key (Division_id) 
        references [SeasonDivision]

    alter table SeasonTeam 
        add constraint FKBB47D4EF9468A261 
        foreign key (Stats_id) 
        references [SeasonTeamStats]


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKADF0688D39DE9BE1]') and parent_object_id = OBJECT_ID(N'[Competition]'))
alter table [Competition]  drop constraint FKADF0688D39DE9BE1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK60BE2013B9630E17]') and parent_object_id = OBJECT_ID(N'Playoff'))
alter table Playoff  drop constraint FK60BE2013B9630E17


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK814A8885B9630E17]') and parent_object_id = OBJECT_ID(N'Season'))
alter table Season  drop constraint FK814A8885B9630E17


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD55C978BA5DBA19F]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FKD55C978BA5DBA19F


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD55C978B84DF53A0]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FKD55C978B84DF53A0


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD55C978B39DE9BE1]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FKD55C978B39DE9BE1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5506D2A339DE9BE1]') and parent_object_id = OBJECT_ID(N'PlayoffCompetitionConfig'))
alter table PlayoffCompetitionConfig  drop constraint FK5506D2A339DE9BE1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC30812C939DE9BE1]') and parent_object_id = OBJECT_ID(N'SeasonCompetitionConfig'))
alter table SeasonCompetitionConfig  drop constraint FKC30812C939DE9BE1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKB0456AE1A34944A1]') and parent_object_id = OBJECT_ID(N'[PlayoffRankingRule]'))
alter table [PlayoffRankingRule]  drop constraint FKB0456AE1A34944A1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKB0456AE13E743747]') and parent_object_id = OBJECT_ID(N'[PlayoffRankingRule]'))
alter table [PlayoffRankingRule]  drop constraint FKB0456AE13E743747


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9C8E70DBA34944A1]') and parent_object_id = OBJECT_ID(N'[PlayoffSeriesRule]'))
alter table [PlayoffSeriesRule]  drop constraint FK9C8E70DBA34944A1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9C8E70DB84DF53A0]') and parent_object_id = OBJECT_ID(N'[PlayoffSeriesRule]'))
alter table [PlayoffSeriesRule]  drop constraint FK9C8E70DB84DF53A0


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKB5815612D430F87A]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FKB5815612D430F87A


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKB58156126DEC57B3]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FKB58156126DEC57B3


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKB5815612B0580EBB]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FKB5815612B0580EBB


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD9AA98C2EFAC5D71]') and parent_object_id = OBJECT_ID(N'BestOfSeries'))
alter table BestOfSeries  drop constraint FKD9AA98C2EFAC5D71


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK98993C4AEFAC5D71]') and parent_object_id = OBJECT_ID(N'TotalGoalsSeries'))
alter table TotalGoalsSeries  drop constraint FK98993C4AEFAC5D71


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8407F15B32FBB3EA]') and parent_object_id = OBJECT_ID(N'[SeasonDivisionRule]'))
alter table [SeasonDivisionRule]  drop constraint FK8407F15B32FBB3EA


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKCB419E6832FBB3EA]') and parent_object_id = OBJECT_ID(N'[SeasonScheduleRule]'))
alter table [SeasonScheduleRule]  drop constraint FKCB419E6832FBB3EA


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKA14C7C4D32FBB3EA]') and parent_object_id = OBJECT_ID(N'[SeasonTeamRule]'))
alter table [SeasonTeamRule]  drop constraint FKA14C7C4D32FBB3EA


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKA14C7C4D1A740F8D]') and parent_object_id = OBJECT_ID(N'[SeasonTeamRule]'))
alter table [SeasonTeamRule]  drop constraint FKA14C7C4D1A740F8D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9140677DFDADB067]') and parent_object_id = OBJECT_ID(N'[SeasonDivision]'))
alter table [SeasonDivision]  drop constraint FK9140677DFDADB067


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9140677D6CB307D8]') and parent_object_id = OBJECT_ID(N'[SeasonDivision]'))
alter table [SeasonDivision]  drop constraint FK9140677D6CB307D8


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK12C5D6FF3E79C898]') and parent_object_id = OBJECT_ID(N'[TeamRanking]'))
alter table [TeamRanking]  drop constraint FK12C5D6FF3E79C898


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK12C5D6FFB9630E17]') and parent_object_id = OBJECT_ID(N'[TeamRanking]'))
alter table [TeamRanking]  drop constraint FK12C5D6FFB9630E17


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKAE113808B39DEE25]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FKAE113808B39DEE25


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKAE1138086E29B72D]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FKAE1138086E29B72D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKAE1138084E36E24A]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FKAE1138084E36E24A


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK35F16396A239786C]') and parent_object_id = OBJECT_ID(N'ScheduleGame'))
alter table ScheduleGame  drop constraint FK35F16396A239786C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK35F16396B9630E17]') and parent_object_id = OBJECT_ID(N'ScheduleGame'))
alter table ScheduleGame  drop constraint FK35F16396B9630E17


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK7C8C0588E5BBBCE5]') and parent_object_id = OBJECT_ID(N'PlayoffGame'))
alter table PlayoffGame  drop constraint FK7C8C0588E5BBBCE5


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK7C8C05885578EA]') and parent_object_id = OBJECT_ID(N'PlayoffGame'))
alter table PlayoffGame  drop constraint FK7C8C05885578EA


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK2B2A2051B9630E17]') and parent_object_id = OBJECT_ID(N'[SingleYearTeam]'))
alter table [SingleYearTeam]  drop constraint FK2B2A2051B9630E17


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK2B2A2051EC25EF59]') and parent_object_id = OBJECT_ID(N'[SingleYearTeam]'))
alter table [SingleYearTeam]  drop constraint FK2B2A2051EC25EF59


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5AE45A6ADD6BE1D5]') and parent_object_id = OBJECT_ID(N'PlayoffTeam'))
alter table PlayoffTeam  drop constraint FK5AE45A6ADD6BE1D5


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8F2860ABDD6BE1D5]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FK8F2860ABDD6BE1D5


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8F2860AB68E49DB8]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FK8F2860AB68E49DB8


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8F2860AB2AFB3E14]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FK8F2860AB2AFB3E14


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
        add constraint FKADF0688D39DE9BE1 
        foreign key (CompetitionConfig_id) 
        references [CompetitionConfig]

    alter table Playoff 
        add constraint FK60BE2013B9630E17 
        foreign key (Competition_id) 
        references [Competition]

    alter table Season 
        add constraint FK814A8885B9630E17 
        foreign key (Competition_id) 
        references [Competition]

    alter table [CompetitionConfig] 
        add constraint FKD55C978BA5DBA19F 
        foreign key (League_id) 
        references [League]

    alter table [CompetitionConfig] 
        add constraint FKD55C978B84DF53A0 
        foreign key (GameRules_id) 
        references [GameRules]

    alter table [CompetitionConfig] 
        add constraint FKD55C978B39DE9BE1 
        foreign key (CompetitionConfig_id) 
        references [CompetitionConfig]

    alter table PlayoffCompetitionConfig 
        add constraint FK5506D2A339DE9BE1 
        foreign key (CompetitionConfig_id) 
        references [CompetitionConfig]

    alter table SeasonCompetitionConfig 
        add constraint FKC30812C939DE9BE1 
        foreign key (CompetitionConfig_id) 
        references [CompetitionConfig]

    alter table [PlayoffRankingRule] 
        add constraint FKB0456AE1A34944A1 
        foreign key (PlayoffConfig_id) 
        references PlayoffCompetitionConfig

    alter table [PlayoffRankingRule] 
        add constraint FKB0456AE13E743747 
        foreign key (SourceCompetition_id) 
        references [CompetitionConfig]

    alter table [PlayoffSeriesRule] 
        add constraint FK9C8E70DBA34944A1 
        foreign key (PlayoffConfig_id) 
        references PlayoffCompetitionConfig

    alter table [PlayoffSeriesRule] 
        add constraint FK9C8E70DB84DF53A0 
        foreign key (GameRules_id) 
        references [GameRules]

    alter table [PlayoffSeries] 
        add constraint FKB5815612D430F87A 
        foreign key (Playoff_id) 
        references Playoff

    alter table [PlayoffSeries] 
        add constraint FKB58156126DEC57B3 
        foreign key (HomeTeam_id) 
        references PlayoffTeam

    alter table [PlayoffSeries] 
        add constraint FKB5815612B0580EBB 
        foreign key (AwayTeam_id) 
        references PlayoffTeam

    alter table BestOfSeries 
        add constraint FKD9AA98C2EFAC5D71 
        foreign key (PlayoffSeries_id) 
        references [PlayoffSeries]

    alter table TotalGoalsSeries 
        add constraint FK98993C4AEFAC5D71 
        foreign key (PlayoffSeries_id) 
        references [PlayoffSeries]

    alter table [SeasonDivisionRule] 
        add constraint FK8407F15B32FBB3EA 
        foreign key (Competition_id) 
        references SeasonCompetitionConfig

    alter table [SeasonScheduleRule] 
        add constraint FKCB419E6832FBB3EA 
        foreign key (Competition_id) 
        references SeasonCompetitionConfig

    alter table [SeasonTeamRule] 
        add constraint FKA14C7C4D32FBB3EA 
        foreign key (Competition_id) 
        references SeasonCompetitionConfig

    alter table [SeasonTeamRule] 
        add constraint FKA14C7C4D1A740F8D 
        foreign key (Team_id) 
        references [Team]

    alter table [SeasonDivision] 
        add constraint FK9140677DFDADB067 
        foreign key (Season_id) 
        references Season

    alter table [SeasonDivision] 
        add constraint FK9140677D6CB307D8 
        foreign key (ParentDivision_id) 
        references [SeasonDivision]

    alter table [TeamRanking] 
        add constraint FK12C5D6FF3E79C898 
        foreign key (Team_id) 
        references [SingleYearTeam]

    alter table [TeamRanking] 
        add constraint FK12C5D6FFB9630E17 
        foreign key (Competition_id) 
        references [Competition]

    alter table [Game] 
        add constraint FKAE113808B39DEE25 
        foreign key (HomeTeam_id) 
        references [Team]

    alter table [Game] 
        add constraint FKAE1138086E29B72D 
        foreign key (AwayTeam_id) 
        references [Team]

    alter table [Game] 
        add constraint FKAE1138084E36E24A 
        foreign key (Rules_id) 
        references [GameRules]

    alter table ScheduleGame 
        add constraint FK35F16396A239786C 
        foreign key (Game_id) 
        references [Game]

    alter table ScheduleGame 
        add constraint FK35F16396B9630E17 
        foreign key (Competition_id) 
        references [Competition]

    alter table PlayoffGame 
        add constraint FK7C8C0588E5BBBCE5 
        foreign key (ScheduleGame_id) 
        references ScheduleGame

    alter table PlayoffGame 
        add constraint FK7C8C05885578EA 
        foreign key (Series_id) 
        references [PlayoffSeries]

    alter table [SingleYearTeam] 
        add constraint FK2B2A2051B9630E17 
        foreign key (Competition_id) 
        references [Competition]

    alter table [SingleYearTeam] 
        add constraint FK2B2A2051EC25EF59 
        foreign key (Parent_id) 
        references [Team]

    alter table PlayoffTeam 
        add constraint FK5AE45A6ADD6BE1D5 
        foreign key (SingleYearTeam_id) 
        references [SingleYearTeam]

    alter table SeasonTeam 
        add constraint FK8F2860ABDD6BE1D5 
        foreign key (SingleYearTeam_id) 
        references [SingleYearTeam]

    alter table SeasonTeam 
        add constraint FK8F2860AB68E49DB8 
        foreign key (Division_id) 
        references [SeasonDivision]

    alter table SeasonTeam 
        add constraint FK8F2860AB2AFB3E14 
        foreign key (Stats_id) 
        references [SeasonTeamStats]

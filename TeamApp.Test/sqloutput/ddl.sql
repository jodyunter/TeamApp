
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFD646D521B6FFEF2]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FKFD646D521B6FFEF2


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFD646D5241700E15]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FKFD646D5241700E15


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKFD646D527D1A4103]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FKFD646D527D1A4103


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD00BE5CC7D1A4103]') and parent_object_id = OBJECT_ID(N'PlayoffCompetitionConfig'))
alter table PlayoffCompetitionConfig  drop constraint FKD00BE5CC7D1A4103


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK544AF81E7D1A4103]') and parent_object_id = OBJECT_ID(N'SeasonCompetitionConfig'))
alter table SeasonCompetitionConfig  drop constraint FK544AF81E7D1A4103


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK865E824E5E723F46]') and parent_object_id = OBJECT_ID(N'[PlayoffRankingRule]'))
alter table [PlayoffRankingRule]  drop constraint FK865E824E5E723F46


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK865E824E1E3442C0]') and parent_object_id = OBJECT_ID(N'[PlayoffRankingRule]'))
alter table [PlayoffRankingRule]  drop constraint FK865E824E1E3442C0


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK97F035EF5E723F46]') and parent_object_id = OBJECT_ID(N'[PlayoffSeriesRule]'))
alter table [PlayoffSeriesRule]  drop constraint FK97F035EF5E723F46


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK97F035EF41700E15]') and parent_object_id = OBJECT_ID(N'[PlayoffSeriesRule]'))
alter table [PlayoffSeriesRule]  drop constraint FK97F035EF41700E15


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK9CA8420E99B3A735]') and parent_object_id = OBJECT_ID(N'[SeasonDivisionRule]'))
alter table [SeasonDivisionRule]  drop constraint FK9CA8420E99B3A735


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK74BF464E99B3A735]') and parent_object_id = OBJECT_ID(N'[SeasonScheduleRule]'))
alter table [SeasonScheduleRule]  drop constraint FK74BF464E99B3A735


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK7CF41E5799B3A735]') and parent_object_id = OBJECT_ID(N'[SeasonTeamRule]'))
alter table [SeasonTeamRule]  drop constraint FK7CF41E5799B3A735


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK7CF41E57D7E87044]') and parent_object_id = OBJECT_ID(N'[SeasonTeamRule]'))
alter table [SeasonTeamRule]  drop constraint FK7CF41E57D7E87044


    if exists (select * from dbo.sysobjects where id = object_id(N'[CompetitionConfig]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [CompetitionConfig]

    if exists (select * from dbo.sysobjects where id = object_id(N'PlayoffCompetitionConfig') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table PlayoffCompetitionConfig

    if exists (select * from dbo.sysobjects where id = object_id(N'SeasonCompetitionConfig') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table SeasonCompetitionConfig

    if exists (select * from dbo.sysobjects where id = object_id(N'[PlayoffRankingRule]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [PlayoffRankingRule]

    if exists (select * from dbo.sysobjects where id = object_id(N'[PlayoffSeriesRule]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [PlayoffSeriesRule]

    if exists (select * from dbo.sysobjects where id = object_id(N'[SeasonDivisionRule]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [SeasonDivisionRule]

    if exists (select * from dbo.sysobjects where id = object_id(N'[SeasonScheduleRule]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [SeasonScheduleRule]

    if exists (select * from dbo.sysobjects where id = object_id(N'[SeasonTeamRule]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [SeasonTeamRule]

    if exists (select * from dbo.sysobjects where id = object_id(N'[GameRules]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [GameRules]

    if exists (select * from dbo.sysobjects where id = object_id(N'[League]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [League]

    if exists (select * from dbo.sysobjects where id = object_id(N'[Team]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [Team]

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
       CreatedBy NVARCHAR(255) null,
       CreatedOn DATETIME2 null,
       LastModifiedBy NVARCHAR(255) null,
       LastModifiedOn DATETIME2 null,
       primary key (Id)
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

    alter table [CompetitionConfig] 
        add constraint FKFD646D521B6FFEF2 
        foreign key (League_id) 
        references [League]

    alter table [CompetitionConfig] 
        add constraint FKFD646D5241700E15 
        foreign key (GameRules_id) 
        references [GameRules]

    alter table [CompetitionConfig] 
        add constraint FKFD646D527D1A4103 
        foreign key (CompetitionConfig_id) 
        references [CompetitionConfig]

    alter table PlayoffCompetitionConfig 
        add constraint FKD00BE5CC7D1A4103 
        foreign key (CompetitionConfig_id) 
        references [CompetitionConfig]

    alter table SeasonCompetitionConfig 
        add constraint FK544AF81E7D1A4103 
        foreign key (CompetitionConfig_id) 
        references [CompetitionConfig]

    alter table [PlayoffRankingRule] 
        add constraint FK865E824E5E723F46 
        foreign key (PlayoffConfig_id) 
        references PlayoffCompetitionConfig

    alter table [PlayoffRankingRule] 
        add constraint FK865E824E1E3442C0 
        foreign key (SourceCompetition_id) 
        references [CompetitionConfig]

    alter table [PlayoffSeriesRule] 
        add constraint FK97F035EF5E723F46 
        foreign key (PlayoffConfig_id) 
        references PlayoffCompetitionConfig

    alter table [PlayoffSeriesRule] 
        add constraint FK97F035EF41700E15 
        foreign key (GameRules_id) 
        references [GameRules]

    alter table [SeasonDivisionRule] 
        add constraint FK9CA8420E99B3A735 
        foreign key (Competition_id) 
        references SeasonCompetitionConfig

    alter table [SeasonScheduleRule] 
        add constraint FK74BF464E99B3A735 
        foreign key (Competition_id) 
        references SeasonCompetitionConfig

    alter table [SeasonTeamRule] 
        add constraint FK7CF41E5799B3A735 
        foreign key (Competition_id) 
        references SeasonCompetitionConfig

    alter table [SeasonTeamRule] 
        add constraint FK7CF41E57D7E87044 
        foreign key (Team_id) 
        references [Team]

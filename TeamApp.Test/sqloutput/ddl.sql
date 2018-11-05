
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKDAB4C29EF35653DE]') and parent_object_id = OBJECT_ID(N'[Competition]'))
alter table [Competition]  drop constraint FKDAB4C29EF35653DE


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKCA3BA1C16C0D1292]') and parent_object_id = OBJECT_ID(N'Playoff'))
alter table Playoff  drop constraint FKCA3BA1C16C0D1292


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKE518A9026C0D1292]') and parent_object_id = OBJECT_ID(N'Season'))
alter table Season  drop constraint FKE518A9026C0D1292


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK2578F886B4F724C8]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FK2578F886B4F724C8


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK2578F886E5BB913D]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FK2578F886E5BB913D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK2578F886F35653DE]') and parent_object_id = OBJECT_ID(N'[CompetitionConfig]'))
alter table [CompetitionConfig]  drop constraint FK2578F886F35653DE


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK4D25AFA5F35653DE]') and parent_object_id = OBJECT_ID(N'PlayoffCompetitionConfig'))
alter table PlayoffCompetitionConfig  drop constraint FK4D25AFA5F35653DE


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKAE5C9A14F35653DE]') and parent_object_id = OBJECT_ID(N'SeasonCompetitionConfig'))
alter table SeasonCompetitionConfig  drop constraint FKAE5C9A14F35653DE


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5A9396FDF24F49BE]') and parent_object_id = OBJECT_ID(N'[PlayoffRankingRule]'))
alter table [PlayoffRankingRule]  drop constraint FK5A9396FDF24F49BE


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK5A9396FD2F21C2A9]') and parent_object_id = OBJECT_ID(N'[PlayoffRankingRule]'))
alter table [PlayoffRankingRule]  drop constraint FK5A9396FD2F21C2A9


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKCA0EEF1BF24F49BE]') and parent_object_id = OBJECT_ID(N'[PlayoffSeriesRule]'))
alter table [PlayoffSeriesRule]  drop constraint FKCA0EEF1BF24F49BE


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKCA0EEF1BE5BB913D]') and parent_object_id = OBJECT_ID(N'[PlayoffSeriesRule]'))
alter table [PlayoffSeriesRule]  drop constraint FKCA0EEF1BE5BB913D


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK7D0DDF0B119BC2A3]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FK7D0DDF0B119BC2A3


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK7D0DDF0BC335D108]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FK7D0DDF0BC335D108


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK7D0DDF0B49C5FC2C]') and parent_object_id = OBJECT_ID(N'[PlayoffSeries]'))
alter table [PlayoffSeries]  drop constraint FK7D0DDF0B49C5FC2C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK8F7C8459FB1088F6]') and parent_object_id = OBJECT_ID(N'BestOfSeries'))
alter table BestOfSeries  drop constraint FK8F7C8459FB1088F6


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK1C3BC24DFB1088F6]') and parent_object_id = OBJECT_ID(N'TotalGoalsSeries'))
alter table TotalGoalsSeries  drop constraint FK1C3BC24DFB1088F6


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK53A9F16DD5AECE2C]') and parent_object_id = OBJECT_ID(N'[SeasonDivisionRule]'))
alter table [SeasonDivisionRule]  drop constraint FK53A9F16DD5AECE2C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKADE96314D5AECE2C]') and parent_object_id = OBJECT_ID(N'[SeasonScheduleRule]'))
alter table [SeasonScheduleRule]  drop constraint FKADE96314D5AECE2C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK73F63320D5AECE2C]') and parent_object_id = OBJECT_ID(N'[SeasonTeamRule]'))
alter table [SeasonTeamRule]  drop constraint FK73F63320D5AECE2C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK73F63320A10187F4]') and parent_object_id = OBJECT_ID(N'[SeasonTeamRule]'))
alter table [SeasonTeamRule]  drop constraint FK73F63320A10187F4


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK3ABBEBA9FCEDA3]') and parent_object_id = OBJECT_ID(N'[SeasonDivision]'))
alter table [SeasonDivision]  drop constraint FK3ABBEBA9FCEDA3


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK3ABBEB4D34C1E8]') and parent_object_id = OBJECT_ID(N'[SeasonDivision]'))
alter table [SeasonDivision]  drop constraint FK3ABBEB4D34C1E8


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK4B328AFE18B649A2]') and parent_object_id = OBJECT_ID(N'[SeasonTeamStats]'))
alter table [SeasonTeamStats]  drop constraint FK4B328AFE18B649A2


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC790679B395C8517]') and parent_object_id = OBJECT_ID(N'[TeamRanking]'))
alter table [TeamRanking]  drop constraint FKC790679B395C8517


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKC790679B6C0D1292]') and parent_object_id = OBJECT_ID(N'[TeamRanking]'))
alter table [TeamRanking]  drop constraint FKC790679B6C0D1292


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD12ACA891CC4CD60]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FKD12ACA891CC4CD60


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD12ACA899634E044]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FKD12ACA899634E044


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD12ACA895F73F74A]') and parent_object_id = OBJECT_ID(N'[Game]'))
alter table [Game]  drop constraint FKD12ACA895F73F74A


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK4B89AEBC6F9019E1]') and parent_object_id = OBJECT_ID(N'ScheduleGame'))
alter table ScheduleGame  drop constraint FK4B89AEBC6F9019E1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK4B89AEBC6C0D1292]') and parent_object_id = OBJECT_ID(N'ScheduleGame'))
alter table ScheduleGame  drop constraint FK4B89AEBC6C0D1292


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKF5489098997A05E2]') and parent_object_id = OBJECT_ID(N'PlayoffGame'))
alter table PlayoffGame  drop constraint FKF5489098997A05E2


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKF5489098224FCC37]') and parent_object_id = OBJECT_ID(N'PlayoffGame'))
alter table PlayoffGame  drop constraint FKF5489098224FCC37


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK958E024A6C0D1292]') and parent_object_id = OBJECT_ID(N'[SingleYearTeam]'))
alter table [SingleYearTeam]  drop constraint FK958E024A6C0D1292


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK958E024A7F2066F3]') and parent_object_id = OBJECT_ID(N'[SingleYearTeam]'))
alter table [SingleYearTeam]  drop constraint FK958E024A7F2066F3


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKF759A3EAC36127C]') and parent_object_id = OBJECT_ID(N'PlayoffTeam'))
alter table PlayoffTeam  drop constraint FKF759A3EAC36127C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD95F4CA6AC36127C]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FKD95F4CA6AC36127C


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD95F4CA668118930]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FKD95F4CA668118930


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD95F4CA6DB2522BA]') and parent_object_id = OBJECT_ID(N'SeasonTeam'))
alter table SeasonTeam  drop constraint FKD95F4CA6DB2522BA


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
       Team_id BIGINT null,
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
        add constraint FKDAB4C29EF35653DE 
        foreign key (CompetitionConfig_id) 
        references [CompetitionConfig]

    alter table Playoff 
        add constraint FKCA3BA1C16C0D1292 
        foreign key (Competition_id) 
        references [Competition]

    alter table Season 
        add constraint FKE518A9026C0D1292 
        foreign key (Competition_id) 
        references [Competition]

    alter table [CompetitionConfig] 
        add constraint FK2578F886B4F724C8 
        foreign key (League_id) 
        references [League]

    alter table [CompetitionConfig] 
        add constraint FK2578F886E5BB913D 
        foreign key (GameRules_id) 
        references [GameRules]

    alter table [CompetitionConfig] 
        add constraint FK2578F886F35653DE 
        foreign key (CompetitionConfig_id) 
        references [CompetitionConfig]

    alter table PlayoffCompetitionConfig 
        add constraint FK4D25AFA5F35653DE 
        foreign key (CompetitionConfig_id) 
        references [CompetitionConfig]

    alter table SeasonCompetitionConfig 
        add constraint FKAE5C9A14F35653DE 
        foreign key (CompetitionConfig_id) 
        references [CompetitionConfig]

    alter table [PlayoffRankingRule] 
        add constraint FK5A9396FDF24F49BE 
        foreign key (PlayoffConfig_id) 
        references PlayoffCompetitionConfig

    alter table [PlayoffRankingRule] 
        add constraint FK5A9396FD2F21C2A9 
        foreign key (SourceCompetition_id) 
        references [CompetitionConfig]

    alter table [PlayoffSeriesRule] 
        add constraint FKCA0EEF1BF24F49BE 
        foreign key (PlayoffConfig_id) 
        references PlayoffCompetitionConfig

    alter table [PlayoffSeriesRule] 
        add constraint FKCA0EEF1BE5BB913D 
        foreign key (GameRules_id) 
        references [GameRules]

    alter table [PlayoffSeries] 
        add constraint FK7D0DDF0B119BC2A3 
        foreign key (Playoff_id) 
        references Playoff

    alter table [PlayoffSeries] 
        add constraint FK7D0DDF0BC335D108 
        foreign key (HomeTeam_id) 
        references PlayoffTeam

    alter table [PlayoffSeries] 
        add constraint FK7D0DDF0B49C5FC2C 
        foreign key (AwayTeam_id) 
        references PlayoffTeam

    alter table BestOfSeries 
        add constraint FK8F7C8459FB1088F6 
        foreign key (PlayoffSeries_id) 
        references [PlayoffSeries]

    alter table TotalGoalsSeries 
        add constraint FK1C3BC24DFB1088F6 
        foreign key (PlayoffSeries_id) 
        references [PlayoffSeries]

    alter table [SeasonDivisionRule] 
        add constraint FK53A9F16DD5AECE2C 
        foreign key (Competition_id) 
        references SeasonCompetitionConfig

    alter table [SeasonScheduleRule] 
        add constraint FKADE96314D5AECE2C 
        foreign key (Competition_id) 
        references SeasonCompetitionConfig

    alter table [SeasonTeamRule] 
        add constraint FK73F63320D5AECE2C 
        foreign key (Competition_id) 
        references SeasonCompetitionConfig

    alter table [SeasonTeamRule] 
        add constraint FK73F63320A10187F4 
        foreign key (Team_id) 
        references [Team]

    alter table [SeasonDivision] 
        add constraint FK3ABBEBA9FCEDA3 
        foreign key (Season_id) 
        references Season

    alter table [SeasonDivision] 
        add constraint FK3ABBEB4D34C1E8 
        foreign key (ParentDivision_id) 
        references [SeasonDivision]

    alter table [SeasonTeamStats] 
        add constraint FK4B328AFE18B649A2 
        foreign key (Team_id) 
        references SeasonTeam

    alter table [TeamRanking] 
        add constraint FKC790679B395C8517 
        foreign key (Team_id) 
        references [SingleYearTeam]

    alter table [TeamRanking] 
        add constraint FKC790679B6C0D1292 
        foreign key (Competition_id) 
        references [Competition]

    alter table [Game] 
        add constraint FKD12ACA891CC4CD60 
        foreign key (HomeTeam_id) 
        references [Team]

    alter table [Game] 
        add constraint FKD12ACA899634E044 
        foreign key (AwayTeam_id) 
        references [Team]

    alter table [Game] 
        add constraint FKD12ACA895F73F74A 
        foreign key (Rules_id) 
        references [GameRules]

    alter table ScheduleGame 
        add constraint FK4B89AEBC6F9019E1 
        foreign key (Game_id) 
        references [Game]

    alter table ScheduleGame 
        add constraint FK4B89AEBC6C0D1292 
        foreign key (Competition_id) 
        references [Competition]

    alter table PlayoffGame 
        add constraint FKF5489098997A05E2 
        foreign key (ScheduleGame_id) 
        references ScheduleGame

    alter table PlayoffGame 
        add constraint FKF5489098224FCC37 
        foreign key (Series_id) 
        references [PlayoffSeries]

    alter table [SingleYearTeam] 
        add constraint FK958E024A6C0D1292 
        foreign key (Competition_id) 
        references [Competition]

    alter table [SingleYearTeam] 
        add constraint FK958E024A7F2066F3 
        foreign key (Parent_id) 
        references [Team]

    alter table PlayoffTeam 
        add constraint FKF759A3EAC36127C 
        foreign key (SingleYearTeam_id) 
        references [SingleYearTeam]

    alter table SeasonTeam 
        add constraint FKD95F4CA6AC36127C 
        foreign key (SingleYearTeam_id) 
        references [SingleYearTeam]

    alter table SeasonTeam 
        add constraint FKD95F4CA668118930 
        foreign key (Division_id) 
        references [SeasonDivision]

    alter table SeasonTeam 
        add constraint FKD95F4CA6DB2522BA 
        foreign key (Stats_id) 
        references [SeasonTeamStats]

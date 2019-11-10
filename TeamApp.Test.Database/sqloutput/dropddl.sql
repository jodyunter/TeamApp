USE [JodyTest]
GO
/****** Object:  StoredProcedure [dbo].[DropAllTables]    Script Date: 11/7/2019 10:44:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[DropAllTables] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

EXEC sp_MSforeachtable "ALTER TABLE ? NOCHECK CONSTRAINT all"

--competitionconfigs first
IF OBJECT_ID (N'CompetitionGamePlayer', N'U') IS NOT NULL drop table CompetitionGamePlayer
IF OBJECT_ID (N'CompetitionPlayer', N'U') IS NOT NULL drop table CompetitionPlayer
IF OBJECT_ID (N'CompetitionTeam', N'U') IS NOT NULL drop table CompetitionTeam
IF OBJECT_ID (N'CompetitionConfigFinalRankingRule', N'U') IS NOT NULL drop table CompetitionConfigFinalRankingRule
IF OBJECT_ID (N'SeasonTeamRule', N'U') IS NOT NULL drop table SeasonTeamRule
IF OBJECT_ID (N'SeasonScheduleRule', N'U') IS NOT NULL drop table SeasonScheduleRule
IF OBJECT_ID (N'SeasonDivisionRule', N'U') IS NOT NULL drop table SeasonDivisionRule
IF OBJECT_ID (N'CompetitionConfig', N'U') IS NOT NULL drop table CompetitionConfig

IF OBJECT_ID (N'TeamRanking', N'U') IS NOT NULL drop table TeamRanking
IF OBJECT_ID (N'SeasonDivision', N'U') IS NOT NULL drop table SeasonDivision
IF OBJECT_ID (N'SeasonTeamStats', N'U') IS NOT NULL drop table SeasonTeamStats

--may need to move in the future
IF OBJECT_ID (N'Player', N'U') IS NOT NULL drop table Player
IF OBJECT_ID (N'Team', N'U') IS NOT NULL drop table Team
IF OBJECT_ID (N'Game', N'U') IS NOT NULL drop table Game
IF OBJECT_ID (N'PlayoffSeries', N'U') IS NOT NULL drop table PlayoffSeries
IF OBJECT_ID (N'GameData', N'U') IS NOT NULL drop table GameData

IF OBJECT_ID (N'GameRules', N'U') IS NOT NULL drop table GameRules

IF OBJECT_ID (N'Competition', N'U') IS NOT NULL drop table Competition
IF OBJECT_ID (N'League', N'U') IS NOT NULL drop table League



END

/*

exec DropAllTables

*/
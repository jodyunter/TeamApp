-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE DropAllTables 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

IF OBJECT_ID (N'BestOfSeries', N'U') IS NOT NULL drop table BestOfSeries
IF OBJECT_ID (N'TotalGoalsSeries', N'U') IS NOT NULL drop table TotalGoalsSeries
IF OBJECT_ID (N'GameData', N'U') IS NOT NULL drop table GameData
IF OBJECT_ID (N'SeasonTeam', N'U') IS NOT NULL drop table SeasonTeam
IF OBJECT_ID (N'TeamRanking', N'U') IS NOT NULL drop table TeamRanking
IF OBJECT_ID (N'PlayoffSeriesRule', N'U') IS NOT NULL drop table PlayoffSeriesRule
IF OBJECT_ID (N'PlayoffGame', N'U') IS NOT NULL drop table PlayoffGame
IF OBJECT_ID (N'PlayoffSeries', N'U') IS NOT NULL drop Table PlayoffSeries
IF OBJECT_ID (N'PlayoffTeam', N'U') IS NOT NULL drop table PlayoffTeam
IF OBJECT_ID (N'SeasonDivision', N'U') IS NOT NULL drop table SeasonDivision
IF OBJECT_ID (N'SeasonDivisionRule', N'U') IS NOT NULL drop table SeasonDivisionRule
IF OBJECT_ID (N'SeasonTeamRule', N'U') IS NOT NULL drop table SeasonTeamRule
IF OBJECT_ID (N'SeasonTeamStats', N'U') IS NOT NULL drop table SeasonTeamStats
IF OBJECT_ID (N'SeasonScheduleRule', N'U') IS NOT NULL drop table SeasonScheduleRule
IF OBJECT_ID (N'SeasonCompetitionConfig', N'U') IS NOT NULL drop table SeasonCompetitionConfig
IF OBJECT_ID (N'SingleYearTeam', N'U') IS NOT NULL drop table SingleYearTeam
IF OBJECT_ID (N'Playoff', N'U') IS NOT NULL drop table Playoff
IF OBJECT_ID (N'Season', N'U') IS NOT NULL drop table Season
IF OBJECT_ID (N'PlayoffRankingRule', N'U') IS NOT NULL drop table PlayoffRankingRule
IF OBJECT_ID (N'PlayoffCompetitionConfig', N'U') IS NOT NULL drop table PlayoffCompetitionConfig
IF OBJECT_ID (N'ScheduleGame', N'U') IS NOT NULL drop table ScheduleGame
IF OBJECT_ID (N'Game', N'U') IS NOT NULL  drop table Game
IF OBJECT_ID (N'Team', N'U') IS NOT NULL drop table Team
IF OBJECT_ID (N'Competition', N'U') IS NOT NULL drop table Competition
IF OBJECT_ID (N'CompetitionConfig', N'U') IS NOT NULL drop table CompetitionConfig
IF OBJECT_ID (N'GameRules', N'U') IS NOT NULL drop table League
IF OBJECT_ID (N'GameRules', N'U') IS NOT NULL drop table GameRules

END
GO

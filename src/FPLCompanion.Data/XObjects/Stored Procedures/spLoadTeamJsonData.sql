IF EXISTS (SELECT 1 FROM sys.objects WHERE TYPE = 'P' AND OBJECT_ID = OBJECT_ID('dbo.spLoadTeamJsonData'))
   DROP PROCEDURE dbo.spLoadTeamJsonData;
GO

CREATE PROCEDURE dbo.spLoadTeamJsonData @path NVARCHAR(MAX)
AS
	SET NOCOUNT ON;
	BEGIN

		DECLARE @SqlQuery NVARCHAR(MAX);
		DECLARE @tmpPlayers TABLE(
			[id] [int],
			[code] [int],
			[draw] [int],
			[form] [decimal](18, 2),
			[loss] [int],
			[name] [nvarchar](max),
			[played] [int] ,
			[points] [int] ,
			[position] [int] ,
			[short_name] [nvarchar](max) ,
			[strength] [int] ,
			[team_division] [int] ,
			[unavailable] [bit] ,
			[win] [int] ,
			[strength_overall_home] [int] ,
			[strength_overall_away] [int] ,
			[strength_attack_home] [int] ,
			[strength_attack_away] [int] ,
			[strength_defence_home] [int] ,
			[strength_defence_away] [int] ,
			[pulse_id] [int]
		)

		SET @SqlQuery = 
		'DECLARE @json NVARCHAR(MAX);
		SELECT @json = BULKColumn FROM OPENROWSET (BULK '''+@PATH+''', SINGLE_CLOB) jsonFile; ' +
		CAST('SELECT [id]
			  ,[code]
			  ,[draw]
			  ,[form]
			  ,[loss]
			  ,[name]
			  ,[played]
			  ,[points]
			  ,[position]
			  ,[short_name]
			  ,[strength]
			  ,[team_division]
			  ,[unavailable]
			  ,[win]
			  ,[strength_overall_home]
			  ,[strength_overall_away]
			  ,[strength_attack_home]
			  ,[strength_attack_away]
			  ,[strength_defence_home]
			  ,[strength_defence_away]
			  ,[pulse_id]
		 FROM OPENJSON(@json)
		 WITH (
			[teams] NVARCHAR(MAX) AS JSON
		 )
		 CROSS APPLY OPENJSON([teams])
		 WITH (
			[id] [int],
			[code] [int],
			[draw] [int],
			[form] [decimal](18, 2),
			[loss] [int],
			[name] [nvarchar](max),
			[played] [int] ,
			[points] [int] ,
			[position] [int] ,
			[short_name] [nvarchar](max) ,
			[strength] [int] ,
			[team_division] [int] ,
			[unavailable] [bit] ,
			[win] [int] ,
			[strength_overall_home] [int] ,
			[strength_overall_away] [int] ,
			[strength_attack_home] [int] ,
			[strength_attack_away] [int] ,
			[strength_defence_home] [int] ,
			[strength_defence_away] [int] ,
			[pulse_id] [int]
		 )' AS NVARCHAR(MAX));

		INSERT @tmpPlayers
		EXECUTE SP_EXECUTESQL @SqlQuery;

		DELETE FROM Team;

		SELECT [id]
			  ,[code]
			  ,[draw]
			  ,[form]
			  ,[loss]
			  ,[name]
			  ,[played]
			  ,[points]
			  ,[position]
			  ,[short_name]
			  ,[strength]
			  ,[team_division]
			  ,[unavailable]
			  ,[win]
			  ,[strength_overall_home]
			  ,[strength_overall_away]
			  ,[strength_attack_home]
			  ,[strength_attack_away]
			  ,[strength_defence_home]
			  ,[strength_defence_away]
			  ,[pulse_id]
			FROM @tmpPlayers;
	END
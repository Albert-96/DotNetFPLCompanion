IF EXISTS (SELECT 1 FROM sys.objects WHERE TYPE = 'P' AND OBJECT_ID = OBJECT_ID('dbo.spLoadElementTypeJsonData'))
   DROP PROCEDURE dbo.spLoadElementTypeJsonData;
GO

CREATE PROCEDURE dbo.spLoadElementTypeJsonData @path NVARCHAR(MAX)
AS
	SET NOCOUNT ON;
	BEGIN

		DECLARE @SqlQuery NVARCHAR(MAX);
		DECLARE @tmpPlayers TABLE(
			[id] [int] ,
			[plural_name] [nvarchar](max) ,
			[plural_name_short] [nvarchar](max) ,
			[singular_name] [nvarchar](max) ,
			[singular_name_short] [nvarchar](max) ,
			[squad_select] [int] ,
			[squad_min_play] [int] ,
			[squad_max_play] [int] ,
			[ui_shirt_specific] [bit] ,
			[element_count] [int]
		)

		SET @SqlQuery = 
		'DECLARE @json NVARCHAR(MAX);
		SELECT @json = BULKColumn FROM OPENROWSET (BULK '''+@PATH+''', SINGLE_CLOB) jsonFile; ' +
		CAST('SELECT [id]
			  ,[plural_name]
			  ,[plural_name_short]
			  ,[singular_name]
			  ,[singular_name_short]
			  ,[squad_select]
			  ,[squad_min_play]
			  ,[squad_max_play]
			  ,[ui_shirt_specific]
			  ,[element_count]
		 FROM OPENJSON(@json)
		 WITH (
			[element_types] NVARCHAR(MAX) AS JSON
		 )
		 CROSS APPLY OPENJSON([element_types])
		 WITH (
			[id] [int] ,
			[plural_name] [nvarchar](max) ,
			[plural_name_short] [nvarchar](max) ,
			[singular_name] [nvarchar](max) ,
			[singular_name_short] [nvarchar](max) ,
			[squad_select] [int] ,
			[squad_min_play] [int] ,
			[squad_max_play] [int] ,
			[ui_shirt_specific] [bit] ,
			[element_count] [int]
		 )' AS NVARCHAR(MAX));

		INSERT @tmpPlayers
		EXECUTE SP_EXECUTESQL @SqlQuery;

		
		DELETE FROM ElementType;

		SELECT [id]
			  ,[plural_name]
			  ,[plural_name_short]
			  ,[singular_name]
			  ,[singular_name_short]
			  ,[squad_select]
			  ,[squad_min_play]
			  ,[squad_max_play]
			  ,[ui_shirt_specific]
			  ,[element_count]
			FROM @tmpPlayers;
	END
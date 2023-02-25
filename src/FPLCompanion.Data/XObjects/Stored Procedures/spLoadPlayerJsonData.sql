IF EXISTS (SELECT 1 FROM sys.objects WHERE TYPE = 'P' AND OBJECT_ID = OBJECT_ID('dbo.spLoadPlayerJsonData'))
   DROP PROCEDURE dbo.spLoadPlayerJsonData;
GO

CREATE PROCEDURE dbo.spLoadPlayerJsonData @path NVARCHAR(MAX)
AS
	SET NOCOUNT ON;
	BEGIN

		DECLARE @SqlQuery NVARCHAR(MAX);
		DECLARE @tmpPlayers TABLE(
			[id] [int],
			[chance_of_playing_next_round] [int],
			[chance_of_playing_this_round] [int],
			[code] [int],
			[cost_change_event] [int],
			[cost_change_event_fall] [int] ,
			[cost_change_start] [int] ,
			[cost_change_start_fall] [int] ,
			[dreamteam_count] [int] ,
			[element_type] [int] ,
			[ep_next] [nvarchar](max) ,
			[ep_this] [nvarchar](max) ,
			[event_points] [int] ,
			[first_name] [nvarchar](max) ,
			[form] [nvarchar](max) ,
			[in_dreamteam] [bit] ,
			[news] [nvarchar](max) ,
			[news_added] [datetime2](7),
			[now_cost] [int] ,
			[photo] [nvarchar](max) ,
			[points_per_game] [nvarchar](max) ,
			[second_name] [nvarchar](max) ,
			[selected_by_percent] [nvarchar](max) ,
			[special] [bit] ,
			[squad_number] [int] ,
			[status] [nvarchar](max) ,
			[team] [int] ,
			[team_code] [int] ,
			[total_points] [int] ,
			[transfers_in] [int] ,
			[transfers_in_event] [int] ,
			[transfers_out] [int] ,
			[transfers_out_event] [int] ,
			[value_form] [nvarchar](max) ,
			[value_season] [nvarchar](max) ,
			[web_name] [nvarchar](max) ,
			[minutes] [int] ,
			[goals_scored] [int] ,
			[assists] [int] ,
			[clean_sheets] [int] ,
			[goals_conceded] [int] ,
			[own_goals] [int] ,
			[penalties_saved] [int] ,
			[penalties_missed] [int] ,
			[yellow_cards] [int] ,
			[red_cards] [int] ,
			[saves] [int] ,
			[bonus] [int] ,
			[bps] [int] ,
			[influence] [nvarchar](max) ,
			[creativity] [nvarchar](max) ,
			[threat] [nvarchar](max) ,
			[ict_index] [nvarchar](max) ,
			[starts] [int] ,
			[expected_goals] [nvarchar](max) ,
			[expected_assists] [nvarchar](max) ,
			[expected_goal_involvements] [nvarchar](max) ,
			[expected_goals_conceded] [nvarchar](max) ,
			[influence_rank] [int] ,
			[influence_rank_type] [int] ,
			[creativity_rank] [int] ,
			[creativity_rank_type] [int] ,
			[threat_rank] [int] ,
			[threat_rank_type] [int] ,
			[ict_index_rank] [int] ,
			[ict_index_rank_type] [int] ,
			[corners_and_indirect_freekicks_order] [int],
			[corners_and_indirect_freekicks_text] [nvarchar](max) ,
			[direct_freekicks_order] [int],
			[direct_freekicks_text] [nvarchar](max) ,
			[penalties_order] [int],
			[penalties_text] [nvarchar](max) ,
			[expected_goals_per_90] [float] ,
			[saves_per_90] [float] ,
			[expected_assists_per_90] [float] ,
			[expected_goal_involvements_per_90] [float] ,
			[expected_goals_conceded_per_90] [float] ,
			[goals_conceded_per_90] [float] ,
			[now_cost_rank] [int] ,
			[now_cost_rank_type] [int] ,
			[form_rank] [int] ,
			[form_rank_type] [int] ,
			[points_per_game_rank] [int] ,
			[points_per_game_rank_type] [int] ,
			[selected_rank] [int] ,
			[selected_rank_type] [int] ,
			[starts_per_90] [float] ,
			[clean_sheets_per_90] [float] 
		)

		SET @SqlQuery = 
		'DECLARE @json NVARCHAR(MAX);
		SELECT @json = BULKColumn FROM OPENROWSET (BULK '''+@PATH+''', SINGLE_CLOB) jsonFile; ' +
		CAST('SELECT [id]
			  ,[chance_of_playing_next_round]
			  ,[chance_of_playing_this_round]
			  ,[code]
			  ,[cost_change_event]
			  ,[cost_change_event_fall]
			  ,[cost_change_start]
			  ,[cost_change_start_fall]
			  ,[dreamteam_count]
			  ,[element_type]
			  ,[ep_next]
			  ,[ep_this]
			  ,[event_points]
			  ,[first_name]
			  ,[form]
			  ,[in_dreamteam]
			  ,[news]
			  ,[news_added]
			  ,[now_cost]
			  ,[photo]
			  ,[points_per_game]
			  ,[second_name]
			  ,[selected_by_percent]
			  ,[special]
			  ,[squad_number]
			  ,[status]
			  ,[team]
			  ,[team_code]
			  ,[total_points]
			  ,[transfers_in]
			  ,[transfers_in_event]
			  ,[transfers_out]
			  ,[transfers_out_event]
			  ,[value_form]
			  ,[value_season]
			  ,[web_name]
			  ,[minutes]
			  ,[goals_scored]
			  ,[assists]
			  ,[clean_sheets]
			  ,[goals_conceded]
			  ,[own_goals]
			  ,[penalties_saved]
			  ,[penalties_missed]
			  ,[yellow_cards]
			  ,[red_cards]
			  ,[saves]
			  ,[bonus]
			  ,[bps]
			  ,[influence]
			  ,[creativity]
			  ,[threat]
			  ,[ict_index]
			  ,[starts]
			  ,[expected_goals]
			  ,[expected_assists]
			  ,[expected_goal_involvements]
			  ,[expected_goals_conceded]
			  ,[influence_rank]
			  ,[influence_rank_type]
			  ,[creativity_rank]
			  ,[creativity_rank_type]
			  ,[threat_rank]
			  ,[threat_rank_type]
			  ,[ict_index_rank]
			  ,[ict_index_rank_type]
			  ,[corners_and_indirect_freekicks_order]
			  ,[corners_and_indirect_freekicks_text]
			  ,[direct_freekicks_order]
			  ,[direct_freekicks_text]
			  ,[penalties_order]
			  ,[penalties_text]
			  ,[expected_goals_per_90]
			  ,[saves_per_90]
			  ,[expected_assists_per_90]
			  ,[expected_goal_involvements_per_90]
			  ,[expected_goals_conceded_per_90]
			  ,[goals_conceded_per_90]
			  ,[now_cost_rank]
			  ,[now_cost_rank_type]
			  ,[form_rank]
			  ,[form_rank_type]
			  ,[points_per_game_rank]
			  ,[points_per_game_rank_type]
			  ,[selected_rank]
			  ,[selected_rank_type]
			  ,[starts_per_90]
			  ,[clean_sheets_per_90]
		 FROM OPENJSON(@json)
		 WITH (
			[elements] NVARCHAR(MAX) AS JSON
		 )
		 CROSS APPLY OPENJSON([elements])
		 WITH (
			[id] [int],
			[chance_of_playing_next_round] [int],
			[chance_of_playing_this_round] [int],
			[code] [int],
			[cost_change_event] [int],
			[cost_change_event_fall] [int] ,
			[cost_change_start] [int] ,
			[cost_change_start_fall] [int] ,
			[dreamteam_count] [int] ,
			[element_type] [int] ,
			[ep_next] [nvarchar](max) ,
			[ep_this] [nvarchar](max) ,
			[event_points] [int] ,
			[first_name] [nvarchar](max) ,
			[form] [nvarchar](max) ,
			[in_dreamteam] [bit] ,
			[news] [nvarchar](max) ,
			[news_added] [datetime2](7),
			[now_cost] [int] ,
			[photo] [nvarchar](max) ,
			[points_per_game] [nvarchar](max) ,
			[second_name] [nvarchar](max) ,
			[selected_by_percent] [nvarchar](max) ,
			[special] [bit] ,
			[squad_number] [int] ,
			[status] [nvarchar](max) ,
			[team] [int] ,
			[team_code] [int] ,
			[total_points] [int] ,
			[transfers_in] [int] ,
			[transfers_in_event] [int] ,
			[transfers_out] [int] ,
			[transfers_out_event] [int] ,
			[value_form] [nvarchar](max) ,
			[value_season] [nvarchar](max) ,
			[web_name] [nvarchar](max) ,
			[minutes] [int] ,
			[goals_scored] [int] ,
			[assists] [int] ,
			[clean_sheets] [int] ,
			[goals_conceded] [int] ,
			[own_goals] [int] ,
			[penalties_saved] [int] ,
			[penalties_missed] [int] ,
			[yellow_cards] [int] ,
			[red_cards] [int] ,
			[saves] [int] ,
			[bonus] [int] ,
			[bps] [int] ,
			[influence] [nvarchar](max) ,
			[creativity] [nvarchar](max) ,
			[threat] [nvarchar](max) ,
			[ict_index] [nvarchar](max) ,
			[starts] [int] ,
			[expected_goals] [nvarchar](max) ,
			[expected_assists] [nvarchar](max) ,
			[expected_goal_involvements] [nvarchar](max) ,
			[expected_goals_conceded] [nvarchar](max) ,
			[influence_rank] [int] ,
			[influence_rank_type] [int] ,
			[creativity_rank] [int] ,
			[creativity_rank_type] [int] ,
			[threat_rank] [int] ,
			[threat_rank_type] [int] ,
			[ict_index_rank] [int] ,
			[ict_index_rank_type] [int] ,
			[corners_and_indirect_freekicks_order] [int],
			[corners_and_indirect_freekicks_text] [nvarchar](max) ,
			[direct_freekicks_order] [int],
			[direct_freekicks_text] [nvarchar](max) ,
			[penalties_order] [int],
			[penalties_text] [nvarchar](max) ,
			[expected_goals_per_90] [float] ,
			[saves_per_90] [float] ,
			[expected_assists_per_90] [float] ,
			[expected_goal_involvements_per_90] [float] ,
			[expected_goals_conceded_per_90] [float] ,
			[goals_conceded_per_90] [float] ,
			[now_cost_rank] [int] ,
			[now_cost_rank_type] [int] ,
			[form_rank] [int] ,
			[form_rank_type] [int] ,
			[points_per_game_rank] [int] ,
			[points_per_game_rank_type] [int] ,
			[selected_rank] [int] ,
			[selected_rank_type] [int] ,
			[starts_per_90] [float] ,
			[clean_sheets_per_90] [float] 
		 )' AS NVARCHAR(MAX));

		INSERT @tmpPlayers
		EXECUTE SP_EXECUTESQL @SqlQuery;

		DELETE FROM Element;

		SELECT [id]
			  ,[chance_of_playing_next_round]
			  ,[chance_of_playing_this_round]
			  ,[code]
			  ,[cost_change_event]
			  ,[cost_change_event_fall]
			  ,[cost_change_start]
			  ,[cost_change_start_fall]
			  ,[dreamteam_count]
			  ,[element_type]
			  ,[ep_next]
			  ,[ep_this]
			  ,[event_points]
			  ,[first_name]
			  ,[form]
			  ,[in_dreamteam]
			  ,[news]
			  ,[news_added]
			  ,[now_cost]
			  ,[photo]
			  ,[points_per_game]
			  ,[second_name]
			  ,[selected_by_percent]
			  ,[special]
			  ,[squad_number]
			  ,[status]
			  ,[team]
			  ,[team_code]
			  ,[total_points]
			  ,[transfers_in]
			  ,[transfers_in_event]
			  ,[transfers_out]
			  ,[transfers_out_event]
			  ,[value_form]
			  ,[value_season]
			  ,[web_name]
			  ,[minutes]
			  ,[goals_scored]
			  ,[assists]
			  ,[clean_sheets]
			  ,[goals_conceded]
			  ,[own_goals]
			  ,[penalties_saved]
			  ,[penalties_missed]
			  ,[yellow_cards]
			  ,[red_cards]
			  ,[saves]
			  ,[bonus]
			  ,[bps]
			  ,[influence]
			  ,[creativity]
			  ,[threat]
			  ,[ict_index]
			  ,[starts]
			  ,[expected_goals]
			  ,[expected_assists]
			  ,[expected_goal_involvements]
			  ,[expected_goals_conceded]
			  ,[influence_rank]
			  ,[influence_rank_type]
			  ,[creativity_rank]
			  ,[creativity_rank_type]
			  ,[threat_rank]
			  ,[threat_rank_type]
			  ,[ict_index_rank]
			  ,[ict_index_rank_type]
			  ,[corners_and_indirect_freekicks_order]
			  ,[corners_and_indirect_freekicks_text]
			  ,[direct_freekicks_order]
			  ,[direct_freekicks_text]
			  ,[penalties_order]
			  ,[penalties_text]
			  ,[expected_goals_per_90]
			  ,[saves_per_90]
			  ,[expected_assists_per_90]
			  ,[expected_goal_involvements_per_90]
			  ,[expected_goals_conceded_per_90]
			  ,[goals_conceded_per_90]
			  ,[now_cost_rank]
			  ,[now_cost_rank_type]
			  ,[form_rank]
			  ,[form_rank_type]
			  ,[points_per_game_rank]
			  ,[points_per_game_rank_type]
			  ,[selected_rank]
			  ,[selected_rank_type]
			  ,[starts_per_90]
			  ,[clean_sheets_per_90]
			FROM @tmpPlayers;
	END
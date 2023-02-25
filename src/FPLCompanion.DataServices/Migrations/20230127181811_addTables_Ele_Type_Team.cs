using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FPLCompanion.DataServices.Migrations
{
    /// <inheritdoc />
    public partial class addTablesEleTypeTeam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ElementType",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    pluralname = table.Column<string>(name: "plural_name", type: "nvarchar(max)", nullable: false),
                    pluralnameshort = table.Column<string>(name: "plural_name_short", type: "nvarchar(max)", nullable: false),
                    singularname = table.Column<string>(name: "singular_name", type: "nvarchar(max)", nullable: false),
                    singularnameshort = table.Column<string>(name: "singular_name_short", type: "nvarchar(max)", nullable: false),
                    squadselect = table.Column<int>(name: "squad_select", type: "int", nullable: false),
                    squadminplay = table.Column<int>(name: "squad_min_play", type: "int", nullable: false),
                    squadmaxplay = table.Column<int>(name: "squad_max_play", type: "int", nullable: false),
                    uishirtspecific = table.Column<bool>(name: "ui_shirt_specific", type: "bit", nullable: false),
                    elementcount = table.Column<int>(name: "element_count", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementType", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    code = table.Column<int>(type: "int", nullable: false),
                    draw = table.Column<int>(type: "int", nullable: false),
                    form = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    loss = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    played = table.Column<int>(type: "int", nullable: false),
                    points = table.Column<int>(type: "int", nullable: false),
                    position = table.Column<int>(type: "int", nullable: false),
                    shortname = table.Column<string>(name: "short_name", type: "nvarchar(max)", nullable: false),
                    strength = table.Column<int>(type: "int", nullable: false),
                    teamdivision = table.Column<int>(name: "team_division", type: "int", nullable: false),
                    unavailable = table.Column<bool>(type: "bit", nullable: false),
                    win = table.Column<int>(type: "int", nullable: false),
                    strengthoverallhome = table.Column<int>(name: "strength_overall_home", type: "int", nullable: false),
                    strengthoverallaway = table.Column<int>(name: "strength_overall_away", type: "int", nullable: false),
                    strengthattackhome = table.Column<int>(name: "strength_attack_home", type: "int", nullable: false),
                    strengthattackaway = table.Column<int>(name: "strength_attack_away", type: "int", nullable: false),
                    strengthdefencehome = table.Column<int>(name: "strength_defence_home", type: "int", nullable: false),
                    strengthdefenceaway = table.Column<int>(name: "strength_defence_away", type: "int", nullable: false),
                    pulseid = table.Column<int>(name: "pulse_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Element",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    chanceofplayingnextround = table.Column<int>(name: "chance_of_playing_next_round", type: "int", nullable: true),
                    chanceofplayingthisround = table.Column<int>(name: "chance_of_playing_this_round", type: "int", nullable: true),
                    code = table.Column<int>(type: "int", nullable: false),
                    costchangeevent = table.Column<int>(name: "cost_change_event", type: "int", nullable: false),
                    costchangeeventfall = table.Column<int>(name: "cost_change_event_fall", type: "int", nullable: false),
                    costchangestart = table.Column<int>(name: "cost_change_start", type: "int", nullable: false),
                    costchangestartfall = table.Column<int>(name: "cost_change_start_fall", type: "int", nullable: false),
                    dreamteamcount = table.Column<int>(name: "dreamteam_count", type: "int", nullable: false),
                    elementtype = table.Column<int>(name: "element_type", type: "int", nullable: false),
                    epnext = table.Column<string>(name: "ep_next", type: "nvarchar(max)", nullable: false),
                    epthis = table.Column<string>(name: "ep_this", type: "nvarchar(max)", nullable: false),
                    eventpoints = table.Column<int>(name: "event_points", type: "int", nullable: false),
                    firstname = table.Column<string>(name: "first_name", type: "nvarchar(max)", nullable: false),
                    form = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    indreamteam = table.Column<bool>(name: "in_dreamteam", type: "bit", nullable: false),
                    news = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    newsadded = table.Column<DateTime>(name: "news_added", type: "datetime2", nullable: true),
                    nowcost = table.Column<int>(name: "now_cost", type: "int", nullable: false),
                    photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pointspergame = table.Column<string>(name: "points_per_game", type: "nvarchar(max)", nullable: false),
                    secondname = table.Column<string>(name: "second_name", type: "nvarchar(max)", nullable: false),
                    selectedbypercent = table.Column<string>(name: "selected_by_percent", type: "nvarchar(max)", nullable: false),
                    special = table.Column<bool>(type: "bit", nullable: false),
                    squadnumber = table.Column<int>(name: "squad_number", type: "int", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    team = table.Column<int>(type: "int", nullable: false),
                    teamcode = table.Column<int>(name: "team_code", type: "int", nullable: false),
                    totalpoints = table.Column<int>(name: "total_points", type: "int", nullable: false),
                    transfersin = table.Column<int>(name: "transfers_in", type: "int", nullable: false),
                    transfersinevent = table.Column<int>(name: "transfers_in_event", type: "int", nullable: false),
                    transfersout = table.Column<int>(name: "transfers_out", type: "int", nullable: false),
                    transfersoutevent = table.Column<int>(name: "transfers_out_event", type: "int", nullable: false),
                    valueform = table.Column<string>(name: "value_form", type: "nvarchar(max)", nullable: false),
                    valueseason = table.Column<string>(name: "value_season", type: "nvarchar(max)", nullable: false),
                    webname = table.Column<string>(name: "web_name", type: "nvarchar(max)", nullable: false),
                    minutes = table.Column<int>(type: "int", nullable: false),
                    goalsscored = table.Column<int>(name: "goals_scored", type: "int", nullable: false),
                    assists = table.Column<int>(type: "int", nullable: false),
                    cleansheets = table.Column<int>(name: "clean_sheets", type: "int", nullable: false),
                    goalsconceded = table.Column<int>(name: "goals_conceded", type: "int", nullable: false),
                    owngoals = table.Column<int>(name: "own_goals", type: "int", nullable: false),
                    penaltiessaved = table.Column<int>(name: "penalties_saved", type: "int", nullable: false),
                    penaltiesmissed = table.Column<int>(name: "penalties_missed", type: "int", nullable: false),
                    yellowcards = table.Column<int>(name: "yellow_cards", type: "int", nullable: false),
                    redcards = table.Column<int>(name: "red_cards", type: "int", nullable: false),
                    saves = table.Column<int>(type: "int", nullable: false),
                    bonus = table.Column<int>(type: "int", nullable: false),
                    bps = table.Column<int>(type: "int", nullable: false),
                    influence = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    creativity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    threat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ictindex = table.Column<string>(name: "ict_index", type: "nvarchar(max)", nullable: false),
                    starts = table.Column<int>(type: "int", nullable: false),
                    expectedgoals = table.Column<string>(name: "expected_goals", type: "nvarchar(max)", nullable: false),
                    expectedassists = table.Column<string>(name: "expected_assists", type: "nvarchar(max)", nullable: false),
                    expectedgoalinvolvements = table.Column<string>(name: "expected_goal_involvements", type: "nvarchar(max)", nullable: false),
                    expectedgoalsconceded = table.Column<string>(name: "expected_goals_conceded", type: "nvarchar(max)", nullable: false),
                    influencerank = table.Column<int>(name: "influence_rank", type: "int", nullable: false),
                    influenceranktype = table.Column<int>(name: "influence_rank_type", type: "int", nullable: false),
                    creativityrank = table.Column<int>(name: "creativity_rank", type: "int", nullable: false),
                    creativityranktype = table.Column<int>(name: "creativity_rank_type", type: "int", nullable: false),
                    threatrank = table.Column<int>(name: "threat_rank", type: "int", nullable: false),
                    threatranktype = table.Column<int>(name: "threat_rank_type", type: "int", nullable: false),
                    ictindexrank = table.Column<int>(name: "ict_index_rank", type: "int", nullable: false),
                    ictindexranktype = table.Column<int>(name: "ict_index_rank_type", type: "int", nullable: false),
                    cornersandindirectfreekicksorder = table.Column<int>(name: "corners_and_indirect_freekicks_order", type: "int", nullable: true),
                    cornersandindirectfreekickstext = table.Column<string>(name: "corners_and_indirect_freekicks_text", type: "nvarchar(max)", nullable: false),
                    directfreekicksorder = table.Column<int>(name: "direct_freekicks_order", type: "int", nullable: true),
                    directfreekickstext = table.Column<string>(name: "direct_freekicks_text", type: "nvarchar(max)", nullable: false),
                    penaltiesorder = table.Column<int>(name: "penalties_order", type: "int", nullable: true),
                    penaltiestext = table.Column<string>(name: "penalties_text", type: "nvarchar(max)", nullable: false),
                    expectedgoalsper90 = table.Column<double>(name: "expected_goals_per_90", type: "float", nullable: false),
                    savesper90 = table.Column<double>(name: "saves_per_90", type: "float", nullable: false),
                    expectedassistsper90 = table.Column<double>(name: "expected_assists_per_90", type: "float", nullable: false),
                    expectedgoalinvolvementsper90 = table.Column<double>(name: "expected_goal_involvements_per_90", type: "float", nullable: false),
                    expectedgoalsconcededper90 = table.Column<double>(name: "expected_goals_conceded_per_90", type: "float", nullable: false),
                    goalsconcededper90 = table.Column<double>(name: "goals_conceded_per_90", type: "float", nullable: false),
                    nowcostrank = table.Column<int>(name: "now_cost_rank", type: "int", nullable: false),
                    nowcostranktype = table.Column<int>(name: "now_cost_rank_type", type: "int", nullable: false),
                    formrank = table.Column<int>(name: "form_rank", type: "int", nullable: false),
                    formranktype = table.Column<int>(name: "form_rank_type", type: "int", nullable: false),
                    pointspergamerank = table.Column<int>(name: "points_per_game_rank", type: "int", nullable: false),
                    pointspergameranktype = table.Column<int>(name: "points_per_game_rank_type", type: "int", nullable: false),
                    selectedrank = table.Column<int>(name: "selected_rank", type: "int", nullable: false),
                    selectedranktype = table.Column<int>(name: "selected_rank_type", type: "int", nullable: false),
                    startsper90 = table.Column<double>(name: "starts_per_90", type: "float", nullable: false),
                    cleansheetsper90 = table.Column<double>(name: "clean_sheets_per_90", type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Element", x => x.id);
                    table.ForeignKey(
                        name: "FK_Element_ElementType_element_type",
                        column: x => x.elementtype,
                        principalTable: "ElementType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Element_Team_team",
                        column: x => x.team,
                        principalTable: "Team",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Element_element_type",
                table: "Element",
                column: "element_type");

            migrationBuilder.CreateIndex(
                name: "IX_Element_team",
                table: "Element",
                column: "team");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Element");

            migrationBuilder.DropTable(
                name: "ElementType");

            migrationBuilder.DropTable(
                name: "Team");
        }
    }
}

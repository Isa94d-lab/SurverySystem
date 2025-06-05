using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories_catalog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories_catalog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Options_response",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Optiontext = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options_response", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Componentreact = table.Column<string>(type: "text", nullable: true),
                    Componenthtml = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: false),
                    instruction = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category_options",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Catalogoptions_id = table.Column<int>(type: "integer", nullable: false),
                    Categories_CatalogId = table.Column<int>(type: "integer", nullable: false),
                    Categoriesoptions_id = table.Column<int>(type: "integer", nullable: false),
                    Options_ResponseId = table.Column<int>(type: "integer", nullable: false),
                    Created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category_options", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_options_Categories_catalog_Categories_CatalogId",
                        column: x => x.Categories_CatalogId,
                        principalTable: "Categories_catalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Category_options_Options_response_Options_ResponseId",
                        column: x => x.Options_ResponseId,
                        principalTable: "Options_response",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chapters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    survey_id = table.Column<int>(type: "integer", nullable: false),
                    SurveysId = table.Column<int>(type: "integer", nullable: false),
                    Componenthtml = table.Column<string>(type: "text", nullable: true),
                    Componentreact = table.Column<string>(type: "text", nullable: true),
                    Chapter_number = table.Column<string>(type: "text", nullable: false),
                    Chapter_title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chapters_Surveys_SurveysId",
                        column: x => x.SurveysId,
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sumaryoptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id_survey = table.Column<int>(type: "integer", nullable: false),
                    SurveysId = table.Column<int>(type: "integer", nullable: false),
                    Code_number = table.Column<string>(type: "text", nullable: true),
                    Idquestion = table.Column<int>(type: "integer", nullable: false),
                    Valuerta = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sumaryoptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sumaryoptions_Surveys_SurveysId",
                        column: x => x.SurveysId,
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Chapter_id = table.Column<int>(type: "integer", nullable: false),
                    ChaptersId = table.Column<int>(type: "integer", nullable: false),
                    Created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Question_number = table.Column<string>(type: "text", nullable: true),
                    Response_type = table.Column<string>(type: "text", nullable: true),
                    Comment_question = table.Column<string>(type: "text", nullable: true),
                    Question_text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Chapters_ChaptersId",
                        column: x => x.ChaptersId,
                        principalTable: "Chapters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sub_questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Subquestion_id = table.Column<int>(type: "integer", nullable: false),
                    Subquestion_number = table.Column<string>(type: "text", nullable: true),
                    Comment_subquestion = table.Column<string>(type: "text", nullable: true),
                    Subquestiontext = table.Column<string>(type: "text", nullable: false),
                    QuestionsId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sub_questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sub_questions_Questions_QuestionsId",
                        column: x => x.QuestionsId,
                        principalTable: "Questions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Option_questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Option_id = table.Column<int>(type: "integer", nullable: false),
                    Options_ResponseId = table.Column<int>(type: "integer", nullable: false),
                    Optioncatalog_id = table.Column<int>(type: "integer", nullable: false),
                    Categories_CatalogId = table.Column<int>(type: "integer", nullable: false),
                    Optionquestions_id = table.Column<int>(type: "integer", nullable: false),
                    Option_QuestionsId = table.Column<int>(type: "integer", nullable: false),
                    Subquestion_id = table.Column<int>(type: "integer", nullable: false),
                    Sub_QuestionsId = table.Column<int>(type: "integer", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Comment_optionres = table.Column<string>(type: "text", nullable: true),
                    Numberoption = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Option_questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Option_questions_Categories_catalog_Categories_CatalogId",
                        column: x => x.Categories_CatalogId,
                        principalTable: "Categories_catalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Option_questions_Option_questions_Option_QuestionsId",
                        column: x => x.Option_QuestionsId,
                        principalTable: "Option_questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Option_questions_Options_response_Options_ResponseId",
                        column: x => x.Options_ResponseId,
                        principalTable: "Options_response",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Option_questions_Sub_questions_Sub_QuestionsId",
                        column: x => x.Sub_QuestionsId,
                        principalTable: "Sub_questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_options_Categories_CatalogId",
                table: "Category_options",
                column: "Categories_CatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_options_Options_ResponseId",
                table: "Category_options",
                column: "Options_ResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_SurveysId",
                table: "Chapters",
                column: "SurveysId");

            migrationBuilder.CreateIndex(
                name: "IX_Option_questions_Categories_CatalogId",
                table: "Option_questions",
                column: "Categories_CatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_Option_questions_Option_QuestionsId",
                table: "Option_questions",
                column: "Option_QuestionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Option_questions_Options_ResponseId",
                table: "Option_questions",
                column: "Options_ResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_Option_questions_Sub_QuestionsId",
                table: "Option_questions",
                column: "Sub_QuestionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ChaptersId",
                table: "Questions",
                column: "ChaptersId");

            migrationBuilder.CreateIndex(
                name: "IX_Sub_questions_QuestionsId",
                table: "Sub_questions",
                column: "QuestionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Sumaryoptions_SurveysId",
                table: "Sumaryoptions",
                column: "SurveysId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category_options");

            migrationBuilder.DropTable(
                name: "Option_questions");

            migrationBuilder.DropTable(
                name: "Sumaryoptions");

            migrationBuilder.DropTable(
                name: "Categories_catalog");

            migrationBuilder.DropTable(
                name: "Options_response");

            migrationBuilder.DropTable(
                name: "Sub_questions");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Chapters");

            migrationBuilder.DropTable(
                name: "Surveys");
        }
    }
}

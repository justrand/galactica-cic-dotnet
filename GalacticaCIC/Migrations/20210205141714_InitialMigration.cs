using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GalacticaCIC.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "Abilities",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expansions",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expansions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    InheritanceAdmiral = table.Column<int>(type: "integer", nullable: true),
                    InheritanceCag = table.Column<int>(type: "integer", nullable: true),
                    InheritancePresident = table.Column<int>(type: "integer", nullable: true),
                    OncePerTurnAbilityId = table.Column<long>(type: "bigint", nullable: true),
                    OncePerGameAbilityId = table.Column<long>(type: "bigint", nullable: true),
                    WeaknessId = table.Column<long>(type: "bigint", nullable: true),
                    LoyaltyWeight = table.Column<int>(type: "integer", nullable: false),
                    AlternateVersionId = table.Column<long>(type: "bigint", nullable: true),
                    ExpansionId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Abilities_OncePerGameAbilityId",
                        column: x => x.OncePerGameAbilityId,
                        principalSchema: "public",
                        principalTable: "Abilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characters_Abilities_OncePerTurnAbilityId",
                        column: x => x.OncePerTurnAbilityId,
                        principalSchema: "public",
                        principalTable: "Abilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characters_Abilities_WeaknessId",
                        column: x => x.WeaknessId,
                        principalSchema: "public",
                        principalTable: "Abilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characters_Characters_AlternateVersionId",
                        column: x => x.AlternateVersionId,
                        principalSchema: "public",
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characters_Expansions_ExpansionId",
                        column: x => x.ExpansionId,
                        principalSchema: "public",
                        principalTable: "Expansions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SkillSets",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PrimaryType = table.Column<int>(type: "integer", nullable: false),
                    SecondaryType = table.Column<int>(type: "integer", nullable: false),
                    DrawAmount = table.Column<int>(type: "integer", nullable: false),
                    CharacterId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillSets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillSets_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalSchema: "public",
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_AlternateVersionId",
                schema: "public",
                table: "Characters",
                column: "AlternateVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ExpansionId",
                schema: "public",
                table: "Characters",
                column: "ExpansionId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_OncePerGameAbilityId",
                schema: "public",
                table: "Characters",
                column: "OncePerGameAbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_OncePerTurnAbilityId",
                schema: "public",
                table: "Characters",
                column: "OncePerTurnAbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_WeaknessId",
                schema: "public",
                table: "Characters",
                column: "WeaknessId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillSets_CharacterId",
                schema: "public",
                table: "SkillSets",
                column: "CharacterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkillSets",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Characters",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Abilities",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Expansions",
                schema: "public");
        }
    }
}

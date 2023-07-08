using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduHome.DataAccess.Migrations
{
    public partial class manytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseDetailsAssesment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssesmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDetailsAssesment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseDetailsAssesment_Assesments_AssesmentId",
                        column: x => x.AssesmentId,
                        principalTable: "Assesments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseDetailsAssesment_CourseDetails_CourseDetailsId",
                        column: x => x.CourseDetailsId,
                        principalTable: "CourseDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CourseDetailsSkillLevel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillLevelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDetailsSkillLevel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseDetailsSkillLevel_CourseDetails_CourseDetailsId",
                        column: x => x.CourseDetailsId,
                        principalTable: "CourseDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseDetailsSkillLevel_SkillLevels_SkillLevelId",
                        column: x => x.SkillLevelId,
                        principalTable: "SkillLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseDetailsAssesment_AssesmentId",
                table: "CourseDetailsAssesment",
                column: "AssesmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseDetailsAssesment_CourseDetailsId",
                table: "CourseDetailsAssesment",
                column: "CourseDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseDetailsSkillLevel_CourseDetailsId",
                table: "CourseDetailsSkillLevel",
                column: "CourseDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseDetailsSkillLevel_SkillLevelId",
                table: "CourseDetailsSkillLevel",
                column: "SkillLevelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseDetailsAssesment");

            migrationBuilder.DropTable(
                name: "CourseDetailsSkillLevel");
        }
    }
}

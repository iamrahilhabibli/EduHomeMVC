using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduHome.DataAccess.Migrations
{
    public partial class DbInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assesments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssesmentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assesments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "courseCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courseCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageOption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SkillLevels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Skill = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "courseDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassDuration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LanguageOptionId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AssesmentId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SkillId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LanguageOptionId = table.Column<int>(type: "int", nullable: false),
                    AssesmentId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    StudentCount = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courseDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_courseDetails_Assesments_AssesmentId1",
                        column: x => x.AssesmentId1,
                        principalTable: "Assesments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_courseDetails_Languages_LanguageOptionId1",
                        column: x => x.LanguageOptionId1,
                        principalTable: "Languages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_courseDetails_SkillLevels_SkillId1",
                        column: x => x.SkillId1,
                        principalTable: "SkillLevels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseCategoryId = table.Column<int>(type: "int", nullable: false),
                    CourseCategoryId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_courses_courseCategories_CourseCategoryId1",
                        column: x => x.CourseCategoryId1,
                        principalTable: "courseCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_courses_courseDetails_CourseDetailsId",
                        column: x => x.CourseDetailsId,
                        principalTable: "courseDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_courseDetails_AssesmentId1",
                table: "courseDetails",
                column: "AssesmentId1");

            migrationBuilder.CreateIndex(
                name: "IX_courseDetails_LanguageOptionId1",
                table: "courseDetails",
                column: "LanguageOptionId1");

            migrationBuilder.CreateIndex(
                name: "IX_courseDetails_SkillId1",
                table: "courseDetails",
                column: "SkillId1");

            migrationBuilder.CreateIndex(
                name: "IX_courses_CourseCategoryId1",
                table: "courses",
                column: "CourseCategoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_courses_CourseDetailsId",
                table: "courses",
                column: "CourseDetailsId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "courses");

            migrationBuilder.DropTable(
                name: "courseCategories");

            migrationBuilder.DropTable(
                name: "courseDetails");

            migrationBuilder.DropTable(
                name: "Assesments");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "SkillLevels");
        }
    }
}

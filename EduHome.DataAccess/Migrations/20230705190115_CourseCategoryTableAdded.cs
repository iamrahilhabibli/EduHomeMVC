using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduHome.DataAccess.Migrations
{
    public partial class CourseCategoryTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courses_CourseCategory_CourseCategoryId",
                table: "courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseCategory",
                table: "CourseCategory");

            migrationBuilder.RenameTable(
                name: "CourseCategory",
                newName: "courseCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_courseCategories",
                table: "courseCategories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_courses_courseCategories_CourseCategoryId",
                table: "courses",
                column: "CourseCategoryId",
                principalTable: "courseCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courses_courseCategories_CourseCategoryId",
                table: "courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_courseCategories",
                table: "courseCategories");

            migrationBuilder.RenameTable(
                name: "courseCategories",
                newName: "CourseCategory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseCategory",
                table: "CourseCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_courses_CourseCategory_CourseCategoryId",
                table: "courses",
                column: "CourseCategoryId",
                principalTable: "CourseCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

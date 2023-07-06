using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduHome.DataAccess.Migrations
{
    public partial class coursedetailtablemdofied : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courseDetails_courses_CourseId",
                table: "courseDetails");

            migrationBuilder.DropIndex(
                name: "IX_courseDetails_CourseId",
                table: "courseDetails");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "courseDetails");

            migrationBuilder.CreateIndex(
                name: "IX_courses_CourseDetailsId",
                table: "courses",
                column: "CourseDetailsId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_courses_courseDetails_CourseDetailsId",
                table: "courses",
                column: "CourseDetailsId",
                principalTable: "courseDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courses_courseDetails_CourseDetailsId",
                table: "courses");

            migrationBuilder.DropIndex(
                name: "IX_courses_CourseDetailsId",
                table: "courses");

            migrationBuilder.AddColumn<Guid>(
                name: "CourseId",
                table: "courseDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_courseDetails_CourseId",
                table: "courseDetails",
                column: "CourseId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_courseDetails_courses_CourseId",
                table: "courseDetails",
                column: "CourseId",
                principalTable: "courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

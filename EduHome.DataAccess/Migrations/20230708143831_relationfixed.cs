using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduHome.DataAccess.Migrations
{
    public partial class relationfixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assesments_CourseDetails_CourseDetailsId",
                table: "Assesments");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseDetailsLanguage_Languages_LanguageOptionId",
                table: "CourseDetailsLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillLevels_CourseDetails_CourseDetailsId",
                table: "SkillLevels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseDetailsLanguage",
                table: "CourseDetailsLanguage");

            migrationBuilder.RenameColumn(
                name: "LanguageOptionId",
                table: "CourseDetailsLanguage",
                newName: "LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseDetailsLanguage_LanguageOptionId",
                table: "CourseDetailsLanguage",
                newName: "IX_CourseDetailsLanguage_LanguageId");

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseDetailsId",
                table: "SkillLevels",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "CourseDetailsId",
                table: "Languages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "CourseDetailsLanguage",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseDetailsId",
                table: "Assesments",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseDetailsLanguage",
                table: "CourseDetailsLanguage",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_CourseDetailsId",
                table: "Languages",
                column: "CourseDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseDetailsLanguage_CourseDetailsId",
                table: "CourseDetailsLanguage",
                column: "CourseDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assesments_CourseDetails_CourseDetailsId",
                table: "Assesments",
                column: "CourseDetailsId",
                principalTable: "CourseDetails",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDetailsLanguage_Languages_LanguageId",
                table: "CourseDetailsLanguage",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Languages_CourseDetails_CourseDetailsId",
                table: "Languages",
                column: "CourseDetailsId",
                principalTable: "CourseDetails",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillLevels_CourseDetails_CourseDetailsId",
                table: "SkillLevels",
                column: "CourseDetailsId",
                principalTable: "CourseDetails",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assesments_CourseDetails_CourseDetailsId",
                table: "Assesments");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseDetailsLanguage_Languages_LanguageId",
                table: "CourseDetailsLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_Languages_CourseDetails_CourseDetailsId",
                table: "Languages");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillLevels_CourseDetails_CourseDetailsId",
                table: "SkillLevels");

            migrationBuilder.DropIndex(
                name: "IX_Languages_CourseDetailsId",
                table: "Languages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseDetailsLanguage",
                table: "CourseDetailsLanguage");

            migrationBuilder.DropIndex(
                name: "IX_CourseDetailsLanguage_CourseDetailsId",
                table: "CourseDetailsLanguage");

            migrationBuilder.DropColumn(
                name: "CourseDetailsId",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CourseDetailsLanguage");

            migrationBuilder.RenameColumn(
                name: "LanguageId",
                table: "CourseDetailsLanguage",
                newName: "LanguageOptionId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseDetailsLanguage_LanguageId",
                table: "CourseDetailsLanguage",
                newName: "IX_CourseDetailsLanguage_LanguageOptionId");

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseDetailsId",
                table: "SkillLevels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseDetailsId",
                table: "Assesments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseDetailsLanguage",
                table: "CourseDetailsLanguage",
                columns: new[] { "CourseDetailsId", "LanguageOptionId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Assesments_CourseDetails_CourseDetailsId",
                table: "Assesments",
                column: "CourseDetailsId",
                principalTable: "CourseDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDetailsLanguage_Languages_LanguageOptionId",
                table: "CourseDetailsLanguage",
                column: "LanguageOptionId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillLevels_CourseDetails_CourseDetailsId",
                table: "SkillLevels",
                column: "CourseDetailsId",
                principalTable: "CourseDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

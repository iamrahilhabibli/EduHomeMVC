using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduHome.DataAccess.Migrations
{
    public partial class coursedetailslanguage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseDetailsLanguage_CourseDetails_CourseDetailsId",
                table: "CourseDetailsLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseDetailsLanguage_Languages_LanguageId",
                table: "CourseDetailsLanguage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseDetailsLanguage",
                table: "CourseDetailsLanguage");

            migrationBuilder.RenameTable(
                name: "CourseDetailsLanguage",
                newName: "CourseDetailsLanguages");

            migrationBuilder.RenameIndex(
                name: "IX_CourseDetailsLanguage_LanguageId",
                table: "CourseDetailsLanguages",
                newName: "IX_CourseDetailsLanguages_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseDetailsLanguage_CourseDetailsId",
                table: "CourseDetailsLanguages",
                newName: "IX_CourseDetailsLanguages_CourseDetailsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseDetailsLanguages",
                table: "CourseDetailsLanguages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDetailsLanguages_CourseDetails_CourseDetailsId",
                table: "CourseDetailsLanguages",
                column: "CourseDetailsId",
                principalTable: "CourseDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDetailsLanguages_Languages_LanguageId",
                table: "CourseDetailsLanguages",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseDetailsLanguages_CourseDetails_CourseDetailsId",
                table: "CourseDetailsLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseDetailsLanguages_Languages_LanguageId",
                table: "CourseDetailsLanguages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseDetailsLanguages",
                table: "CourseDetailsLanguages");

            migrationBuilder.RenameTable(
                name: "CourseDetailsLanguages",
                newName: "CourseDetailsLanguage");

            migrationBuilder.RenameIndex(
                name: "IX_CourseDetailsLanguages_LanguageId",
                table: "CourseDetailsLanguage",
                newName: "IX_CourseDetailsLanguage_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseDetailsLanguages_CourseDetailsId",
                table: "CourseDetailsLanguage",
                newName: "IX_CourseDetailsLanguage_CourseDetailsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseDetailsLanguage",
                table: "CourseDetailsLanguage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDetailsLanguage_CourseDetails_CourseDetailsId",
                table: "CourseDetailsLanguage",
                column: "CourseDetailsId",
                principalTable: "CourseDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDetailsLanguage_Languages_LanguageId",
                table: "CourseDetailsLanguage",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

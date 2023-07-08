using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduHome.DataAccess.Migrations
{
    public partial class many2manytablesadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseDetailsAssesment_Assesments_AssesmentId",
                table: "CourseDetailsAssesment");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseDetailsAssesment_CourseDetails_CourseDetailsId",
                table: "CourseDetailsAssesment");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseDetailsSkillLevel_CourseDetails_CourseDetailsId",
                table: "CourseDetailsSkillLevel");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseDetailsSkillLevel_SkillLevels_SkillLevelId",
                table: "CourseDetailsSkillLevel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseDetailsSkillLevel",
                table: "CourseDetailsSkillLevel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseDetailsAssesment",
                table: "CourseDetailsAssesment");

            migrationBuilder.RenameTable(
                name: "CourseDetailsSkillLevel",
                newName: "CourseDetailsSkillLevels");

            migrationBuilder.RenameTable(
                name: "CourseDetailsAssesment",
                newName: "CourseDetailsAssesments");

            migrationBuilder.RenameIndex(
                name: "IX_CourseDetailsSkillLevel_SkillLevelId",
                table: "CourseDetailsSkillLevels",
                newName: "IX_CourseDetailsSkillLevels_SkillLevelId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseDetailsSkillLevel_CourseDetailsId",
                table: "CourseDetailsSkillLevels",
                newName: "IX_CourseDetailsSkillLevels_CourseDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseDetailsAssesment_CourseDetailsId",
                table: "CourseDetailsAssesments",
                newName: "IX_CourseDetailsAssesments_CourseDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseDetailsAssesment_AssesmentId",
                table: "CourseDetailsAssesments",
                newName: "IX_CourseDetailsAssesments_AssesmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseDetailsSkillLevels",
                table: "CourseDetailsSkillLevels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseDetailsAssesments",
                table: "CourseDetailsAssesments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDetailsAssesments_Assesments_AssesmentId",
                table: "CourseDetailsAssesments",
                column: "AssesmentId",
                principalTable: "Assesments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDetailsAssesments_CourseDetails_CourseDetailsId",
                table: "CourseDetailsAssesments",
                column: "CourseDetailsId",
                principalTable: "CourseDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDetailsSkillLevels_CourseDetails_CourseDetailsId",
                table: "CourseDetailsSkillLevels",
                column: "CourseDetailsId",
                principalTable: "CourseDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDetailsSkillLevels_SkillLevels_SkillLevelId",
                table: "CourseDetailsSkillLevels",
                column: "SkillLevelId",
                principalTable: "SkillLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseDetailsAssesments_Assesments_AssesmentId",
                table: "CourseDetailsAssesments");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseDetailsAssesments_CourseDetails_CourseDetailsId",
                table: "CourseDetailsAssesments");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseDetailsSkillLevels_CourseDetails_CourseDetailsId",
                table: "CourseDetailsSkillLevels");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseDetailsSkillLevels_SkillLevels_SkillLevelId",
                table: "CourseDetailsSkillLevels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseDetailsSkillLevels",
                table: "CourseDetailsSkillLevels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseDetailsAssesments",
                table: "CourseDetailsAssesments");

            migrationBuilder.RenameTable(
                name: "CourseDetailsSkillLevels",
                newName: "CourseDetailsSkillLevel");

            migrationBuilder.RenameTable(
                name: "CourseDetailsAssesments",
                newName: "CourseDetailsAssesment");

            migrationBuilder.RenameIndex(
                name: "IX_CourseDetailsSkillLevels_SkillLevelId",
                table: "CourseDetailsSkillLevel",
                newName: "IX_CourseDetailsSkillLevel_SkillLevelId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseDetailsSkillLevels_CourseDetailsId",
                table: "CourseDetailsSkillLevel",
                newName: "IX_CourseDetailsSkillLevel_CourseDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseDetailsAssesments_CourseDetailsId",
                table: "CourseDetailsAssesment",
                newName: "IX_CourseDetailsAssesment_CourseDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseDetailsAssesments_AssesmentId",
                table: "CourseDetailsAssesment",
                newName: "IX_CourseDetailsAssesment_AssesmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseDetailsSkillLevel",
                table: "CourseDetailsSkillLevel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseDetailsAssesment",
                table: "CourseDetailsAssesment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDetailsAssesment_Assesments_AssesmentId",
                table: "CourseDetailsAssesment",
                column: "AssesmentId",
                principalTable: "Assesments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDetailsAssesment_CourseDetails_CourseDetailsId",
                table: "CourseDetailsAssesment",
                column: "CourseDetailsId",
                principalTable: "CourseDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDetailsSkillLevel_CourseDetails_CourseDetailsId",
                table: "CourseDetailsSkillLevel",
                column: "CourseDetailsId",
                principalTable: "CourseDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDetailsSkillLevel_SkillLevels_SkillLevelId",
                table: "CourseDetailsSkillLevel",
                column: "SkillLevelId",
                principalTable: "SkillLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

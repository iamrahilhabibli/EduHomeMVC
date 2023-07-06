using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduHome.DataAccess.Migrations
{
    public partial class tablesupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Assesment",
                table: "courseDetails");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "courseDetails");

            migrationBuilder.DropColumn(
                name: "SkillLevel",
                table: "courseDetails");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "courseDetails",
                newName: "Start");

            migrationBuilder.RenameColumn(
                name: "Fee",
                table: "courseDetails",
                newName: "CourseFee");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "courses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "courses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageName",
                table: "courses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "courses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Duration",
                table: "courseDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "AboutCourse",
                table: "courseDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AssesmentId",
                table: "courseDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Certification",
                table: "courseDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClassDuration",
                table: "courseDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HowToApply",
                table: "courseDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageOptionId",
                table: "courseDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SkillId",
                table: "courseDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Assesments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssesmentType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assesments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageOption = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SkillLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Skill = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillLevels", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_courseDetails_AssesmentId",
                table: "courseDetails",
                column: "AssesmentId");

            migrationBuilder.CreateIndex(
                name: "IX_courseDetails_LanguageOptionId",
                table: "courseDetails",
                column: "LanguageOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_courseDetails_SkillId",
                table: "courseDetails",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_courseDetails_Assesments_AssesmentId",
                table: "courseDetails",
                column: "AssesmentId",
                principalTable: "Assesments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_courseDetails_Languages_LanguageOptionId",
                table: "courseDetails",
                column: "LanguageOptionId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_courseDetails_SkillLevels_SkillId",
                table: "courseDetails",
                column: "SkillId",
                principalTable: "SkillLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courseDetails_Assesments_AssesmentId",
                table: "courseDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_courseDetails_Languages_LanguageOptionId",
                table: "courseDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_courseDetails_SkillLevels_SkillId",
                table: "courseDetails");

            migrationBuilder.DropTable(
                name: "Assesments");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "SkillLevels");

            migrationBuilder.DropIndex(
                name: "IX_courseDetails_AssesmentId",
                table: "courseDetails");

            migrationBuilder.DropIndex(
                name: "IX_courseDetails_LanguageOptionId",
                table: "courseDetails");

            migrationBuilder.DropIndex(
                name: "IX_courseDetails_SkillId",
                table: "courseDetails");

            migrationBuilder.DropColumn(
                name: "AboutCourse",
                table: "courseDetails");

            migrationBuilder.DropColumn(
                name: "AssesmentId",
                table: "courseDetails");

            migrationBuilder.DropColumn(
                name: "Certification",
                table: "courseDetails");

            migrationBuilder.DropColumn(
                name: "ClassDuration",
                table: "courseDetails");

            migrationBuilder.DropColumn(
                name: "HowToApply",
                table: "courseDetails");

            migrationBuilder.DropColumn(
                name: "LanguageOptionId",
                table: "courseDetails");

            migrationBuilder.DropColumn(
                name: "SkillId",
                table: "courseDetails");

            migrationBuilder.RenameColumn(
                name: "Start",
                table: "courseDetails",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "CourseFee",
                table: "courseDetails",
                newName: "Fee");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageName",
                table: "courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Duration",
                table: "courseDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Assesment",
                table: "courseDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "courseDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SkillLevel",
                table: "courseDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

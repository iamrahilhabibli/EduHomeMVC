using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduHome.DataAccess.Migrations
{
    public partial class EventADdedToDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Events_EventDetailsId",
                table: "Events");

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventDetailsId",
                table: "Events",
                column: "EventDetailsId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Events_EventDetailsId",
                table: "Events");

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventDetailsId",
                table: "Events",
                column: "EventDetailsId");
        }
    }
}

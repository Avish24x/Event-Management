using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event_Management_Appilcation.Migrations
{
    public partial class EventControllerreportingcontrollerfeedbackcontrollerteamMembercontrollerGroupControllercoreimplementation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupID",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReportID",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    ReportID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateGenerated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.ReportID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_ReportID",
                table: "Events",
                column: "ReportID");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Reports_ReportID",
                table: "Events",
                column: "ReportID",
                principalTable: "Reports",
                principalColumn: "ReportID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Reports_ReportID",
                table: "Events");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Events_ReportID",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "GroupID",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ReportID",
                table: "Events");
        }
    }
}

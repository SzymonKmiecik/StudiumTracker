using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudiumTracker.Data.Migrations
{
    public partial class AddedDbContextForLecturer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lecturers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Forename = table.Column<string>(maxLength: 250, nullable: false),
                    Surname = table.Column<string>(maxLength: 250, nullable: false),
                    Phone = table.Column<string>(maxLength: 25, nullable: false),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecturers", x => x.Id);
                });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropTable(
                name: "Lecturers");

        }
    }
}

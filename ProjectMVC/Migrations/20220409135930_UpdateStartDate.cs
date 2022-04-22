using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectMVC.Migrations
{
    public partial class UpdateStartDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StarDate",
                table: "Projects",
                newName: "StartDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Projects",
                newName: "StarDate");
        }
    }
}

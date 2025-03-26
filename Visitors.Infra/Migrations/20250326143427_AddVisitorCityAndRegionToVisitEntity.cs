using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Visitors.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddVisitorCityAndRegionToVisitEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Visits WHERE 1=1;");
            migrationBuilder.Sql("DELETE FROM Sites WHERE 1=1;");

            migrationBuilder.AddColumn<string>(
                name: "VisitorCity",
                table: "Visits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VisitorRegion",
                table: "Visits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VisitorCity",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "VisitorRegion",
                table: "Visits");
        }
    }
}

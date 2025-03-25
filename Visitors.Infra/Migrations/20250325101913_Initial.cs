using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Visitors.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Auto-generated ID for the site"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Site name"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date Created"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    IsActivated = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sites", x => x.Id);
                },
                comment: "Table for storing sites");

            migrationBuilder.CreateTable(
                name: "Visits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Auto-generated ID for the visit"),
                    VisitorIP = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Visitor IP address"),
                    VisitorCountry = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Visitor Country"),
                    VisitedAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date Visited"),
                    SiteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key referencing the Sites table"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    IsActivated = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visits_Sites_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Sites",
                        principalColumn: "Id");
                },
                comment: "Table for storing Visits");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_SiteId",
                table: "Visits",
                column: "SiteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Visits");

            migrationBuilder.DropTable(
                name: "Sites");
        }
    }
}

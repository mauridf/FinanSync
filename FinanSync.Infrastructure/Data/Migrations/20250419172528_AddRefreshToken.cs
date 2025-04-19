using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanSync.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "refreshtoken",
                table: "aspnetusers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "refreshtokenexpiry",
                table: "aspnetusers",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "refreshtoken",
                table: "aspnetusers");

            migrationBuilder.DropColumn(
                name: "refreshtokenexpiry",
                table: "aspnetusers");
        }
    }
}

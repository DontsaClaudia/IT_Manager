using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GesPark.Migrations
{
    /// <inheritdoc />
    public partial class Network : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DefaultIPGateway",
                table: "Network",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultIPGateway",
                table: "Network");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Musictify.Data.Migrations
{
    public partial class Seventh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinuteLength",
                table: "Songs");

            migrationBuilder.AddColumn<string>(
                name: "YoutubeLink",
                table: "Songs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YoutubeLink",
                table: "Songs");

            migrationBuilder.AddColumn<double>(
                name: "MinuteLength",
                table: "Songs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}

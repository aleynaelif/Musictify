using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Musictify.Data.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_Singer_SingerID",
                table: "Album");

            migrationBuilder.DropIndex(
                name: "IX_Album_SingerID",
                table: "Album");

            migrationBuilder.DropColumn(
                name: "SingerID",
                table: "Album");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                table: "Singer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                table: "Producer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "Album",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ProducerAlbum",
                columns: table => new
                {
                    ProducerAlbumID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlbumID = table.Column<int>(nullable: false),
                    ProducerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProducerAlbum", x => x.ProducerAlbumID);
                    table.ForeignKey(
                        name: "FK_ProducerAlbum_Album_AlbumID",
                        column: x => x.AlbumID,
                        principalTable: "Album",
                        principalColumn: "AlbumID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProducerAlbum_Producer_ProducerID",
                        column: x => x.ProducerID,
                        principalTable: "Producer",
                        principalColumn: "ProducerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SingerAlbum",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlbumID = table.Column<int>(nullable: false),
                    SingerID = table.Column<int>(nullable: false),
                    TrackNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SingerAlbum", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SingerAlbum_Album_AlbumID",
                        column: x => x.AlbumID,
                        principalTable: "Album",
                        principalColumn: "AlbumID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SingerAlbum_Singer_SingerID",
                        column: x => x.SingerID,
                        principalTable: "Singer",
                        principalColumn: "SingerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    SongsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SongsName = table.Column<string>(nullable: true),
                    MinuteLength = table.Column<double>(nullable: false),
                    Collab = table.Column<string>(nullable: true),
                    Lyrics = table.Column<string>(nullable: true),
                    AlbumID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.SongsID);
                    table.ForeignKey(
                        name: "FK_Songs_Album_AlbumID",
                        column: x => x.AlbumID,
                        principalTable: "Album",
                        principalColumn: "AlbumID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProducerSongs",
                columns: table => new
                {
                    ProducerSongsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProducerID = table.Column<int>(nullable: false),
                    SongsID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProducerSongs", x => x.ProducerSongsID);
                    table.ForeignKey(
                        name: "FK_ProducerSongs_Producer_ProducerID",
                        column: x => x.ProducerID,
                        principalTable: "Producer",
                        principalColumn: "ProducerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProducerSongs_Songs_SongsID",
                        column: x => x.SongsID,
                        principalTable: "Songs",
                        principalColumn: "SongsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SingerSongs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SingerID = table.Column<int>(nullable: false),
                    SongsID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SingerSongs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SingerSongs_Singer_SingerID",
                        column: x => x.SingerID,
                        principalTable: "Singer",
                        principalColumn: "SingerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SingerSongs_Songs_SongsID",
                        column: x => x.SongsID,
                        principalTable: "Songs",
                        principalColumn: "SongsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProducerAlbum_AlbumID",
                table: "ProducerAlbum",
                column: "AlbumID");

            migrationBuilder.CreateIndex(
                name: "IX_ProducerAlbum_ProducerID",
                table: "ProducerAlbum",
                column: "ProducerID");

            migrationBuilder.CreateIndex(
                name: "IX_ProducerSongs_ProducerID",
                table: "ProducerSongs",
                column: "ProducerID");

            migrationBuilder.CreateIndex(
                name: "IX_ProducerSongs_SongsID",
                table: "ProducerSongs",
                column: "SongsID");

            migrationBuilder.CreateIndex(
                name: "IX_SingerAlbum_AlbumID",
                table: "SingerAlbum",
                column: "AlbumID");

            migrationBuilder.CreateIndex(
                name: "IX_SingerAlbum_SingerID",
                table: "SingerAlbum",
                column: "SingerID");

            migrationBuilder.CreateIndex(
                name: "IX_SingerSongs_SingerID",
                table: "SingerSongs",
                column: "SingerID");

            migrationBuilder.CreateIndex(
                name: "IX_SingerSongs_SongsID",
                table: "SingerSongs",
                column: "SongsID");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_AlbumID",
                table: "Songs",
                column: "AlbumID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProducerAlbum");

            migrationBuilder.DropTable(
                name: "ProducerSongs");

            migrationBuilder.DropTable(
                name: "SingerAlbum");

            migrationBuilder.DropTable(
                name: "SingerSongs");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.AlterColumn<string>(
                name: "Birthday",
                table: "Singer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "Birthday",
                table: "Producer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "ReleaseDate",
                table: "Album",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<int>(
                name: "SingerID",
                table: "Album",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Album_SingerID",
                table: "Album",
                column: "SingerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Album_Singer_SingerID",
                table: "Album",
                column: "SingerID",
                principalTable: "Singer",
                principalColumn: "SingerID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

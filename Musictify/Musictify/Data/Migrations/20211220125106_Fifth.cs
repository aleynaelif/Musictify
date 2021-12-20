using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Musictify.Data.Migrations
{
    public partial class Fifth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PLaylistSongs_Playlist_PlaylistID",
                table: "PLaylistSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_PLaylistSongs_Songs_SongsID",
                table: "PLaylistSongs");

            migrationBuilder.DropTable(
                name: "ProducerAlbum");

            migrationBuilder.DropTable(
                name: "ProducerSongs");

            migrationBuilder.DropTable(
                name: "Producer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PLaylistSongs",
                table: "PLaylistSongs");

            migrationBuilder.DropColumn(
                name: "TotalTicketCapacity",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TrackNumber",
                table: "SingerAlbum");

            migrationBuilder.RenameTable(
                name: "PLaylistSongs",
                newName: "PlaylistSongs");

            migrationBuilder.RenameIndex(
                name: "IX_PLaylistSongs_SongsID",
                table: "PlaylistSongs",
                newName: "IX_PlaylistSongs_SongsID");

            migrationBuilder.RenameIndex(
                name: "IX_PLaylistSongs_PlaylistID",
                table: "PlaylistSongs",
                newName: "IX_PlaylistSongs_PlaylistID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlaylistSongs",
                table: "PlaylistSongs",
                column: "PlaylistSongsID");

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistSongs_Playlist_PlaylistID",
                table: "PlaylistSongs",
                column: "PlaylistID",
                principalTable: "Playlist",
                principalColumn: "PlaylistID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistSongs_Songs_SongsID",
                table: "PlaylistSongs",
                column: "SongsID",
                principalTable: "Songs",
                principalColumn: "SongsID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistSongs_Playlist_PlaylistID",
                table: "PlaylistSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistSongs_Songs_SongsID",
                table: "PlaylistSongs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlaylistSongs",
                table: "PlaylistSongs");

            migrationBuilder.RenameTable(
                name: "PlaylistSongs",
                newName: "PLaylistSongs");

            migrationBuilder.RenameIndex(
                name: "IX_PlaylistSongs_SongsID",
                table: "PLaylistSongs",
                newName: "IX_PLaylistSongs_SongsID");

            migrationBuilder.RenameIndex(
                name: "IX_PlaylistSongs_PlaylistID",
                table: "PLaylistSongs",
                newName: "IX_PLaylistSongs_PlaylistID");

            migrationBuilder.AddColumn<int>(
                name: "TotalTicketCapacity",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TrackNumber",
                table: "SingerAlbum",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PLaylistSongs",
                table: "PLaylistSongs",
                column: "PlaylistSongsID");

            migrationBuilder.CreateTable(
                name: "Producer",
                columns: table => new
                {
                    ProducerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProducerAge = table.Column<int>(type: "int", nullable: false),
                    ProducerDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProducerName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producer", x => x.ProducerID);
                });

            migrationBuilder.CreateTable(
                name: "ProducerAlbum",
                columns: table => new
                {
                    ProducerAlbumID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlbumID = table.Column<int>(type: "int", nullable: false),
                    ProducerID = table.Column<int>(type: "int", nullable: false)
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
                name: "ProducerSongs",
                columns: table => new
                {
                    ProducerSongsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProducerID = table.Column<int>(type: "int", nullable: false),
                    SongsID = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.AddForeignKey(
                name: "FK_PLaylistSongs_Playlist_PlaylistID",
                table: "PLaylistSongs",
                column: "PlaylistID",
                principalTable: "Playlist",
                principalColumn: "PlaylistID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PLaylistSongs_Songs_SongsID",
                table: "PLaylistSongs",
                column: "SongsID",
                principalTable: "Songs",
                principalColumn: "SongsID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

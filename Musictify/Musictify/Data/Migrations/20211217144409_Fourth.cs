using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Musictify.Data.Migrations
{
    public partial class Fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SingerSongs",
                table: "SingerSongs");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "SingerSongs");

            migrationBuilder.AddColumn<int>(
                name: "SingerSongsID",
                table: "SingerSongs",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SingerSongs",
                table: "SingerSongs",
                column: "SingerSongsID");

            migrationBuilder.CreateTable(
                name: "CD",
                columns: table => new
                {
                    CDID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CDName = table.Column<string>(nullable: true),
                    CDPrice = table.Column<double>(nullable: false),
                    CDImageURL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CD", x => x.CDID);
                });

            migrationBuilder.CreateTable(
                name: "Playlist",
                columns: table => new
                {
                    PlaylistID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaylistName = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    PlaylistDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlist", x => x.PlaylistID);
                });

            migrationBuilder.CreateTable(
                name: "Stadium",
                columns: table => new
                {
                    StadiumID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StadiumName = table.Column<string>(nullable: true),
                    StadiumCountry = table.Column<string>(nullable: true),
                    StadiumCity = table.Column<string>(nullable: true),
                    StadiumAdress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stadium", x => x.StadiumID);
                });

            migrationBuilder.CreateTable(
                name: "TicketPricings",
                columns: table => new
                {
                    TicketPricingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VipPrice = table.Column<double>(nullable: false),
                    BackstagePrice = table.Column<double>(nullable: false),
                    EarlyBirdPrice = table.Column<double>(nullable: false),
                    NormalPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketPricings", x => x.TicketPricingID);
                });

            migrationBuilder.CreateTable(
                name: "Vinyl",
                columns: table => new
                {
                    VinylID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VinylName = table.Column<string>(nullable: true),
                    VinylPrice = table.Column<double>(nullable: false),
                    VinylImageURL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vinyl", x => x.VinylID);
                });

            migrationBuilder.CreateTable(
                name: "PLaylistSongs",
                columns: table => new
                {
                    PlaylistSongsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaylistID = table.Column<int>(nullable: false),
                    SongsID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLaylistSongs", x => x.PlaylistSongsID);
                    table.ForeignKey(
                        name: "FK_PLaylistSongs_Playlist_PlaylistID",
                        column: x => x.PlaylistID,
                        principalTable: "Playlist",
                        principalColumn: "PlaylistID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PLaylistSongs_Songs_SongsID",
                        column: x => x.SongsID,
                        principalTable: "Songs",
                        principalColumn: "SongsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Concert",
                columns: table => new
                {
                    ConcertID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StadiumID = table.Column<int>(nullable: false),
                    ConcertDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concert", x => x.ConcertID);
                    table.ForeignKey(
                        name: "FK_Concert_Stadium_StadiumID",
                        column: x => x.StadiumID,
                        principalTable: "Stadium",
                        principalColumn: "StadiumID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseDate = table.Column<DateTime>(nullable: false),
                    TicketPricingID = table.Column<int>(nullable: false),
                    TotalTicketCapacity = table.Column<int>(nullable: false),
                    SeatRow = table.Column<int>(nullable: false),
                    SeatColumn = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketsID);
                    table.ForeignKey(
                        name: "FK_Tickets_TicketPricings_TicketPricingID",
                        column: x => x.TicketPricingID,
                        principalTable: "TicketPricings",
                        principalColumn: "TicketPricingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shop",
                columns: table => new
                {
                    ShopID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VinylID = table.Column<int>(nullable: false),
                    CDID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shop", x => x.ShopID);
                    table.ForeignKey(
                        name: "FK_Shop_CD_CDID",
                        column: x => x.CDID,
                        principalTable: "CD",
                        principalColumn: "CDID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shop_Vinyl_VinylID",
                        column: x => x.VinylID,
                        principalTable: "Vinyl",
                        principalColumn: "VinylID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConcertSinger",
                columns: table => new
                {
                    ConcertSingerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SingerID = table.Column<int>(nullable: false),
                    ConcertID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcertSinger", x => x.ConcertSingerID);
                    table.ForeignKey(
                        name: "FK_ConcertSinger_Concert_ConcertID",
                        column: x => x.ConcertID,
                        principalTable: "Concert",
                        principalColumn: "ConcertID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConcertSinger_Singer_SingerID",
                        column: x => x.SingerID,
                        principalTable: "Singer",
                        principalColumn: "SingerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Concert_StadiumID",
                table: "Concert",
                column: "StadiumID");

            migrationBuilder.CreateIndex(
                name: "IX_ConcertSinger_ConcertID",
                table: "ConcertSinger",
                column: "ConcertID");

            migrationBuilder.CreateIndex(
                name: "IX_ConcertSinger_SingerID",
                table: "ConcertSinger",
                column: "SingerID");

            migrationBuilder.CreateIndex(
                name: "IX_PLaylistSongs_PlaylistID",
                table: "PLaylistSongs",
                column: "PlaylistID");

            migrationBuilder.CreateIndex(
                name: "IX_PLaylistSongs_SongsID",
                table: "PLaylistSongs",
                column: "SongsID");

            migrationBuilder.CreateIndex(
                name: "IX_Shop_CDID",
                table: "Shop",
                column: "CDID");

            migrationBuilder.CreateIndex(
                name: "IX_Shop_VinylID",
                table: "Shop",
                column: "VinylID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketPricingID",
                table: "Tickets",
                column: "TicketPricingID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConcertSinger");

            migrationBuilder.DropTable(
                name: "PLaylistSongs");

            migrationBuilder.DropTable(
                name: "Shop");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Concert");

            migrationBuilder.DropTable(
                name: "Playlist");

            migrationBuilder.DropTable(
                name: "CD");

            migrationBuilder.DropTable(
                name: "Vinyl");

            migrationBuilder.DropTable(
                name: "TicketPricings");

            migrationBuilder.DropTable(
                name: "Stadium");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SingerSongs",
                table: "SingerSongs");

            migrationBuilder.DropColumn(
                name: "SingerSongsID",
                table: "SingerSongs");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "SingerSongs",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SingerSongs",
                table: "SingerSongs",
                column: "ID");
        }
    }
}

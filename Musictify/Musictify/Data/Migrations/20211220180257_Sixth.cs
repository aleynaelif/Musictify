using Microsoft.EntityFrameworkCore.Migrations;

namespace Musictify.Data.Migrations
{
    public partial class Sixth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConcertTickets",
                columns: table => new
                {
                    ConcertTicketsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConcertID = table.Column<int>(nullable: false),
                    TicketsID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcertTickets", x => x.ConcertTicketsID);
                    table.ForeignKey(
                        name: "FK_ConcertTickets_Concert_ConcertID",
                        column: x => x.ConcertID,
                        principalTable: "Concert",
                        principalColumn: "ConcertID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConcertTickets_Tickets_TicketsID",
                        column: x => x.TicketsID,
                        principalTable: "Tickets",
                        principalColumn: "TicketsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConcertTickets_ConcertID",
                table: "ConcertTickets",
                column: "ConcertID");

            migrationBuilder.CreateIndex(
                name: "IX_ConcertTickets_TicketsID",
                table: "ConcertTickets",
                column: "TicketsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConcertTickets");
        }
    }
}

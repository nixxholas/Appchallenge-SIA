using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SIAHTTPS.Data.Migrations
{
    public partial class setupdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aircrafts",
                columns: table => new
                {
                    AircraftId = table.Column<int>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Brand = table.Column<string>(type: "VARCHAR(MAX)", nullable: false),
                    FlightNumber = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Model = table.Column<string>(type: "VARCHAR(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_Aircraft_AircraftId", x => x.AircraftId);
                });

            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    AirportId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(type: "VARCHAR(MAX)", nullable: false),
                    Country = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    CountryAbbreviation = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    CountryCode = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    IATACode = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_Airport_AirportId", x => x.AirportId);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ETA = table.Column<DateTime>(nullable: false),
                    TakeoffDT = table.Column<DateTime>(nullable: false),
                    TouchDownDT = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_Flight_FlightId", x => x.FlightId);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TicketName = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    TicketType = table.Column<string>(type: "VARCHAR(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_Tickets_TicketId", x => x.TicketId);
                });

            migrationBuilder.CreateTable(
                name: "Terminals",
                columns: table => new
                {
                    AirportId = table.Column<long>(type: "bigint", nullable: false),
                    TerminalId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TerminalName = table.Column<string>(type: "VARCHAR(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_Terminal_TerminalId", x => new { x.AirportId, x.TerminalId });
                    table.ForeignKey(
                        name: "FK_Terminals_Airports_AirportId",
                        column: x => x.AirportId,
                        principalTable: "Airports",
                        principalColumn: "AirportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AircraftFlights",
                columns: table => new
                {
                    AircraftId = table.Column<int>(nullable: false),
                    FlightId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("AircraftFlights_CompositeKey", x => new { x.AircraftId, x.FlightId });
                    table.ForeignKey(
                        name: "FK_AircraftFlights_Aircrafts_AircraftId",
                        column: x => x.AircraftId,
                        principalTable: "Aircrafts",
                        principalColumn: "AircraftId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AircraftFlights_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AirportFlights",
                columns: table => new
                {
                    AirportId = table.Column<long>(nullable: false),
                    FlightId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("AirportFlights_CompositeKey", x => new { x.AirportId, x.FlightId });
                    table.ForeignKey(
                        name: "FK_AirportFlights_Airports_AirportId",
                        column: x => x.AirportId,
                        principalTable: "Airports",
                        principalColumn: "AirportId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AirportFlights_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlightTickets",
                columns: table => new
                {
                    FlightId = table.Column<long>(nullable: false),
                    TicketId = table.Column<long>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(19, 2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("FlightTickets_CompositeKey", x => new { x.FlightId, x.TicketId });
                    table.ForeignKey(
                        name: "FK_FlightTickets_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlightTickets_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "TicketId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "Aircraft_FlightNumber_UniqueConstraint",
                table: "Aircrafts",
                column: "FlightNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AircraftFlights_AircraftId",
                table: "AircraftFlights",
                column: "AircraftId");

            migrationBuilder.CreateIndex(
                name: "IX_AircraftFlights_FlightId",
                table: "AircraftFlights",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_AirportFlights_AirportId",
                table: "AirportFlights",
                column: "AirportId");

            migrationBuilder.CreateIndex(
                name: "IX_AirportFlights_FlightId",
                table: "AirportFlights",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightTickets_FlightId",
                table: "FlightTickets",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightTickets_TicketId",
                table: "FlightTickets",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Terminals_AirportId",
                table: "Terminals",
                column: "AirportId");

            migrationBuilder.CreateIndex(
                name: "Ticket_TicketType_UniqueConstraint",
                table: "Tickets",
                column: "TicketType",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AircraftFlights");

            migrationBuilder.DropTable(
                name: "AirportFlights");

            migrationBuilder.DropTable(
                name: "FlightTickets");

            migrationBuilder.DropTable(
                name: "Terminals");

            migrationBuilder.DropTable(
                name: "Aircrafts");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Airports");
        }
    }
}

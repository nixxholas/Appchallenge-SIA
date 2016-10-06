using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SIAHTTPS.Data;

namespace SIAHTTPS.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SIAHTTPS.Models.Aircraft", b =>
                {
                    b.Property<int>("AircraftId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("AircraftId")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnName("Brand")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<string>("FlightNumber")
                        .IsRequired()
                        .HasColumnName("FlightNumber")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnName("Model")
                        .HasColumnType("VARCHAR(MAX)");

                    b.HasKey("AircraftId")
                        .HasName("PrimaryKey_Aircrafts_AircraftId");

                    b.HasIndex("FlightNumber")
                        .IsUnique()
                        .HasName("Aircrafts_FlightNumber_UniqueConstraint");

                    b.ToTable("Aircraft");
                });

            modelBuilder.Entity("SIAHTTPS.Models.Airport", b =>
                {
                    b.Property<long>("AirportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("AirportId")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnName("City")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnName("Country")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("CountryAbbreviation")
                        .IsRequired()
                        .HasColumnName("CountryAbbreviation")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasColumnName("CountryCode")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("IATACode")
                        .IsRequired()
                        .HasColumnName("IATACode")
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("AirportId")
                        .HasName("PrimaryKey_Airports_AirportId");

                    b.HasIndex("IATACode")
                        .IsUnique()
                        .HasName("Airports_IATACode_UniqueConstraint");

                    b.ToTable("Airport");
                });

            modelBuilder.Entity("SIAHTTPS.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FullName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("SIAHTTPS.Models.EndTermFlight", b =>
                {
                    b.Property<long>("TerminalId");

                    b.Property<long>("FlightId");

                    b.Property<long?>("TerminalAirportId");

                    b.Property<long?>("TerminalId1");

                    b.HasKey("TerminalId", "FlightId")
                        .HasName("EndTermFlights_CompositeKey");

                    b.HasIndex("FlightId")
                        .IsUnique();

                    b.HasIndex("TerminalAirportId", "TerminalId1");

                    b.ToTable("EndTermFlight");
                });

            modelBuilder.Entity("SIAHTTPS.Models.Flight", b =>
                {
                    b.Property<long>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("FlightId")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AircraftId");

                    b.Property<long>("ETA")
                        .HasColumnName("ETA")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("TakeoffDT")
                        .HasColumnName("TakeoffDT");

                    b.Property<DateTime>("TouchDownDT")
                        .HasColumnName("TouchDownDT");

                    b.HasKey("FlightId")
                        .HasName("PrimaryKey_Flights_FlightId");

                    b.HasIndex("AircraftId");

                    b.ToTable("Flight");
                });

            modelBuilder.Entity("SIAHTTPS.Models.FlightTicket", b =>
                {
                    b.Property<long>("FlightId");

                    b.Property<long>("TicketId");

                    b.Property<decimal>("Price")
                        .HasColumnName("Price")
                        .HasColumnType("decimal(19, 2)");

                    b.Property<int>("Quantity")
                        .HasColumnName("Quantity")
                        .HasColumnType("int");

                    b.HasKey("FlightId", "TicketId")
                        .HasName("FlightTickets_CompositeKey");

                    b.HasIndex("FlightId");

                    b.HasIndex("TicketId");

                    b.ToTable("FlightTicket");
                });

            modelBuilder.Entity("SIAHTTPS.Models.StartTermFlight", b =>
                {
                    b.Property<long>("TerminalId");

                    b.Property<long>("FlightId");

                    b.Property<long?>("TerminalAirportId");

                    b.Property<long?>("TerminalId1");

                    b.HasKey("TerminalId", "FlightId")
                        .HasName("StartTermFlights_CompositeKey");

                    b.HasIndex("FlightId")
                        .IsUnique();

                    b.HasIndex("TerminalAirportId", "TerminalId1");

                    b.ToTable("StartTermFlight");
                });

            modelBuilder.Entity("SIAHTTPS.Models.Terminal", b =>
                {
                    b.Property<long>("AirportId")
                        .HasColumnName("AirportId")
                        .HasColumnType("bigint");

                    b.Property<long>("TerminalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TerminalId")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TerminalName")
                        .IsRequired()
                        .HasColumnName("TerminalName")
                        .HasColumnType("VARCHAR(MAX)");

                    b.HasKey("AirportId", "TerminalId")
                        .HasName("PrimaryKey_Terminals_TerminalId");

                    b.HasIndex("AirportId");

                    b.ToTable("Terminal");
                });

            modelBuilder.Entity("SIAHTTPS.Models.Ticket", b =>
                {
                    b.Property<long>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TicketId")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TicketName")
                        .HasColumnName("TicketName")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<string>("TicketType")
                        .HasColumnName("TicketType")
                        .HasColumnType("VARCHAR(300)");

                    b.HasKey("TicketId")
                        .HasName("PrimaryKey_Tickets_TicketId");

                    b.HasIndex("TicketType")
                        .IsUnique()
                        .HasName("Tickets_TicketType_UniqueConstraint");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SIAHTTPS.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SIAHTTPS.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SIAHTTPS.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SIAHTTPS.Models.EndTermFlight", b =>
                {
                    b.HasOne("SIAHTTPS.Models.Flight", "Flight")
                        .WithOne("EndTermFlight")
                        .HasForeignKey("SIAHTTPS.Models.EndTermFlight", "FlightId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SIAHTTPS.Models.Terminal", "Terminal")
                        .WithMany("EndTermFlights")
                        .HasForeignKey("TerminalAirportId", "TerminalId1");
                });

            modelBuilder.Entity("SIAHTTPS.Models.Flight", b =>
                {
                    b.HasOne("SIAHTTPS.Models.Aircraft", "Aircraft")
                        .WithMany("Flights")
                        .HasForeignKey("AircraftId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SIAHTTPS.Models.FlightTicket", b =>
                {
                    b.HasOne("SIAHTTPS.Models.Flight", "Flight")
                        .WithMany("FlightTickets")
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SIAHTTPS.Models.Ticket", "Ticket")
                        .WithMany("FlightTickets")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SIAHTTPS.Models.StartTermFlight", b =>
                {
                    b.HasOne("SIAHTTPS.Models.Flight", "Flight")
                        .WithOne("StartTermFlight")
                        .HasForeignKey("SIAHTTPS.Models.StartTermFlight", "FlightId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SIAHTTPS.Models.Terminal", "Terminal")
                        .WithMany("StartTermFlights")
                        .HasForeignKey("TerminalAirportId", "TerminalId1");
                });

            modelBuilder.Entity("SIAHTTPS.Models.Terminal", b =>
                {
                    b.HasOne("SIAHTTPS.Models.Airport", "Airport")
                        .WithMany("Terminals")
                        .HasForeignKey("AirportId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}

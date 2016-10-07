using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using SIAHTTPS.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SIAHTTPS.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Aircraft> Aircrafts { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<StartTermFlight> StartTermFlights { get; set; }
        public DbSet<EndTermFlight> EndTermFlights { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<FlightTicket> FlightTickets { get; set; }
        public DbSet<Terminal> Terminals { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        //    : base(options)
        //{
        //}

        //

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=DIT-NB1530078\SQLEXPRESS;database=SIA;Trusted_Connection=True;MultipleActiveResultSets=True");
            optionsBuilder.UseSqlServer(@"Server=tcp:siahttps.database.windows.net,1433;Initial Catalog=siahttps;Persist Security Info=False;User ID=jingyen;Password=FuckW3IweN!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var entity in builder.Model.GetEntityTypes())
            {
                entity.Relational().TableName = entity.DisplayName();
            }

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            // -------------- Defining Aircraft Entity --------------- //
            builder.Entity<Aircraft>()
                .HasKey(input => input.AircraftId)
                .HasName("PrimaryKey_Aircrafts_AircraftId");

            builder.Entity<Aircraft>()
                .Property(input => input.AircraftId)
                .HasColumnName("AircraftId")
                .HasColumnType("int")
                .UseSqlServerIdentityColumn()
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Entity<Aircraft>()
                .Property(input => input.Model)
                .HasColumnName("Model")
                .HasColumnType("VARCHAR(MAX)")
                .IsRequired();

            builder.Entity<Aircraft>()
                .Property(input => input.Brand)
                .HasColumnName("Brand")
                .HasColumnType("VARCHAR(MAX)")
                .IsRequired();

            builder.Entity<Aircraft>()
                .Property(input => input.FlightNumber)
                .HasColumnName("FlightNumber")
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            // Enforce Unique Constraint on FlightNumber
            builder.Entity<Aircraft>()
                .HasIndex(input => input.FlightNumber).IsUnique()
                .HasName("Aircrafts_FlightNumber_UniqueConstraint");

            // Foreign Relationships
            builder.Entity<Aircraft>()
                .HasMany(input => input.Flights)
                .WithOne(input => input.Aircraft)
                .HasForeignKey(input => input.AircraftId);
           
            // -------------- Aircraft Entity END --------------- //
            
            // -------------- Defining Airport Entity --------------- //
            builder.Entity<Airport>()
                .HasKey(input => input.AirportId)
                .HasName("PrimaryKey_Airports_AirportId");

            builder.Entity<Airport>()
                .Property(input => input.AirportId)
                .HasColumnName("AirportId")
                .HasColumnType("bigint")
                .UseSqlServerIdentityColumn()
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Entity<Airport>()
                .Property(input => input.IATACode)
                .HasColumnName("IATACode")
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            builder.Entity<Airport>()
                .Property(input => input.City)
                .HasColumnName("City")
                .HasColumnType("VARCHAR(MAX)")
                .IsRequired();

            builder.Entity<Airport>()
                .Property(input => input.Country)
                .HasColumnName("Country")
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            builder.Entity<Airport>()
                .Property(input => input.CountryCode)
                .HasColumnName("CountryCode")
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            builder.Entity<Airport>()
                .Property(input => input.CountryAbbreviation)
                .HasColumnName("CountryAbbreviation")
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            // Enforce Unique Constraint on IATACode
            builder.Entity<Airport>()
                .HasIndex(input => input.IATACode).IsUnique()
                .HasName("Airports_IATACode_UniqueConstraint");

            // Foreign Relationships
            builder.Entity<Airport>()
                .HasMany(input => input.Terminals)
                .WithOne(input => input.Airport)
                .HasForeignKey(input => input.AirportId);

            // -------------- Airport Entity END --------------- //

            // -------------- Defining StartTermFlights Entity --------------- //

            builder.Entity<StartTermFlight>()
                .HasKey(input => new { input.TerminalId, input.FlightId})
                .HasName("StartTermFlights_CompositeKey");

            // -------------- StartTermFlights Entity END --------------- //

            // -------------- Defining EndTermFlights Entity --------------- //

            builder.Entity<EndTermFlight>()
                .HasKey(input => new { input.TerminalId, input.FlightId })
                .HasName("EndTermFlights_CompositeKey");

            // -------------- EndTermFlights Entity END --------------- //

            // -------------- Defining Flight Entity --------------- //
            builder.Entity<Flight>()
                .HasKey(input => input.FlightId)
                .HasName("PrimaryKey_Flights_FlightId");

            builder.Entity<Flight>()
                .Property(input => input.FlightId)
                .HasColumnName("FlightId")
                .HasColumnType("bigint")
                .UseSqlServerIdentityColumn()
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Entity<Flight>()
                .Property(input => input.ETA)
                .HasColumnName("ETA")
				.HasColumnType("bigint")
                .IsRequired();

            builder.Entity<Flight>()
                .Property(input => input.TakeoffDT)
                .HasColumnName("TakeoffDT")
                .IsRequired();

            builder.Entity<Flight>()
                .Property(input => input.TouchDownDT)
                .HasColumnName("TouchDownDT")
                .IsRequired();

            // Foreign Relationships
            builder.Entity<Flight>()
                .HasOne(input => input.StartTermFlight)
                .WithOne(input => input.Flight);

            builder.Entity<Flight>()
                .HasOne(input => input.EndTermFlight)
                .WithOne(input => input.Flight);

            builder.Entity<Flight>()
                .HasMany(input => input.FlightTickets)
                .WithOne(input => input.Flight)
                .HasForeignKey(input => input.FlightId);

            builder.Entity<Flight>()
                .HasOne(input => input.Aircraft)
                .WithMany(input => input.Flights)
                .HasForeignKey(input => input.AircraftId);

            // -------------- Flight Entity END --------------- //

            // -------------- Defining FlightTickets Entity --------------- //
            builder.Entity<FlightTicket>()
                .HasKey(input => new { input.FlightId, input.TicketId })
                .HasName("FlightTickets_CompositeKey");

            builder.Entity<FlightTicket>()
                .Property(input => input.Price)
                .HasColumnName("Price")
                .HasColumnType("decimal(19, 2)")
                .IsRequired();

            builder.Entity<FlightTicket>()
                .Property(input => input.Quantity)
                .HasColumnName("Quantity")
                .HasColumnType("int")
                .IsRequired();

            builder.Entity<FlightTicket>()
                .Property(input => input.CreatedAt)
                .HasDefaultValueSql("GETDATE()")
                .IsRequired();

            // -------------- FlightTickets Entity END --------------- //

            // -------------- Defining Terminal Entity --------------- //
            builder.Entity<Terminal>()
                .HasKey(input => new { input.AirportId, input.TerminalId })
                .HasName("PrimaryKey_Terminals_TerminalId");

            builder.Entity<Terminal>()
                .Property(input => input.TerminalId)
                .HasColumnName("TerminalId")
                .HasColumnType("bigint")
                .UseSqlServerIdentityColumn()
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Entity<Terminal>()
                .Property(input => input.TerminalName)
                .HasColumnName("TerminalName")
                .HasColumnType("VARCHAR(MAX)")
                .IsRequired();

            builder.Entity<Terminal>()
                .Property(input => input.AirportId)
                .HasColumnName("AirportId")
                .HasColumnType("bigint")
                .IsRequired();

            // Foreign Key Relationships
            //builder.Entity<Terminal>()
            //    .HasMany(input => input.StartTermFlights)
            //    .WithOne(input => input.Terminal)
            //    .HasForeignKey(input => input.TerminalId);

            //builder.Entity<Terminal>()
            //    .HasMany(input => input.EndTermFlights)
            //    .WithOne(input => input.Terminal)
            //    .HasForeignKey(input => input.TerminalId);
            
            // -------------- Terminal Entity END --------------- //

            // -------------- Defining Ticket Entity --------------- //
            builder.Entity<Ticket>()
                .HasKey(input => input.TicketId)
                .HasName("PrimaryKey_Tickets_TicketId");

            builder.Entity<Ticket>()
                .Property(input => input.TicketId)
                .HasColumnName("TicketId")
                .HasColumnType("bigint")
                .UseSqlServerIdentityColumn()
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Entity<Ticket>()
                .Property(input => input.TicketType)
                .HasColumnName("TicketType")
                .HasColumnType("VARCHAR(300)");

            builder.Entity<Ticket>()
                .Property(input => input.TicketName)
                .HasColumnName("TicketName")
                .HasColumnType("VARCHAR(MAX)");

            // Enforce Unique Constraint on TicketType
            builder.Entity<Ticket>()
                .HasIndex(input => input.TicketType).IsUnique()
                .HasName("Tickets_TicketType_UniqueConstraint");

            // -------------- Ticket Entity END --------------- //

            base.OnModelCreating(builder);
        }
    }
}

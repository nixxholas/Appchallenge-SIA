using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SIAHTTPS.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SIAHTTPS.Models
{
    public static class DataSeeder
    {
        public static async void SeedData(this IApplicationBuilder app)
        {
            var db = app.ApplicationServices.GetService<ApplicationDbContext>();

            //This is to make sure that the migration, seeding is done only when there are no students found in User table.
            //If there are student records found in User table, I will assume that, better don't do seeding.
            //The if statement block is to check whether there are records in the User table.
            //The db.Users will know. You call the Any() method to check
            //The purpose of having this if block here (which covers amost the entire SeedData() method)

            //Caution: Clear all the tables in the database first.
            db.Database.Migrate();


            //RoleStore needs using Microsoft.AspNet.Identity.EntityFramework;
            var identityRoleStore = new RoleStore<IdentityRole>(db);
            var identityRoleManager = new RoleManager<IdentityRole>(identityRoleStore, null, null, null, null, null);

            var superAdminRole = new IdentityRole { Name = "SUPER ADMIN" };
            await identityRoleManager.CreateAsync(superAdminRole);

            var adminRole = new IdentityRole { Name = "ADMIN" };
            await identityRoleManager.CreateAsync(adminRole);

            var officerRole = new IdentityRole { Name = "OFFICER" };
            await identityRoleManager.CreateAsync(officerRole);

            var customerRole = new IdentityRole { Name = "USER" };
            await identityRoleManager.CreateAsync(customerRole);

            var userStore = new UserStore<ApplicationUser>(db);
            var userManager = new UserManager<ApplicationUser>(userStore, null, null, null, null, null, null, null, null);


            var danielUser = new ApplicationUser { UserName = "88881", Email = "DANIEL@EMU.COM", FullName = "DANIEL" };
            PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
            danielUser.PasswordHash = ph.HashPassword(danielUser, "P@ssw0rd"); //More complex password
            await userManager.CreateAsync(danielUser);

            await userManager.AddToRoleAsync(danielUser, "SUPER ADMIN");



            var susanUser = new ApplicationUser { UserName = "88882", Email = "SUSAN@EMU.COM", FullName = "SUSAN" };
            susanUser.PasswordHash = ph.HashPassword(susanUser, "P@ssw0rd"); //More complex password
            await userManager.CreateAsync(susanUser);

            await userManager.AddToRoleAsync(susanUser, "ADMIN");

            var randyUser = new ApplicationUser { UserName = "88883", Email = "RANDY@EMU.COM", FullName = "RANDY" };
            randyUser.PasswordHash = ph.HashPassword(randyUser, "P@ssw0rd"); //More complex password
            await userManager.CreateAsync(randyUser);

            await userManager.AddToRoleAsync(randyUser, "OFFICER");


            var thomasUser = new ApplicationUser { UserName = "88884", Email = "THOMAS@EMU.COM", FullName = "THOMAS" };
            thomasUser.PasswordHash = ph.HashPassword(thomasUser, "P@ssw0rd"); //More complex password

            await userManager.CreateAsync(thomasUser);
            await userManager.AddToRoleAsync(thomasUser, "OFFICER");

            var benUser = new ApplicationUser { UserName = "88885", Email = "BEN@EMU.COM", FullName = "BEN" };
            benUser.PasswordHash = ph.HashPassword(benUser, "P@ssw0rd"); //More complex password

            await userManager.CreateAsync(benUser);

            await userManager.AddToRoleAsync(benUser, "OFFICER");

            var gabrielUser = new ApplicationUser { UserName = "88886", Email = "GABRIEL@EMU.COM", FullName = "GABRIEL" };
            gabrielUser.PasswordHash = ph.HashPassword(gabrielUser, "P@ssw0rd"); //More complex password

            //Use the UserManager class instance, userManager
            //which manages the many-to-many AspNetUserRoles table
            //to create a user, Gabriel.
            await userManager.CreateAsync(gabrielUser); //Add the user
                                                        //Use the UserManager class instance, userManager
                                                        //which also manages the many-to-many AspNetUserRoles table
                                                        //to create a relationship describing that, Gabriel user is an OFFICER role user
            await userManager.AddToRoleAsync(gabrielUser, "OFFICER");

            var fredUser = new ApplicationUser { UserName = "88887", Email = "FRED@EMU.COM", FullName = "FRED" };
            fredUser.PasswordHash = ph.HashPassword(fredUser, "P@ssw0rd"); //More complex password

            //Use the UserManager class instance, userManager
            //which manages the many-to-many AspNetUserRoles table
            //to create a user, Fred.
            await userManager.CreateAsync(fredUser); //Add the user
                                                     //Use the UserManager class instance, userManager
                                                     //which also manages the many-to-many AspNetUserRoles table
                                                     //to create a relationship describing that, Fred user is an OFFICER role user
            await userManager.AddToRoleAsync(fredUser, "OFFICER");

            // End of DataSeeder for User accounts

            // DataSeeder for Tables

            // Aircraft Seeding

            Aircraft SQ603;
            SQ603 = new Aircraft()
            {
                Model = "A380-800",
                Brand = "Airbus",
                FlightNumber = "SQ603"
            };

            db.Aircrafts.Add(SQ603);

            Aircraft SQ418;
            SQ418 = new Aircraft()
            {
                Model = "A380-800",
                Brand = "Airbus",
                FlightNumber = "SQ418"
            };

            db.Aircrafts.Add(SQ418);


            Aircraft SQ852;
            SQ852 = new Aircraft()
            {
                Model = "777-300ER",
                Brand = "Boeing",
                FlightNumber = "SQ852"
            };

            db.Aircrafts.Add(SQ852);


            Aircraft SQ349;
            SQ349 = new Aircraft()
            {
                Model = "777-200",
                Brand = "Boeing",
                FlightNumber = "SQ349"
            };

            db.Aircrafts.Add(SQ349);


            Aircraft SQ225;
            SQ225 = new Aircraft()
            {
                Model = "777-300",
                Brand = "Boeing",
                FlightNumber = "SQ225"
            };

            db.Aircrafts.Add(SQ225);


            Aircraft SQ709;
            SQ709 = new Aircraft()
            {
                Model = "A350-900",
                Brand = "Airbus",
                FlightNumber = "SQ709"
            };

            db.Aircrafts.Add(SQ709);


            Aircraft SQ794;
            SQ794 = new Aircraft()
            {
                Model = "A380-800",
                Brand = "Airbus",
                FlightNumber = "SQ794"
            };

            db.Aircrafts.Add(SQ794);


            Aircraft SQ599;
            SQ599 = new Aircraft()
            {
                Model = "777-200ER",
                Brand = "Boeing",
                FlightNumber = "SQ599"
            };

            db.Aircrafts.Add(SQ599);


            Aircraft SQ279;
            SQ279 = new Aircraft()
            {
                Model = "777-300",
                Brand = "Boeing",
                FlightNumber = "SQ279"
            };

            db.Aircrafts.Add(SQ279);


            Aircraft SQ018;
            SQ018 = new Aircraft()
            {
                Model = "777-200ER",
                Brand = "Boeing",
                FlightNumber = "SQ018"
            };

            db.Aircrafts.Add(SQ018);

            Aircraft SQ324;
            SQ324 = new Aircraft()
            {
                Model = "A350-900",
                Brand = "Airbus",
                FlightNumber = "SQ324"
            };
            db.Aircrafts.Add(SQ324);

            Airport airport1;
            airport1 = new Airport()
            {
                IATACode = "SIN",
                City = "Singapore City",
                Country = "Singapore",
                CountryCode = "+65",
                CountryAbbreviation = "SG"
            };

            db.Airports.Add(airport1);

            Airport airport2;
            airport2 = new Airport()
            {
                IATACode = "SIR",
                City = "Sion",
                Country = "Switzerland",
                CountryCode = "+27",
                CountryAbbreviation = "CH"
            };

            db.Airports.Add(airport2);

            Airport airport3;
            airport3 = new Airport()
            {
                IATACode = "PEK",
                City = "Beijing",
                Country = "China",
                CountryCode = "+86",
                CountryAbbreviation = "CN"
            };

            db.Airports.Add(airport3);

            Airport airport4;
            airport4 = new Airport()
            {
                IATACode = "AMS",
                Country = "Netherlands",
                City = "Amsterdam",
                CountryCode = "+31",
                CountryAbbreviation = "AN"
            };
            db.Airports.Add(airport4);

            Ticket firstClass;
            firstClass = new Ticket()
            {
                TicketType = "First Class",
                TicketName = ""
            };
            db.Tickets.Add(firstClass);

            Ticket business;
            business = new Ticket()
            {
                TicketType = "Business Class",
                TicketName = ""
            };
            db.Tickets.Add(business);

            Ticket suites;
            suites = new Ticket()
            {
                TicketType = "Suites",
                TicketName = ""
            };
            db.Tickets.Add(suites);

            Ticket premiumEconomy;
            premiumEconomy = new Ticket()
            {
                TicketType = "Premium Economy Class",
                TicketName = ""
            };
            db.Tickets.Add(premiumEconomy);

            Ticket economy;
            economy = new Ticket()
            {
                TicketType = "Economy Class",
                TicketName = ""
            };
            db.Tickets.Add(economy);

            Terminal terminal1;
            terminal1 = new Terminal()
            {
                TerminalName = "Terminal 1",
                Airport = airport1
            };
            db.Terminals.Add(terminal1);

            Terminal terminal2;
            terminal2 = new Terminal()
            {
                TerminalName = "Terminal 2",
                Airport = airport2
            };
            db.Terminals.Add(terminal2);

            Terminal terminal3;
            terminal3 = new Terminal()
            {
                TerminalName = "Terminal 3",
                Airport = airport3
            };
            db.Terminals.Add(terminal3);

            Terminal terminal4;
            terminal4 = new Terminal()
            {
                TerminalName = "Terminal 4",
                Airport = airport4
            };
            db.Terminals.Add(terminal4);

            Flight flight1;
            flight1 = new Flight()
            {
                TakeoffDT = new DateTime(2016, 10, 10, 4, 30, 00),
                TouchDownDT = new DateTime(2016, 10, 10, 11, 30, 00),
                ETA = new DateTime(2016, 10, 10, 11, 30, 00).Subtract(new DateTime(2016, 10, 10, 4, 30, 00)).Ticks,
                StartTermFlight = new StartTermFlight()
                {
                    Terminal = terminal1
                },
                EndTermFlight = new EndTermFlight()
                {

                    Terminal = terminal3
                }
            };
            db.Flights.Add(flight1);

            StartTermFlight stf1;
            stf1 = new StartTermFlight()
            {
                Flight = flight1,
                Terminal = terminal1
            };
            db.StartTermFlights.Add(stf1);

            EndTermFlight etf1;
            etf1 = new EndTermFlight()
            {
                Flight = flight1,
                Terminal = terminal3
            };
            db.EndTermFlights.Add(etf1);

            Flight flight2;
            flight2 = new Flight()
            {
                TakeoffDT = new DateTime(2016, 10, 6, 00, 05, 00),
                TouchDownDT = new DateTime(2016, 10, 6, 06, 35, 00),
                ETA = new DateTime(2016, 10, 6, 06, 35, 00).Subtract(new DateTime(2016, 10, 6, 00, 05, 00)).Ticks,
                StartTermFlight = new StartTermFlight()
                {

                    Terminal = terminal3
                },
                EndTermFlight = new EndTermFlight()
                {
                    Terminal = terminal1
                }
            };
            db.Flights.Add(flight2);

            StartTermFlight stf2;
            stf2 = new StartTermFlight()
            {
                Flight = flight2,
                Terminal = terminal3
            };
            db.StartTermFlights.Add(stf2);

            EndTermFlight etf2;
            etf2 = new EndTermFlight()
            {
                Flight = flight2,
                Terminal = terminal1
            };
            db.EndTermFlights.Add(etf2);

            Flight flight3;
            flight3 = new Flight()
            {
                TakeoffDT = new DateTime(2016, 10, 4, 11, 04, 00),
                TouchDownDT = new DateTime(2016, 10, 5, 05, 55, 00),
                ETA = new DateTime(2016, 10, 5, 05, 55, 00).Subtract(new DateTime(2016, 10, 4, 11, 04, 00)).Ticks,
                StartTermFlight = new StartTermFlight()
                {
                    Terminal = terminal4
                },
                EndTermFlight = new EndTermFlight()
                {
                    Terminal = terminal1
                }
            };
            db.Flights.Add(flight3);

            StartTermFlight stf3;
            stf3 = new StartTermFlight()
            {
                Flight = flight3,
                Terminal = terminal4
            };
            db.StartTermFlights.Add(stf1);

            EndTermFlight etf3;
            etf3 = new EndTermFlight()
            {
                Flight = flight3,
                Terminal = terminal1
            };
            db.EndTermFlights.Add(etf3);

            Flight flight4;
            flight4 = new Flight()
            {
                TakeoffDT = new DateTime(2016, 10, 13, 08, 55, 00),
                TouchDownDT = new DateTime(2016, 10, 13, 15, 20, 00),
                ETA = new DateTime(2016, 10, 13, 15, 20, 00).Subtract(new DateTime(2016, 10, 13, 08, 55, 00)).Ticks,
                StartTermFlight = new StartTermFlight()
                {
                    Terminal = terminal4
                },
                EndTermFlight = new EndTermFlight()
                {

                    Terminal = terminal1
                }
            };
            db.Flights.Add(flight4);

            StartTermFlight stf4;
            stf4 = new StartTermFlight()
            {
                Flight = flight4,
                Terminal = terminal4
            };
            db.StartTermFlights.Add(stf4);

            EndTermFlight etf4;
            etf4 = new EndTermFlight()
            {
                Flight = flight4,
                Terminal = terminal1
            };
            db.EndTermFlights.Add(etf4);

            Flight oldshit1;
            oldshit1 = new Flight()
            {
                TakeoffDT = new DateTime(2016, 09, 06, 00, 19, 00),
                TouchDownDT = new DateTime(2016, 09, 06, 07, 15, 00),
                ETA = new DateTime(2016, 09, 06, 07, 15, 00).Subtract(new DateTime(2016, 09, 06, 00, 19, 00)).Ticks,
                StartTermFlight = new StartTermFlight()
                {

                    Terminal = terminal1
                },
                EndTermFlight = new EndTermFlight()
                {

                    Terminal = terminal4
                }
            };
            db.Flights.Add(oldshit1);

            StartTermFlight ostf1;
            ostf1 = new StartTermFlight()
            {
                Flight = oldshit1,
                Terminal = terminal1
            };
            db.StartTermFlights.Add(ostf1);

            EndTermFlight oetf1;
            oetf1 = new EndTermFlight()
            {
                Flight = oldshit1,
                Terminal = terminal4
            };
            db.EndTermFlights.Add(oetf1);

            Flight oldshit2;
            oldshit2 = new Flight()
            {
                TakeoffDT = new DateTime(2016, 09, 07, 00, 14, 00),
                TouchDownDT = new DateTime(2016, 09, 07, 06, 43, 00),
                ETA = new DateTime(2016, 09, 07, 06, 43, 00).Subtract(new DateTime(2016, 09, 07, 00, 14, 00)).Ticks,
                StartTermFlight = new StartTermFlight()
                {

                    Terminal = terminal1
                },
                EndTermFlight = new EndTermFlight()
                {
                    Terminal = terminal4
                }
            };
            db.Flights.Add(oldshit2);

            StartTermFlight ostf2;
            ostf2 = new StartTermFlight()
            {
                Flight = oldshit2,
                Terminal = terminal1
            };
            db.StartTermFlights.Add(ostf2);

            EndTermFlight oetf2;
            oetf2 = new EndTermFlight()
            {
                Flight = oldshit2,
                Terminal = terminal4
            };
            db.EndTermFlights.Add(oetf2);

            Flight oldshit3;
            oldshit3 = new Flight()
            {
                TakeoffDT = new DateTime(2016, 09, 08, 00, 20, 00),
                TouchDownDT = new DateTime(2016, 09, 08, 06, 32, 00),
                ETA = new DateTime(2016, 09, 08, 06, 32, 00).Subtract(new DateTime(2016, 09, 08, 00, 20, 00)).Ticks,
                StartTermFlight = new StartTermFlight()
                {

                    Terminal = terminal1
                },
                EndTermFlight = new EndTermFlight()
                {

                    Terminal = terminal4
                }
            };
            db.Flights.Add(oldshit3);

            StartTermFlight ostf3;
            ostf3 = new StartTermFlight()
            {
                Flight = oldshit3,
                Terminal = terminal1
            };
            db.StartTermFlights.Add(ostf3);

            EndTermFlight oetf3;
            oetf3 = new EndTermFlight()
            {
                Flight = oldshit3,
                Terminal = terminal4
            };
            db.EndTermFlights.Add(oetf3);

            Flight oldshit4;
            oldshit4 = new Flight()
            {
                TakeoffDT = new DateTime(2016, 09, 09, 00, 24, 00),
                TouchDownDT = new DateTime(2016, 09, 09, 06, 42, 00),
                ETA = new DateTime(2016, 09, 09, 06, 42, 00).Subtract(new DateTime(2016, 09, 09, 00, 24, 00)).Ticks,
                StartTermFlight = new StartTermFlight()
                {

                    Terminal = terminal1
                },
                EndTermFlight = new EndTermFlight()
                {

                    Terminal = terminal4
                }
            };
            db.Flights.Add(oldshit4);

            StartTermFlight ostf4;
            ostf4 = new StartTermFlight()
            {
                Flight = oldshit4,
                Terminal = terminal1
            };
            db.StartTermFlights.Add(ostf4);

            EndTermFlight oetf4;
            oetf4 = new EndTermFlight()
            {
                Flight = oldshit4,
                Terminal = terminal4
            };
            db.EndTermFlights.Add(oetf4);

            Flight oldshit5;
            oldshit5 = new Flight()
            {
                TakeoffDT = new DateTime(2016, 09, 10, 00, 15, 00),
                TouchDownDT = new DateTime(2016, 09, 10, 06, 41, 00),
                ETA = new DateTime(2016, 09, 10, 06, 41, 00).Subtract(new DateTime(2016, 09, 10, 00, 15, 00)).Ticks,
                StartTermFlight = new StartTermFlight()
                {

                    Terminal = terminal1
                },
                EndTermFlight = new EndTermFlight()
                {

                    Terminal = terminal4
                }
            };
            db.Flights.Add(oldshit5);

            StartTermFlight ostf5;
            ostf5 = new StartTermFlight()
            {
                Flight = oldshit5,
                Terminal = terminal1
            };
            db.StartTermFlights.Add(ostf5);

            EndTermFlight oetf5;
            oetf5 = new EndTermFlight()
            {
                Flight = oldshit5,
                Terminal = terminal4
            };
            db.EndTermFlights.Add(oetf5);

            Flight oldshit6;
            oldshit6 = new Flight()
            {
                TakeoffDT = new DateTime(2016, 09, 11, 00, 19, 00),
                TouchDownDT = new DateTime(2016, 09, 11, 07, 15, 00),
                ETA = new DateTime(2016, 09, 11, 07, 15, 00).Subtract(new DateTime(2016, 09, 11, 00, 19, 00)).Ticks,
                StartTermFlight = new StartTermFlight()
                {

                    Terminal = terminal1
                },
                EndTermFlight = new EndTermFlight()
                {

                    Terminal = terminal4
                }
            };
            db.Flights.Add(oldshit6);

            StartTermFlight ostf6;
            ostf6 = new StartTermFlight()
            {
                Flight = oldshit6,
                Terminal = terminal1
            };
            db.StartTermFlights.Add(ostf6);

            EndTermFlight oetf6;
            oetf6 = new EndTermFlight()
            {
                Flight = oldshit6,
                Terminal = terminal4
            };
            db.EndTermFlights.Add(oetf6);

            Flight oldshit7;
            oldshit7 = new Flight()
            {
                TakeoffDT = new DateTime(2016, 09, 12, 00, 13, 00),
                TouchDownDT = new DateTime(2016, 09, 12, 06, 42, 00),
                ETA = new DateTime(2016, 09, 12, 06, 42, 00).Subtract(new DateTime(2016, 09, 12, 00, 13, 00)).Ticks,
                StartTermFlight = new StartTermFlight()
                {

                    Terminal = terminal1
                },
                EndTermFlight = new EndTermFlight()
                {

                    Terminal = terminal4
                }
            };
            db.Flights.Add(oldshit7);

            StartTermFlight ostf7;
            ostf7 = new StartTermFlight()
            {
                Flight = oldshit7,
                Terminal = terminal1
            };
            db.StartTermFlights.Add(ostf7);

            EndTermFlight oetf7;
            oetf7 = new EndTermFlight()
            {
                Flight = oldshit7,
                Terminal = terminal4
            };
            db.EndTermFlights.Add(oetf7);

            Flight oldshit8;
            oldshit8 = new Flight()
            {
                TakeoffDT = new DateTime(2016, 09, 13, 02, 14, 00),
                TouchDownDT = new DateTime(2016, 09, 13, 07, 15, 00),
                ETA = new DateTime(2016, 09, 13, 07, 15, 00).Subtract(new DateTime(2016, 09, 13, 02, 14, 00)).Ticks,
                StartTermFlight = new StartTermFlight()
                {

                    Terminal = terminal1
                },
                EndTermFlight = new EndTermFlight()
                {

                    Terminal = terminal4
                }
            };
            db.Flights.Add(oldshit8);

            StartTermFlight ostf8;
            ostf8 = new StartTermFlight()
            {
                Flight = oldshit8,
                Terminal = terminal1
            };
            db.StartTermFlights.Add(ostf8);

            EndTermFlight oetf8;
            oetf8 = new EndTermFlight()
            {
                Flight = oldshit8,
                Terminal = terminal4
            };
            db.EndTermFlights.Add(oetf8);

            Flight oldshit9;
            oldshit9 = new Flight()
            {
                TakeoffDT = new DateTime(2016, 09, 14, 00, 14, 00),
                TouchDownDT = new DateTime(2016, 09, 14, 06, 38, 00),
                ETA = new DateTime(2016, 09, 14, 06, 38, 00).Subtract(new DateTime(2016, 09, 14, 00, 14, 00)).Ticks,
                StartTermFlight = new StartTermFlight()
                {

                    Terminal = terminal1
                },
                EndTermFlight = new EndTermFlight()
                {

                    Terminal = terminal4
                }
            };
            db.Flights.Add(oldshit9);

            StartTermFlight ostf9;
            ostf9 = new StartTermFlight()
            {
                Flight = oldshit9,
                Terminal = terminal1
            };
            db.StartTermFlights.Add(ostf9);

            EndTermFlight oetf9;
            oetf9 = new EndTermFlight()
            {
                Flight = oldshit9,
                Terminal = terminal4
            };
            db.EndTermFlights.Add(oetf9);

            Flight oldshit10;
            oldshit10 = new Flight()
            {
                TakeoffDT = new DateTime(2016, 09, 15, 00, 16, 00),
                TouchDownDT = new DateTime(2016, 09, 15, 06, 32, 00),
                ETA = new DateTime(2016, 09, 15, 06, 32, 00).Subtract(new DateTime(2016, 09, 15, 00, 16, 00)).Ticks,
                StartTermFlight = new StartTermFlight()
                {

                    Terminal = terminal1
                },
                EndTermFlight = new EndTermFlight()
                {

                    Terminal = terminal4
                }
            };
            db.Flights.Add(oldshit10);

            StartTermFlight ostf10;
            ostf10 = new StartTermFlight()
            {
                Flight = oldshit10,
                Terminal = terminal1
            };
            db.StartTermFlights.Add(ostf10);

            EndTermFlight oetf10;
            oetf10 = new EndTermFlight()
            {
                Flight = oldshit10,
                Terminal = terminal4
            };
            db.EndTermFlights.Add(oetf10);

            Flight oldshit11;
            oldshit11 = new Flight()
            {
                TakeoffDT = new DateTime(2016, 09, 17, 00, 32, 00),
                TouchDownDT = new DateTime(2016, 09, 17, 07, 15, 00),
                ETA = new DateTime(2016, 09, 17, 07, 15, 00).Subtract(new DateTime(2016, 09, 17, 00, 32, 00)).Ticks,
                StartTermFlight = new StartTermFlight()
                {

                    Terminal = terminal1
                },
                EndTermFlight = new EndTermFlight()
                {

                    Terminal = terminal4
                }
            };
            db.Flights.Add(oldshit11);

            StartTermFlight ostf11;
            ostf11 = new StartTermFlight()
            {
                Flight = oldshit11,
                Terminal = terminal1
            };
            db.StartTermFlights.Add(ostf11);

            EndTermFlight oetf11;
            oetf11 = new EndTermFlight()
            {
                Flight = oldshit11,
                Terminal = terminal4
            };
            db.EndTermFlights.Add(oetf11);

            Flight oldshit12;
            oldshit12 = new Flight()
            {
                TakeoffDT = new DateTime(2016, 09, 19, 00, 14, 00),
                TouchDownDT = new DateTime(2016, 09, 19, 06, 27, 00),
                ETA = new DateTime(2016, 09, 19, 06, 27, 00).Subtract(new DateTime(2016, 09, 19, 00, 14, 00)).Ticks,
                StartTermFlight = new StartTermFlight()
                {

                    Terminal = terminal1
                },
                EndTermFlight = new EndTermFlight()
                {

                    Terminal = terminal4
                }
            };
            db.Flights.Add(oldshit12);

            StartTermFlight ostf12;
            ostf12 = new StartTermFlight()
            {
                Flight = oldshit12,
                Terminal = terminal1
            };
            db.StartTermFlights.Add(ostf12);

            EndTermFlight oetf12;
            oetf12 = new EndTermFlight()
            {
                Flight = oldshit12,
                Terminal = terminal4
            };
            db.EndTermFlights.Add(oetf12);

            Flight oldshit13;
            oldshit13 = new Flight()
            {
                TakeoffDT = new DateTime(2016, 09, 19, 00, 14, 00),
                TouchDownDT = new DateTime(2016, 09, 19, 06, 27, 00),
                ETA = new DateTime(2016, 09, 19, 06, 27, 00).Subtract(new DateTime(2016, 09, 19, 00, 14, 00)).Ticks,
                StartTermFlight = new StartTermFlight()
                {

                    Terminal = terminal1
                },
                EndTermFlight = new EndTermFlight()
                {

                    Terminal = terminal4
                }
            };
            db.Flights.Add(oldshit13);

            StartTermFlight ostf13;
            ostf13 = new StartTermFlight()
            {
                Flight = oldshit13,
                Terminal = terminal1
            };
            db.StartTermFlights.Add(ostf13);

            EndTermFlight oetf13;
            oetf13 = new EndTermFlight()
            {
                Flight = oldshit13,
                Terminal = terminal4
            };
            db.EndTermFlights.Add(oetf13);

            Flight oldshit14;
            oldshit14 = new Flight()
            {
                TakeoffDT = new DateTime(2016, 09, 21, 00, 14, 00),
                TouchDownDT = new DateTime(2016, 09, 21, 06, 38, 00),
                ETA = new DateTime(2016, 09, 21, 06, 38, 00).Subtract(new DateTime(2016, 09, 21, 00, 14, 00)).Ticks,
                StartTermFlight = new StartTermFlight()
                {

                    Terminal = terminal1
                },
                EndTermFlight = new EndTermFlight()
                {

                    Terminal = terminal4
                }
            };
            db.Flights.Add(oldshit14);

            StartTermFlight ostf14;
            ostf14 = new StartTermFlight()
            {
                Flight = oldshit14,
                Terminal = terminal1
            };
            db.StartTermFlights.Add(ostf14);

            EndTermFlight oetf14;
            oetf14 = new EndTermFlight()
            {
                Flight = oldshit14,
                Terminal = terminal4
            };
            db.EndTermFlights.Add(oetf14);

            Flight oldshit15;
            oldshit15 = new Flight()
            {
                TakeoffDT = new DateTime(2016, 09, 23, 00, 21, 00),
                TouchDownDT = new DateTime(2016, 09, 23, 06, 41, 00),
                ETA = new DateTime(2016, 09, 23, 06, 41, 00).Subtract(new DateTime(2016, 09, 23, 00, 21, 00)).Ticks,
                StartTermFlight = new StartTermFlight()
                {

                    Terminal = terminal1
                },
                EndTermFlight = new EndTermFlight()
                {

                    Terminal = terminal4
                }
            };
            db.Flights.Add(oldshit15);

            StartTermFlight ostf15;
            ostf15 = new StartTermFlight()
            {
                Flight = oldshit15,
                Terminal = terminal1
            };
            db.StartTermFlights.Add(ostf15);

            EndTermFlight oetf15;
            oetf15 = new EndTermFlight()
            {
                Flight = oldshit15,
                Terminal = terminal4
            };
            db.EndTermFlights.Add(oetf15);

            Flight oldshit16;
            oldshit16 = new Flight()
            {
                TakeoffDT = new DateTime(2016, 09, 25, 00, 17, 00),
                TouchDownDT = new DateTime(2016, 09, 25, 06, 34, 00),
                ETA = new DateTime(2016, 09, 25, 06, 34, 00).Subtract(new DateTime(2016, 09, 25, 00, 17, 00)).Ticks,
                StartTermFlight = new StartTermFlight()
                {

                    Terminal = terminal1
                },
                EndTermFlight = new EndTermFlight()
                {

                    Terminal = terminal4
                }
            };
            db.Flights.Add(oldshit16);

            StartTermFlight ostf16;
            ostf16 = new StartTermFlight()
            {
                Flight = oldshit16,
                Terminal = terminal1
            };
            db.StartTermFlights.Add(ostf16);

            EndTermFlight oetf16;
            oetf16 = new EndTermFlight()
            {
                Flight = oldshit16,
                Terminal = terminal4
            };
            db.EndTermFlights.Add(oetf16);

            Flight oldshit17;
            oldshit17 = new Flight()
            {
                TakeoffDT = new DateTime(2016, 09, 27, 00, 15, 00),
                TouchDownDT = new DateTime(2016, 09, 27, 06, 37, 00),
                ETA = new DateTime(2016, 09, 27, 06, 37, 00).Subtract(new DateTime(2016, 09, 27, 00, 15, 00)).Ticks,
                StartTermFlight = new StartTermFlight()
                {

                    Terminal = terminal1
                },
                EndTermFlight = new EndTermFlight()
                {

                    Terminal = terminal4
                }
            };
            db.Flights.Add(oldshit17);

            StartTermFlight ostf17;
            ostf17 = new StartTermFlight()
            {
                Flight = oldshit17,
                Terminal = terminal1
            };
            db.StartTermFlights.Add(ostf17);

            EndTermFlight oetf17;
            oetf17 = new EndTermFlight()
            {
                Flight = oldshit17,
                Terminal = terminal4
            };
            db.EndTermFlights.Add(oetf17);

            Flight oldshit18;
            oldshit18 = new Flight()
            {
                TakeoffDT = new DateTime(2016, 09, 29, 00, 14, 00),
                TouchDownDT = new DateTime(2016, 09, 29, 07, 15, 00),
                ETA = new DateTime(2016, 09, 29, 07, 15, 00).Subtract(new DateTime(2016, 09, 29, 00, 14, 00)).Ticks,
                StartTermFlight = new StartTermFlight()
                {

                    Terminal = terminal1
                },
                EndTermFlight = new EndTermFlight()
                {

                    Terminal = terminal4
                }
            };
            db.Flights.Add(oldshit18);

            StartTermFlight ostf18;
            ostf18 = new StartTermFlight()
            {
                Flight = oldshit18,
                Terminal = terminal1
            };
            db.StartTermFlights.Add(ostf18);

            EndTermFlight oetf18;
            oetf18 = new EndTermFlight()
            {
                Flight = oldshit18,
                Terminal = terminal4
            };
            db.EndTermFlights.Add(oetf18);

            Flight oldshit19;
            oldshit19 = new Flight()
            {
                TakeoffDT = new DateTime(2016, 10, 01, 00, 50, 00),
                TouchDownDT = new DateTime(2016, 10, 01, 07, 15, 00),
                ETA = new DateTime(2016, 10, 01, 07, 15, 00).Subtract(new DateTime(2016, 10, 01, 00, 50, 00)).Ticks,
                StartTermFlight = new StartTermFlight()
                {

                    Terminal = terminal1
                },
                EndTermFlight = new EndTermFlight()
                {

                    Terminal = terminal4
                }
            };
            db.Flights.Add(oldshit19);

            StartTermFlight ostf19;
            ostf19 = new StartTermFlight()
            {
                Flight = oldshit19,
                Terminal = terminal1
            };
            db.StartTermFlights.Add(ostf19);

            EndTermFlight oetf19;
            oetf19 = new EndTermFlight()
            {
                Flight = oldshit19,
                Terminal = terminal4
            };
            db.EndTermFlights.Add(oetf19);

            Flight oldshit20;
            oldshit20 = new Flight()
            {
                TakeoffDT = new DateTime(2016, 10, 03, 00, 25, 00),
                TouchDownDT = new DateTime(2016, 10, 03, 06, 49, 00),
                ETA = new DateTime(2016, 10, 03, 06, 49, 00).Subtract(new DateTime(2016, 10, 03, 00, 25, 00)).Ticks,
                StartTermFlight = new StartTermFlight()
                {

                    Terminal = terminal1
                },
                EndTermFlight = new EndTermFlight()
                {

                    Terminal = terminal4
                }
            };
            db.Flights.Add(oldshit20);

            StartTermFlight ostf20;
            ostf20 = new StartTermFlight()
            {
                Flight = oldshit20,
                Terminal = terminal1
            };
            db.StartTermFlights.Add(ostf20);

            EndTermFlight oetf20;
            oetf20 = new EndTermFlight()
            {
                Flight = oldshit20,
                Terminal = terminal4
            };
            db.EndTermFlights.Add(oetf20);


            FlightTicket ft1;
            ft1 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1501,
                Quantity = 225,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-39)
            };



            FlightTicket ft2;
            ft2 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1502,
                Quantity = 224,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-39)
            };



            FlightTicket ft3;
            ft3 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1503,
                Quantity = 223,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-39)
            };



            FlightTicket ft4;
            ft4 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1503,
                Quantity = 222,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-39)
            };



            FlightTicket ft5;
            ft5 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1503,
                Quantity = 221,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-39)
            };



            FlightTicket ft6;
            ft6 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1505,
                Quantity = 220,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-38)
            };



            FlightTicket ft7;
            ft7 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1506,
                Quantity = 219,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-38)
            };



            FlightTicket ft8;
            ft8 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1508,
                Quantity = 218,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-38)
            };



            FlightTicket ft9;
            ft9 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1510,
                Quantity = 217,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-38)
            };



            FlightTicket ft10;
            ft10 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1511,
                Quantity = 216,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-38)
            };



            FlightTicket ft11;
            ft11 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1512,
                Quantity = 215,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-37)
            };



            FlightTicket ft12;
            ft12 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1514,
                Quantity = 214,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-37)
            };



            FlightTicket ft13;
            ft13 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1514,
                Quantity = 213,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-36)
            };



            FlightTicket ft14;
            ft14 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1515,
                Quantity = 212,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-36)
            };



            FlightTicket ft15;
            ft15 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1515,
                Quantity = 211,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-36)
            };



            FlightTicket ft16;
            ft16 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1516,
                Quantity = 210,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-36)
            };



            FlightTicket ft17;
            ft17 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1518,
                Quantity = 209,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-36)
            };



            FlightTicket ft18;
            ft18 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1519,
                Quantity = 208,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-35)
            };



            FlightTicket ft19;
            ft19 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1520,
                Quantity = 207,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-35)
            };



            FlightTicket ft20;
            ft20 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1521,
                Quantity = 206,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-35)
            };



            FlightTicket ft21;
            ft21 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1521,
                Quantity = 205,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-35)
            };



            FlightTicket ft22;
            ft22 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1523,
                Quantity = 204,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-35)
            };



            FlightTicket ft23;
            ft23 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1525,
                Quantity = 203,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-35)
            };



            FlightTicket ft24;
            ft24 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1525,
                Quantity = 202,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-35)
            };



            FlightTicket ft25;
            ft25 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1526,
                Quantity = 201,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-34)
            };



            FlightTicket ft26;
            ft26 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1527,
                Quantity = 200,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-34)
            };



            FlightTicket ft27;
            ft27 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1529,
                Quantity = 199,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-34)
            };



            FlightTicket ft28;
            ft28 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1531,
                Quantity = 198,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-34)
            };



            FlightTicket ft29;
            ft29 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1532,
                Quantity = 197,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-34)
            };



            FlightTicket ft30;
            ft30 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1534,
                Quantity = 196,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-34)
            };



            FlightTicket ft31;
            ft31 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1535,
                Quantity = 195,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-34)
            };



            FlightTicket ft32;
            ft32 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1537,
                Quantity = 194,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-33)
            };



            FlightTicket ft33;
            ft33 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1537,
                Quantity = 193,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-33)
            };



            FlightTicket ft34;
            ft34 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1538,
                Quantity = 192,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-33)
            };



            FlightTicket ft35;
            ft35 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1539,
                Quantity = 191,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-33)
            };



            FlightTicket ft36;
            ft36 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1541,
                Quantity = 190,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-32)
            };



            FlightTicket ft37;
            ft37 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1541,
                Quantity = 189,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-32)
            };



            FlightTicket ft38;
            ft38 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1543,
                Quantity = 188,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-32)
            };



            FlightTicket ft39;
            ft39 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1545,
                Quantity = 187,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-32)
            };



            FlightTicket ft40;
            ft40 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1547,
                Quantity = 186,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-31)
            };



            FlightTicket ft41;
            ft41 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1548,
                Quantity = 185,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-31)
            };



            FlightTicket ft42;
            ft42 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1548,
                Quantity = 184,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-31)
            };



            FlightTicket ft43;
            ft43 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1550,
                Quantity = 183,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-31)
            };



            FlightTicket ft44;
            ft44 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1552,
                Quantity = 182,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-31)
            };



            FlightTicket ft45;
            ft45 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1553,
                Quantity = 181,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-31)
            };



            FlightTicket ft46;
            ft46 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1554,
                Quantity = 180,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-30)
            };



            FlightTicket ft47;
            ft47 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1555,
                Quantity = 179,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-30)
            };



            FlightTicket ft48;
            ft48 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1556,
                Quantity = 178,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-30)
            };



            FlightTicket ft49;
            ft49 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1556,
                Quantity = 177,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-30)
            };



            FlightTicket ft50;
            ft50 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1557,
                Quantity = 176,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-30)
            };



            FlightTicket ft51;
            ft51 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1557,
                Quantity = 175,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-29)
            };



            FlightTicket ft52;
            ft52 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1557,
                Quantity = 174,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-29)
            };



            FlightTicket ft53;
            ft53 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1559,
                Quantity = 173,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-29)
            };



            FlightTicket ft54;
            ft54 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1560,
                Quantity = 172,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-29)
            };



            FlightTicket ft55;
            ft55 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1560,
                Quantity = 171,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-29)
            };



            FlightTicket ft56;
            ft56 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1560,
                Quantity = 170,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-28)
            };



            FlightTicket ft57;
            ft57 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1561,
                Quantity = 169,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-28)
            };



            FlightTicket ft58;
            ft58 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1563,
                Quantity = 168,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-28)
            };



            FlightTicket ft59;
            ft59 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1564,
                Quantity = 167,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-28)
            };



            FlightTicket ft60;
            ft60 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1565,
                Quantity = 166,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-28)
            };



            FlightTicket ft61;
            ft61 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1566,
                Quantity = 165,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-27)
            };



            FlightTicket ft62;
            ft62 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1567,
                Quantity = 164,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-27)
            };



            FlightTicket ft63;
            ft63 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1568,
                Quantity = 163,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-27)
            };



            FlightTicket ft64;
            ft64 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1569,
                Quantity = 162,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-27)
            };



            FlightTicket ft65;
            ft65 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1570,
                Quantity = 161,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-26)
            };



            FlightTicket ft66;
            ft66 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1571,
                Quantity = 160,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-26)
            };



            FlightTicket ft67;
            ft67 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1572,
                Quantity = 159,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-26)
            };



            FlightTicket ft68;
            ft68 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1574,
                Quantity = 158,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-26)
            };



            FlightTicket ft69;
            ft69 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1576,
                Quantity = 157,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-26)
            };



            FlightTicket ft70;
            ft70 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1576,
                Quantity = 156,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-26)
            };



            FlightTicket ft71;
            ft71 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1577,
                Quantity = 155,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-26)
            };



            FlightTicket ft72;
            ft72 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1579,
                Quantity = 154,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-26)
            };



            FlightTicket ft73;
            ft73 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1580,
                Quantity = 153,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-26)
            };



            FlightTicket ft74;
            ft74 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1582,
                Quantity = 152,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-25)
            };



            FlightTicket ft75;
            ft75 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1582,
                Quantity = 151,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-25)
            };



            FlightTicket ft76;
            ft76 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1583,
                Quantity = 150,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-25)
            };



            FlightTicket ft77;
            ft77 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1583,
                Quantity = 149,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-24)
            };



            FlightTicket ft78;
            ft78 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1583,
                Quantity = 148,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-24)
            };



            FlightTicket ft79;
            ft79 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1585,
                Quantity = 147,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-24)
            };



            FlightTicket ft80;
            ft80 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1585,
                Quantity = 146,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-24)
            };



            FlightTicket ft81;
            ft81 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1587,
                Quantity = 145,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-24)
            };



            FlightTicket ft82;
            ft82 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1589,
                Quantity = 144,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-24)
            };



            FlightTicket ft83;
            ft83 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1591,
                Quantity = 143,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-24)
            };



            FlightTicket ft84;
            ft84 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1591,
                Quantity = 142,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-23)
            };



            FlightTicket ft85;
            ft85 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1591,
                Quantity = 141,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-23)
            };



            FlightTicket ft86;
            ft86 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1592,
                Quantity = 140,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-23)
            };



            FlightTicket ft87;
            ft87 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1594,
                Quantity = 139,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-23)
            };



            FlightTicket ft88;
            ft88 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1596,
                Quantity = 138,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-23)
            };



            FlightTicket ft89;
            ft89 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1596,
                Quantity = 137,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-22)
            };



            FlightTicket ft90;
            ft90 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1598,
                Quantity = 136,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-22)
            };



            FlightTicket ft91;
            ft91 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1600,
                Quantity = 135,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-22)
            };



            FlightTicket ft92;
            ft92 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1601,
                Quantity = 134,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-22)
            };



            FlightTicket ft93;
            ft93 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1601,
                Quantity = 133,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-22)
            };



            FlightTicket ft94;
            ft94 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1601,
                Quantity = 132,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-22)
            };



            FlightTicket ft95;
            ft95 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1602,
                Quantity = 131,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-21)
            };



            FlightTicket ft96;
            ft96 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1602,
                Quantity = 130,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-21)
            };



            FlightTicket ft97;
            ft97 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1602,
                Quantity = 129,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-21)
            };



            FlightTicket ft98;
            ft98 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1602,
                Quantity = 128,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-21)
            };



            FlightTicket ft99;
            ft99 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1602,
                Quantity = 127,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-20)
            };



            FlightTicket ft100;
            ft100 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1604,
                Quantity = 126,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-20)
            };



            FlightTicket ft101;
            ft101 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1604,
                Quantity = 125,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-20)
            };



            FlightTicket ft102;
            ft102 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1604,
                Quantity = 124,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-20)
            };



            FlightTicket ft103;
            ft103 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1606,
                Quantity = 123,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-20)
            };



            FlightTicket ft104;
            ft104 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1607,
                Quantity = 122,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-20)
            };



            FlightTicket ft105;
            ft105 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1609,
                Quantity = 121,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-20)
            };



            FlightTicket ft106;
            ft106 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1610,
                Quantity = 120,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-20)
            };



            FlightTicket ft107;
            ft107 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1610,
                Quantity = 119,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-20)
            };



            FlightTicket ft108;
            ft108 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1610,
                Quantity = 118,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-20)
            };



            FlightTicket ft109;
            ft109 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1610,
                Quantity = 117,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-20)
            };



            FlightTicket ft110;
            ft110 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1611,
                Quantity = 116,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-19)
            };



            FlightTicket ft111;
            ft111 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1611,
                Quantity = 115,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-19)
            };



            FlightTicket ft112;
            ft112 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1613,
                Quantity = 114,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-19)
            };



            FlightTicket ft113;
            ft113 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1613,
                Quantity = 113,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-19)
            };



            FlightTicket ft114;
            ft114 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1615,
                Quantity = 112,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-19)
            };



            FlightTicket ft115;
            ft115 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1616,
                Quantity = 111,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-19)
            };



            FlightTicket ft116;
            ft116 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1616,
                Quantity = 110,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-18)
            };



            FlightTicket ft117;
            ft117 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1616,
                Quantity = 109,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-18)
            };



            FlightTicket ft118;
            ft118 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1617,
                Quantity = 108,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-18)
            };



            FlightTicket ft119;
            ft119 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1618,
                Quantity = 107,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-18)
            };



            FlightTicket ft120;
            ft120 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1619,
                Quantity = 106,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-18)
            };



            FlightTicket ft121;
            ft121 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1619,
                Quantity = 105,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-18)
            };



            FlightTicket ft122;
            ft122 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1620,
                Quantity = 104,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-18)
            };



            FlightTicket ft123;
            ft123 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1620,
                Quantity = 103,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-18)
            };



            FlightTicket ft124;
            ft124 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1620,
                Quantity = 102,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-17)
            };



            FlightTicket ft125;
            ft125 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1621,
                Quantity = 101,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-17)
            };



            FlightTicket ft126;
            ft126 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1623,
                Quantity = 100,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-16)
            };



            FlightTicket ft127;
            ft127 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1623,
                Quantity = 99,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-16)
            };



            FlightTicket ft128;
            ft128 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1623,
                Quantity = 98,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-16)
            };



            FlightTicket ft129;
            ft129 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1623,
                Quantity = 97,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-16)
            };



            FlightTicket ft130;
            ft130 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1623,
                Quantity = 96,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-16)
            };



            FlightTicket ft131;
            ft131 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1625,
                Quantity = 95,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-16)
            };



            FlightTicket ft132;
            ft132 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1627,
                Quantity = 94,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-16)
            };



            FlightTicket ft133;
            ft133 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1629,
                Quantity = 93,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-16)
            };



            FlightTicket ft134;
            ft134 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1631,
                Quantity = 92,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-15)
            };



            FlightTicket ft135;
            ft135 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1632,
                Quantity = 91,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-15)
            };



            FlightTicket ft136;
            ft136 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1634,
                Quantity = 90,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-15)
            };



            FlightTicket ft137;
            ft137 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1635,
                Quantity = 89,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-15)
            };



            FlightTicket ft138;
            ft138 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1636,
                Quantity = 88,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-14)
            };



            FlightTicket ft139;
            ft139 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1637,
                Quantity = 87,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-14)
            };



            FlightTicket ft140;
            ft140 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1637,
                Quantity = 86,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-14)
            };



            FlightTicket ft141;
            ft141 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1639,
                Quantity = 85,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-14)
            };



            FlightTicket ft142;
            ft142 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1640,
                Quantity = 84,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-14)
            };



            FlightTicket ft143;
            ft143 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1642,
                Quantity = 83,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-14)
            };



            FlightTicket ft144;
            ft144 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1642,
                Quantity = 82,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-14)
            };



            FlightTicket ft145;
            ft145 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1644,
                Quantity = 81,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-13)
            };



            FlightTicket ft146;
            ft146 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1644,
                Quantity = 80,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-13)
            };



            FlightTicket ft147;
            ft147 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1646,
                Quantity = 79,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-13)
            };



            FlightTicket ft148;
            ft148 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1647,
                Quantity = 78,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-13)
            };



            FlightTicket ft149;
            ft149 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1649,
                Quantity = 77,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-13)
            };



            FlightTicket ft150;
            ft150 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1650,
                Quantity = 76,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-13)
            };



            FlightTicket ft151;
            ft151 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1651,
                Quantity = 75,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-12)
            };



            FlightTicket ft152;
            ft152 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1652,
                Quantity = 74,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-12)
            };



            FlightTicket ft153;
            ft153 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1652,
                Quantity = 73,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-12)
            };



            FlightTicket ft154;
            ft154 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1654,
                Quantity = 72,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-12)
            };



            FlightTicket ft155;
            ft155 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1656,
                Quantity = 71,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-12)
            };



            FlightTicket ft156;
            ft156 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1656,
                Quantity = 70,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-11)
            };



            FlightTicket ft157;
            ft157 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1658,
                Quantity = 69,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-11)
            };



            FlightTicket ft158;
            ft158 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1660,
                Quantity = 68,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-11)
            };



            FlightTicket ft159;
            ft159 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1662,
                Quantity = 67,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-10)
            };



            FlightTicket ft160;
            ft160 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1664,
                Quantity = 66,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-10)
            };



            FlightTicket ft161;
            ft161 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1665,
                Quantity = 65,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-10)
            };



            FlightTicket ft162;
            ft162 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1666,
                Quantity = 64,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-10)
            };



            FlightTicket ft163;
            ft163 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1667,
                Quantity = 63,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-10)
            };



            FlightTicket ft164;
            ft164 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1668,
                Quantity = 62,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-10)
            };



            FlightTicket ft165;
            ft165 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1668,
                Quantity = 61,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-10)
            };



            FlightTicket ft166;
            ft166 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1669,
                Quantity = 60,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-9)
            };



            FlightTicket ft167;
            ft167 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1669,
                Quantity = 59,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-9)
            };



            FlightTicket ft168;
            ft168 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1671,
                Quantity = 58,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-9)
            };



            FlightTicket ft169;
            ft169 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1672,
                Quantity = 57,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-9)
            };



            FlightTicket ft170;
            ft170 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1673,
                Quantity = 56,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-9)
            };



            FlightTicket ft171;
            ft171 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1673,
                Quantity = 55,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-9)
            };



            FlightTicket ft172;
            ft172 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1673,
                Quantity = 54,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-9)
            };



            FlightTicket ft173;
            ft173 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1675,
                Quantity = 53,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-8)
            };



            FlightTicket ft174;
            ft174 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1676,
                Quantity = 52,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-8)
            };



            FlightTicket ft175;
            ft175 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1678,
                Quantity = 51,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-8)
            };



            FlightTicket ft176;
            ft176 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1680,
                Quantity = 50,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-7)
            };



            FlightTicket ft177;
            ft177 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1680,
                Quantity = 49,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-7)
            };



            FlightTicket ft178;
            ft178 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1682,
                Quantity = 48,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-7)
            };



            FlightTicket ft179;
            ft179 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1684,
                Quantity = 47,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-7)
            };



            FlightTicket ft180;
            ft180 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1685,
                Quantity = 46,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-7)
            };



            FlightTicket ft181;
            ft181 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1686,
                Quantity = 45,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-6)
            };



            FlightTicket ft182;
            ft182 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1686,
                Quantity = 44,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-6)
            };



            FlightTicket ft183;
            ft183 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1688,
                Quantity = 43,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-6)
            };



            FlightTicket ft184;
            ft184 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1689,
                Quantity = 42,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-5)
            };



            FlightTicket ft185;
            ft185 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1691,
                Quantity = 41,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-5)
            };



            FlightTicket ft186;
            ft186 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1691,
                Quantity = 40,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-5)
            };



            FlightTicket ft187;
            ft187 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1691,
                Quantity = 39,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-5)
            };



            FlightTicket ft188;
            ft188 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1693,
                Quantity = 38,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-5)
            };



            FlightTicket ft189;
            ft189 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1695,
                Quantity = 37,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-5)
            };



            FlightTicket ft190;
            ft190 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1697,
                Quantity = 36,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-5)
            };



            FlightTicket ft191;
            ft191 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1698,
                Quantity = 35,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-4)
            };



            FlightTicket ft192;
            ft192 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1698,
                Quantity = 34,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-4)
            };



            FlightTicket ft193;
            ft193 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1700,
                Quantity = 33,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-4)
            };



            FlightTicket ft194;
            ft194 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1701,
                Quantity = 32,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-4)
            };



            FlightTicket ft195;
            ft195 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1703,
                Quantity = 31,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-4)
            };



            FlightTicket ft196;
            ft196 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1705,
                Quantity = 30,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-3)
            };



            FlightTicket ft197;
            ft197 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1705,
                Quantity = 29,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-3)
            };



            FlightTicket ft198;
            ft198 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1707,
                Quantity = 28,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-3)
            };



            FlightTicket ft199;
            ft199 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1707,
                Quantity = 27,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-3)
            };



            FlightTicket ft200;
            ft200 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1708,
                Quantity = 26,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-3)
            };



            FlightTicket ft201;
            ft201 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1709,
                Quantity = 25,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-3)
            };



            FlightTicket ft202;
            ft202 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1710,
                Quantity = 24,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-3)
            };



            FlightTicket ft203;
            ft203 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1711,
                Quantity = 23,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-3)
            };



            FlightTicket ft204;
            ft204 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1712,
                Quantity = 22,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-3)
            };



            FlightTicket ft205;
            ft205 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1714,
                Quantity = 21,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-2)
            };



            FlightTicket ft206;
            ft206 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1714,
                Quantity = 20,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-2)
            };



            FlightTicket ft207;
            ft207 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1714,
                Quantity = 19,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-2)
            };



            FlightTicket ft208;
            ft208 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1715,
                Quantity = 18,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-2)
            };



            FlightTicket ft209;
            ft209 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1715,
                Quantity = 17,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-2)
            };



            FlightTicket ft210;
            ft210 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1715,
                Quantity = 16,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-2)
            };



            FlightTicket ft211;
            ft211 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1717,
                Quantity = 15,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-2)
            };



            FlightTicket ft212;
            ft212 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1717,
                Quantity = 14,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-2)
            };



            FlightTicket ft213;
            ft213 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1717,
                Quantity = 13,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-2)
            };



            FlightTicket ft214;
            ft214 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1717,
                Quantity = 12,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-2)
            };



            FlightTicket ft215;
            ft215 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1717,
                Quantity = 11,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-1)
            };



            FlightTicket ft216;
            ft216 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1717,
                Quantity = 10,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-1)
            };



            FlightTicket ft217;
            ft217 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1719,
                Quantity = 9,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-1)
            };



            FlightTicket ft218;
            ft218 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1719,
                Quantity = 8,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-1)
            };



            FlightTicket ft219;
            ft219 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1719,
                Quantity = 7,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-0)
            };



            FlightTicket ft220;
            ft220 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1719,
                Quantity = 6,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-0)
            };



            FlightTicket ft221;
            ft221 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1721,
                Quantity = 5,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-0)
            };



            FlightTicket ft222;
            ft222 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1722,
                Quantity = 4,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-0)
            };



            FlightTicket ft223;
            ft223 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1722,
                Quantity = 3,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-0)
            };



            FlightTicket ft224;
            ft224 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1722,
                Quantity = 2,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-0)
            };



            FlightTicket ft227;
            ft227 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5004,
                Quantity = 45,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-38)
            };



            FlightTicket ft228;
            ft228 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5004,
                Quantity = 44,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-38)
            };



            FlightTicket ft229;
            ft229 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5006,
                Quantity = 43,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-38)
            };



            FlightTicket ft230;
            ft230 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5006,
                Quantity = 42,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-37)
            };



            FlightTicket ft231;
            ft231 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5007,
                Quantity = 41,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-37)
            };



            FlightTicket ft232;
            ft232 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5008,
                Quantity = 40,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-36)
            };



            FlightTicket ft233;
            ft233 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5011,
                Quantity = 39,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-36)
            };



            FlightTicket ft234;
            ft234 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5015,
                Quantity = 38,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-36)
            };



            FlightTicket ft235;
            ft235 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5015,
                Quantity = 37,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-35)
            };



            FlightTicket ft236;
            ft236 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5016,
                Quantity = 36,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-33)
            };



            FlightTicket ft237;
            ft237 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5020,
                Quantity = 35,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-33)
            };



            FlightTicket ft238;
            ft238 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5024,
                Quantity = 34,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-32)
            };



            FlightTicket ft239;
            ft239 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5025,
                Quantity = 33,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-32)
            };



            FlightTicket ft240;
            ft240 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5025,
                Quantity = 32,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-31)
            };



            FlightTicket ft241;
            ft241 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5028,
                Quantity = 31,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-31)
            };



            FlightTicket ft242;
            ft242 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5032,
                Quantity = 30,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-29)
            };



            FlightTicket ft243;
            ft243 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5032,
                Quantity = 29,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-27)
            };



            FlightTicket ft244;
            ft244 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5035,
                Quantity = 28,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-27)
            };



            FlightTicket ft245;
            ft245 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5039,
                Quantity = 27,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-27)
            };



            FlightTicket ft246;
            ft246 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5043,
                Quantity = 26,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-25)
            };



            FlightTicket ft247;
            ft247 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5045,
                Quantity = 25,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-25)
            };



            FlightTicket ft248;
            ft248 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5048,
                Quantity = 24,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-23)
            };



            FlightTicket ft249;
            ft249 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5051,
                Quantity = 23,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-21)
            };



            FlightTicket ft250;
            ft250 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5053,
                Quantity = 22,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-19)
            };



            FlightTicket ft251;
            ft251 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5057,
                Quantity = 21,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-19)
            };



            FlightTicket ft252;
            ft252 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5059,
                Quantity = 20,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-18)
            };



            FlightTicket ft253;
            ft253 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5059,
                Quantity = 19,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-18)
            };



            FlightTicket ft254;
            ft254 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5062,
                Quantity = 18,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-17)
            };



            FlightTicket ft255;
            ft255 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5066,
                Quantity = 17,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-17)
            };



            FlightTicket ft256;
            ft256 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5070,
                Quantity = 16,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-16)
            };



            FlightTicket ft257;
            ft257 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5074,
                Quantity = 15,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-14)
            };



            FlightTicket ft258;
            ft258 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5075,
                Quantity = 14,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-12)
            };



            FlightTicket ft259;
            ft259 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5075,
                Quantity = 13,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-12)
            };



            FlightTicket ft260;
            ft260 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5077,
                Quantity = 12,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-12)
            };



            FlightTicket ft261;
            ft261 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5081,
                Quantity = 11,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-11)
            };



            FlightTicket ft262;
            ft262 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5083,
                Quantity = 10,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-9)
            };



            FlightTicket ft263;
            ft263 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5084,
                Quantity = 9,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-8)
            };



            FlightTicket ft264;
            ft264 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5085,
                Quantity = 8,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-8)
            };



            FlightTicket ft265;
            ft265 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5085,
                Quantity = 7,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-7)
            };



            FlightTicket ft266;
            ft266 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5089,
                Quantity = 6,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-7)
            };



            FlightTicket ft267;
            ft267 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5092,
                Quantity = 5,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-7)
            };



            FlightTicket ft268;
            ft268 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5096,
                Quantity = 4,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-6)
            };



            FlightTicket ft269;
            ft269 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5099,
                Quantity = 3,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-5)
            };



            FlightTicket ft270;
            ft270 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5099,
                Quantity = 2,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-3)
            };



            FlightTicket ft301;
            ft301 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = firstClass,
                Price = 11016,
                Quantity = 8,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-33)
            };



            FlightTicket ft302;
            ft302 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = firstClass,
                Price = 11017,
                Quantity = 7,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-28)
            };



            FlightTicket ft303;
            ft303 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = firstClass,
                Price = 11033,
                Quantity = 6,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-24)
            };
            
            FlightTicket ft304;
            ft304 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = firstClass,
                Price = 11040,
                Quantity = 5,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-22)
            };

            FlightTicket ft305;
            ft305 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = firstClass,
                Price = 11045,
                Quantity = 4,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-17)
            };

            FlightTicket ft306;
            ft306 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = firstClass,
                Price = 11050,
                Quantity = 3,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-14)
            };
            
            FlightTicket ft307;
            ft307 = new FlightTicket()
            {
                Flight = oldshit7,
                Ticket = firstClass,
                Price = 11068,
                Quantity = 2,
                CreatedAt = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-14)
            };
        }
            
    }
}

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
                Model = "777-200ER",
                Brand = "Boeing",
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
                StartTermFlight = new StartTermFlights()
                {                    
                    Terminal = terminal1
                },
                EndTermFlight = new EndTermFlights()
                {
                    
                    Terminal = terminal3
                }
            };
            db.Flights.Add(flight1);

            StartTermFlights stf1;
            stf1 = new StartTermFlights()
            {
                Flight = flight1,
                Terminal = terminal1
            };
            db.StartTermFlights.Add(stf1);

            EndTermFlights etf1;
            etf1 = new EndTermFlights()
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
                ETA = new DateTime().Subtract.(new DateTime()).Ticks,
                StartTermFlight = new StartTermFlights()
                {
                    
                    Terminal = terminal3
                },
                EndTermFlight = new EndTermFlights()
                {
                    Terminal = terminal1
                }
            };
            db.Flights.Add(flight2);

            StartTermFlights stf2;
            stf2 = new StartTermFlights()
            {
                Flight = flight2,
                Terminal = terminal3
            };
            db.StartTermFlights.Add(stf2);

            EndTermFlights etf2;
            etf2 = new EndTermFlights()
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
                ETA = new DateTime().Subtract.(new DateTime()).Ticks,
                StartTermFlight = new StartTermFlights()
                {                    
                    Terminal = terminal4
                },
                EndTermFlight = new EndTermFlights()
                {
                    Terminal = terminal1
                }
            };
            db.Flights.Add(flight3);

            StartTermFlights stf3;
            stf3 = new StartTermFlights()
            {
                Flight = flight3,
                Terminal = terminal4
            };
            db.StartTermFlights.Add(stf1);

            EndTermFlights etf3;
            etf3 = new EndTermFlights()
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
                ETA = new DateTime().Subtract.(new DateTime()).Ticks,
                StartTermFlight = new StartTermFlights()
                {
                    Terminal = terminal4
                },
                EndTermFlight = new EndTermFlights()
                {
                    
                    Terminal = terminal1
                }
            };
            db.Flights.Add(flight4);

            StartTermFlights stf4;
            stf4 = new StartTermFlights()
            {
                Flight = flight4,
                Terminal = terminal4
            };
            db.StartTermFlights.Add(stf4);

            EndTermFlights etf4;
            etf4 = new EndTermFlights()
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
                ETA = new DateTime().Subtract.(new DateTime()).Ticks,
                StartTermFlight = new StartTermFlights()
                {
                    
                    Terminal = terminal1
                },
                EndTermFlight = new EndTermFlights()
                {
                    
                    Terminal = terminal4
                }
            };
            db.Flights.Add(oldshit1);

            StartTermFlights ostf1;
            ostf1 = new StartTermFlights()
            {
                Flight = oldshit1,
                Terminal = terminal1
            };
            db.StartTermFlights.Add(ostf1);

            EndTermFlights oetf1;
            oetf1 = new EndTermFlights()
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
                ETA = new DateTime().Subtract.(new DateTime()).Ticks,
                StartTermFlight = new StartTermFlights()
                {
                    
                    Terminal = terminal1
                },
                EndTermFlight = new EndTermFlights()
                {
                    Terminal = terminal4
                }
            };
            db.Flights.Add(oldshit2);

            StartTermFlights ostf2;
            ostf2 = new StartTermFlights()
            {
                Flight = oldshit2,
                Terminal = terminal1
            };
            db.StartTermFlights.Add(ostf2);

            EndTermFlights oetf2;
            oetf2 = new EndTermFlights()
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
                ETA = new DateTime().Subtract.(new DateTime()).Ticks,
                StartTermFlight = new StartTermFlights()
                {
                    
                    Terminal = terminal1
                },
                EndTermFlight = new EndTermFlights()
                {
                    
                    Terminal = terminal4
                }
            };
            db.Flights.Add(oldshit3);

            StartTermFlights ostf3;
            ostf3 = new StartTermFlights()
            {
                Flight = oldshit3,
                Terminal = terminal1
            };
            db.StartTermFlights.Add(ostf3);

            EndTermFlights oetf3;
            oetf3 = new EndTermFlights()
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
                ETA = new DateTime().Subtract.(new DateTime()).Ticks,
                StartTermFlight = new StartTermFlights()
                {
                    
                    Terminal = terminal1
                },
                EndTermFlight = new EndTermFlights()
                {
                    
                    Terminal = terminal4
                }
            };
            db.Flights.Add(oldshit4);

            StartTermFlights ostf4;
            ostf4 = new StartTermFlights()
            {
                Flight = oldshit4,
                Terminal = terminal1
            };
            db.StartTermFlights.Add(ostf4);

            EndTermFlights oetf4;
            oetf4 = new EndTermFlights()
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
                ETA = new DateTime().Subtract.(new DateTime()).Ticks,
                StartTermFlight = new StartTermFlights()
                {
                    
                    Terminal = terminal1
                },
                EndTermFlight = new EndTermFlights()
                {
                    
                    Terminal = terminal4
                }
            };
            db.Flights.Add(oldshit5);

            StartTermFlights ostf5;
            ostf5 = new StartTermFlights()
            {
                Flight = oldshit5,
                Terminal = terminal1
            };
            db.StartTermFlights.Add(ostf5);

            EndTermFlights oetf5;
            oetf5 = new EndTermFlights()
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
                ETA = new DateTime().Subtract.(new DateTime()).Ticks,
                StartTermFlight = new StartTermFlights()
                {
                    
                    Terminal = terminal1
                },
                EndTermFlight = new EndTermFlights()
                {
                    
                    Terminal = terminal4
                }
            };
            db.Flights.Add(oldshit6);

            StartTermFlights ostf6;
            ostf6 = new StartTermFlights()
            {
                Flight = oldshit6,
                Terminal = terminal1
            };
            db.StartTermFlights.Add(ostf6);

            EndTermFlights oetf6;
            oetf6 = new EndTermFlights()
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
                ETA = new DateTime().Subtract.(new DateTime()).Ticks,
                StartTermFlight = new StartTermFlights()
                {
                    
                    Terminal = terminal1
                },
                EndTermFlight = new EndTermFlights()
                {
                    
                    Terminal = terminal4
                }
            };
            db.Flights.Add(oldshit7);

            StartTermFlights ostf7;
            ostf7 = new StartTermFlights()
            {
                Flight = oldshit7,
                Terminal = terminal1
            };
            db.StartTermFlights.Add(ostf7);

            EndTermFlights oetf7;
            oetf7 = new EndTermFlights()
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
                ETA = new DateTime().Subtract.(new DateTime()).Ticks,
                StartTermFlight = new StartTermFlights()
                {
                    
                    Terminal = terminal1
                },
                EndTermFlight = new EndTermFlights()
                {
                    
                    Terminal = terminal4
                }
            };
            db.Flights.Add(oldshit8);

            StartTermFlights ostf8;
            ostf8 = new StartTermFlights()
            {
                Flight = oldshit8,
                Terminal = terminal1
            };
            db.StartTermFlights.Add(ostf8);

            EndTermFlights oetf8;
            oetf8 = new EndTermFlights()
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
                ETA = new DateTime().Subtract.(new DateTime()).Ticks,
                StartTermFlight = new StartTermFlights()
                {
                    
                    Terminal = terminal1
                },
                EndTermFlight = new EndTermFlights()
                {
                    
                    Terminal = terminal4
                }
            };
            db.Flights.Add(oldshit9);

            StartTermFlights ostf9;
            ostf9 = new StartTermFlights()
            {
                Flight = oldshit9,
                Terminal = terminal1
            };
            db.StartTermFlights.Add(ostf9);

            EndTermFlights oetf9;
            oetf9 = new EndTermFlights()
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
                ETA = new DateTime().Subtract.(new DateTime()).Ticks,
                StartTermFlight = new StartTermFlights()
                {
                    
                    Terminal = terminal1
                },
                EndTermFlight = new EndTermFlights()
                {
                    
                    Terminal = terminal4
                }
            };
            db.Flights.Add(oldshit10);

            StartTermFlights ostf10;
            ostf10 = new StartTermFlights()
            {
                Flight = oldshit10,
                Terminal = terminal1
            };
            db.StartTermFlights.Add(ostf10);

            EndTermFlights oetf10;
            oetf10 = new EndTermFlights()
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
                ETA = new DateTime().Subtract.(new DateTime()).Ticks,
                StartTermFlight = new StartTermFlights()
                {
                    
                    Terminal = terminal1
                },
                EndTermFlight = new EndTermFlights()
                {
                    
                    Terminal = terminal4
                }
            };
            db.Flights.Add(oldshit11);

            StartTermFlights ostf11;
            ostf11 = new StartTermFlights()
            {
                Flight = oldshit11,
                Terminal = terminal1
            };
            db.StartTermFlights.Add(ostf11);

            EndTermFlights oetf11;
            oetf11 = new EndTermFlights()
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
                ETA = new DateTime().Subtract.(new DateTime()).Ticks,
                StartTermFlight = new StartTermFlights()
                {
                    
                    Terminal = terminal1
                },
                EndTermFlight = new EndTermFlights()
                {
                    
                    Terminal = terminal4
                }
            };
            db.Flights.Add(oldshit12);

            StartTermFlights ostf12;
            ostf12 = new StartTermFlights()
            {
                Flight = oldshit12,
                Terminal = terminal1
            };
            db.StartTermFlights.Add(ostf12);

            EndTermFlights oetf12;
            oetf12 = new EndTermFlights()
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
                ETA = new DateTime().Subtract.(new DateTime()).Ticks,
                StartTermFlight = new StartTermFlights()
                {
                    
                    Terminal = terminal1
                },
                EndTermFlight = new EndTermFlights()
                {
                    
                    Terminal = terminal4
                }
            };
            db.Flights.Add(oldshit13);

            StartTermFlights ostf13;
            ostf13 = new StartTermFlights()
            {
                Flight = oldshit13,
                Terminal = terminal1
            };
            db.StartTermFlights.Add(ostf13);

            EndTermFlights oetf13;
            oetf13 = new EndTermFlights()
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
                ETA = new DateTime().Subtract.(new DateTime()).Ticks,
                StartTermFlight = new StartTermFlights()
                {
                    
                    Terminal = terminal1
                },
                EndTermFlight = new EndTermFlights()
                {
                    
                    Terminal = terminal4
                }
            };
            db.Flights.Add(oldshit14);

            StartTermFlights ostf14;
            ostf14 = new StartTermFlights()
            {
                Flight = oldshit14,
                Terminal = terminal1
            };
            db.StartTermFlights.Add(ostf14);

            EndTermFlights oetf14;
            oetf14 = new EndTermFlights()
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
                ETA = new DateTime().Subtract.(new DateTime()).Ticks,
                StartTermFlight = new StartTermFlights()
                {
                    
                    Terminal = terminal1
                },
                EndTermFlight = new EndTermFlights()
                {
                    
                    Terminal = terminal4
                }
            };
            db.Flights.Add(oldshit15);

            StartTermFlights ostf15;
            ostf15 = new StartTermFlights()
            {
                Flight = oldshit15,
                Terminal = terminal1
            };
            db.StartTermFlights.Add(ostf15);

            EndTermFlights oetf15;
            oetf15 = new EndTermFlights()
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
                ETA = new DateTime().Subtract.(new DateTime()).Ticks,
                StartTermFlight = new StartTermFlights()
                {
                    
                    Terminal = terminal1
                },
                EndTermFlight = new EndTermFlights()
                {
                    
                    Terminal = terminal4
                }
            };
            db.Flights.Add(oldshit16);

            StartTermFlights ostf16;
            ostf16 = new StartTermFlights()
            {
                Flight = oldshit16,
                Terminal = terminal1
            };
            db.StartTermFlights.Add(ostf16);

            EndTermFlights oetf16;
            oetf16 = new EndTermFlights()
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
                ETA = new DateTime().Subtract.(new DateTime()).Ticks,
                StartTermFlight = new StartTermFlights()
                {
                    
                    Terminal = terminal1
                },
                EndTermFlight = new EndTermFlights()
                {
                    
                    Terminal = terminal4
                }
            };
            db.Flights.Add(oldshit17);

            StartTermFlights ostf17;
            ostf17 = new StartTermFlights()
            {
                Flight = oldshit17,
                Terminal = terminal1
            };
            db.StartTermFlights.Add(ostf17);

            EndTermFlights oetf17;
            oetf17 = new EndTermFlights()
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
                ETA = new DateTime().Subtract.(new DateTime()).Ticks,
                StartTermFlight = new StartTermFlights()
                {
                    
                    Terminal = terminal1
                },
                EndTermFlight = new EndTermFlights()
                {
                    
                    Terminal = terminal4
                }
            };
            db.Flights.Add(oldshit18);

            StartTermFlights ostf18;
            ostf18 = new StartTermFlights()
            {
                Flight = oldshit18,
                Terminal = terminal1
            };
            db.StartTermFlights.Add(ostf18);

            EndTermFlights oetf18;
            oetf18 = new EndTermFlights()
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
                ETA = new DateTime().Subtract.(new DateTime()).Ticks,
                StartTermFlight = new StartTermFlights()
                {
                    
                    Terminal = terminal1
                },
                EndTermFlight = new EndTermFlights()
                {
                    
                    Terminal = terminal4
                }
            };
            db.Flights.Add(oldshit19);

            StartTermFlights ostf19;
            ostf19 = new StartTermFlights()
            {
                Flight = oldshit19,
                Terminal = terminal1
            };
            db.StartTermFlights.Add(ostf19);

            EndTermFlights oetf19;
            oetf19 = new EndTermFlights() 
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
                ETA = new DateTime().Subtract.(new DateTime()).Ticks,
                StartTermFlight = new StartTermFlights()
                {
                    
                    Terminal = terminal1
                },
                EndTermFlight = new EndTermFlights()
                {
                    
                    Terminal = terminal4
                }
            };
            db.Flights.Add(oldshit20);

            StartTermFlights ostf20;
            ostf20 = new StartTermFlights()
            {
                Flight = oldshit20,
                Terminal = terminal1
            };
            db.StartTermFlights.Add(ostf20);

            EndTermFlights oetf20;
            oetf20 = new EndTermFlights()
            {
                Flight = oldshit20,
                Terminal = terminal4
            };
            db.EndTermFlights.Add(oetf20);

            FlightTickets ft1;
            ft1 = new FlightTickets()
            {
                Flight = 
                Ticket = 
                Price = 
                Quantity = 
            };
        }
    }
}

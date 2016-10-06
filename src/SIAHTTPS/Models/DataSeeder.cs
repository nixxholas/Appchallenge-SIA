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

<<<<<<< HEAD
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
                Flight = oldshit7,
                Ticket = economy,
                Price = 1501,
                Quantity = 225,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-39)
            };

            

            FlightTickets ft2;
            ft2 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1502,
                Quantity = 224,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-39)
            };

            

            FlightTickets ft3;
            ft3 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1503,
                Quantity = 223,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-39)
            };

            

            FlightTickets ft4;
            ft4 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1503,
                Quantity = 222,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-39)
            };

            

            FlightTickets ft5;
            ft5 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1503,
                Quantity = 221,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-39)
            };

            

            FlightTickets ft6;
            ft6 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1505,
                Quantity = 220,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-38)
            };

            

            FlightTickets ft7;
            ft7 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1506,
                Quantity = 219,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-38)
            };

            

            FlightTickets ft8;
            ft8 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1508,
                Quantity = 218,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-38)
            };

            

            FlightTickets ft9;
            ft9 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1510,
                Quantity = 217,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-38)
            };

            

            FlightTickets ft10;
            ft10 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1511,
                Quantity = 216,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-38)
            };

            

            FlightTickets ft11;
            ft11 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1512,
                Quantity = 215,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-37)
            };

            

            FlightTickets ft12;
            ft12 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1514,
                Quantity = 214,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-37)
            };

            

            FlightTickets ft13;
            ft13 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1514,
                Quantity = 213,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-36)
            };

            

            FlightTickets ft14;
            ft14 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1515,
                Quantity = 212,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-36)
            };

            

            FlightTickets ft15;
            ft15 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1515,
                Quantity = 211,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-36)
            };

            

            FlightTickets ft16;
            ft16 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1516,
                Quantity = 210,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-36)
            };

            

            FlightTickets ft17;
            ft17 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1518,
                Quantity = 209,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-36)
            };

            

            FlightTickets ft18;
            ft18 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1519,
                Quantity = 208,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-35)
            };

            

            FlightTickets ft19;
            ft19 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1520,
                Quantity = 207,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-35)
            };

            

            FlightTickets ft20;
            ft20 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1521,
                Quantity = 206,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-35)
            };

            

            FlightTickets ft21;
            ft21 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1521,
                Quantity = 205,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-35)
            };

            

            FlightTickets ft22;
            ft22 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1523,
                Quantity = 204,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-35)
            };

            

            FlightTickets ft23;
            ft23 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1525,
                Quantity = 203,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-35)
            };

            

            FlightTickets ft24;
            ft24 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1525,
                Quantity = 202,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-35)
            };

            

            FlightTickets ft25;
            ft25 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1526,
                Quantity = 201,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-34)
            };

            

            FlightTickets ft26;
            ft26 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1527,
                Quantity = 200,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-34)
            };

            

            FlightTickets ft27;
            ft27 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1529,
                Quantity = 199,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-34)
            };

            

            FlightTickets ft28;
            ft28 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1531,
                Quantity = 198,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-34)
            };

            

            FlightTickets ft29;
            ft29 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1532,
                Quantity = 197,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-34)
            };

            

            FlightTickets ft30;
            ft30 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1534,
                Quantity = 196,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-34)
            };

            

            FlightTickets ft31;
            ft31 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1535,
                Quantity = 195,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-34)
            };

            

            FlightTickets ft32;
            ft32 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1537,
                Quantity = 194,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-33)
            };

            

            FlightTickets ft33;
            ft33 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1537,
                Quantity = 193,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-33)
            };

            

            FlightTickets ft34;
            ft34 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1538,
                Quantity = 192,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-33)
            };

            

            FlightTickets ft35;
            ft35 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1539,
                Quantity = 191,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-33)
            };

            

            FlightTickets ft36;
            ft36 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1541,
                Quantity = 190,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-32)
            };

            

            FlightTickets ft37;
            ft37 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1541,
                Quantity = 189,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-32)
            };

            

            FlightTickets ft38;
            ft38 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1543,
                Quantity = 188,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-32)
            };

            

            FlightTickets ft39;
            ft39 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1545,
                Quantity = 187,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-32)
            };

            

            FlightTickets ft40;
            ft40 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1547,
                Quantity = 186,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-31)
            };

            

            FlightTickets ft41;
            ft41 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1548,
                Quantity = 185,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-31)
            };

            

            FlightTickets ft42;
            ft42 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1548,
                Quantity = 184,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-31)
            };

            

            FlightTickets ft43;
            ft43 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1550,
                Quantity = 183,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-31)
            };

            

            FlightTickets ft44;
            ft44 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1552,
                Quantity = 182,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-31)
            };

            

            FlightTickets ft45;
            ft45 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1553,
                Quantity = 181,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-31)
            };

            

            FlightTickets ft46;
            ft46 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1554,
                Quantity = 180,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-30)
            };

            

            FlightTickets ft47;
            ft47 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1555,
                Quantity = 179,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-30)
            };

            

            FlightTickets ft48;
            ft48 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1556,
                Quantity = 178,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-30)
            };

            

            FlightTickets ft49;
            ft49 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1556,
                Quantity = 177,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-30)
            };

            

            FlightTickets ft50;
            ft50 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1557,
                Quantity = 176,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-30)
            };

            

            FlightTickets ft51;
            ft51 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1557,
                Quantity = 175,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-29)
            };

            

            FlightTickets ft52;
            ft52 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1557,
                Quantity = 174,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-29)
            };

            

            FlightTickets ft53;
            ft53 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1559,
                Quantity = 173,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-29)
            };

            

            FlightTickets ft54;
            ft54 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1560,
                Quantity = 172,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-29)
            };

            

            FlightTickets ft55;
            ft55 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1560,
                Quantity = 171,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-29)
            };

            

            FlightTickets ft56;
            ft56 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1560,
                Quantity = 170,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-28)
            };

            

            FlightTickets ft57;
            ft57 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1561,
                Quantity = 169,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-28)
            };

            

            FlightTickets ft58;
            ft58 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1563,
                Quantity = 168,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-28)
            };

            

            FlightTickets ft59;
            ft59 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1564,
                Quantity = 167,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-28)
            };

            

            FlightTickets ft60;
            ft60 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1565,
                Quantity = 166,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-28)
            };

            

            FlightTickets ft61;
            ft61 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1566,
                Quantity = 165,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-27)
            };

            

            FlightTickets ft62;
            ft62 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1567,
                Quantity = 164,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-27)
            };

            

            FlightTickets ft63;
            ft63 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1568,
                Quantity = 163,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-27)
            };

            

            FlightTickets ft64;
            ft64 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1569,
                Quantity = 162,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-27)
            };

            

            FlightTickets ft65;
            ft65 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1570,
                Quantity = 161,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-26)
            };

            

            FlightTickets ft66;
            ft66 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1571,
                Quantity = 160,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-26)
            };

            

            FlightTickets ft67;
            ft67 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1572,
                Quantity = 159,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-26)
            };

            

            FlightTickets ft68;
            ft68 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1574,
                Quantity = 158,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-26)
            };

            

            FlightTickets ft69;
            ft69 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1576,
                Quantity = 157,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-26)
            };

            

            FlightTickets ft70;
            ft70 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1576,
                Quantity = 156,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-26)
            };

            

            FlightTickets ft71;
            ft71 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1577,
                Quantity = 155,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-26)
            };

            

            FlightTickets ft72;
            ft72 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1579,
                Quantity = 154,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-26)
            };

            

            FlightTickets ft73;
            ft73 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1580,
                Quantity = 153,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-26)
            };

            

            FlightTickets ft74;
            ft74 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1582,
                Quantity = 152,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-25)
            };

            

            FlightTickets ft75;
            ft75 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1582,
                Quantity = 151,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-25)
            };

            

            FlightTickets ft76;
            ft76 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1583,
                Quantity = 150,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-25)
            };

            

            FlightTickets ft77;
            ft77 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1583,
                Quantity = 149,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-24)
            };

            

            FlightTickets ft78;
            ft78 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1583,
                Quantity = 148,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-24)
            };

            

            FlightTickets ft79;
            ft79 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1585,
                Quantity = 147,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-24)
            };

            

            FlightTickets ft80;
            ft80 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1585,
                Quantity = 146,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-24)
            };

            

            FlightTickets ft81;
            ft81 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1587,
                Quantity = 145,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-24)
            };

            

            FlightTickets ft82;
            ft82 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1589,
                Quantity = 144,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-24)
            };

            

            FlightTickets ft83;
            ft83 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1591,
                Quantity = 143,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-24)
            };

            

            FlightTickets ft84;
            ft84 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1591,
                Quantity = 142,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-23)
            };

            

            FlightTickets ft85;
            ft85 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1591,
                Quantity = 141,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-23)
            };

            

            FlightTickets ft86;
            ft86 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1592,
                Quantity = 140,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-23)
            };

            

            FlightTickets ft87;
            ft87 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1594,
                Quantity = 139,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-23)
            };

            

            FlightTickets ft88;
            ft88 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1596,
                Quantity = 138,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-23)
            };

            

            FlightTickets ft89;
            ft89 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1596,
                Quantity = 137,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-22)
            };

            

            FlightTickets ft90;
            ft90 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1598,
                Quantity = 136,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-22)
            };

            

            FlightTickets ft91;
            ft91 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1600,
                Quantity = 135,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-22)
            };

            

            FlightTickets ft92;
            ft92 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1601,
                Quantity = 134,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-22)
            };

            

            FlightTickets ft93;
            ft93 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1601,
                Quantity = 133,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-22)
            };

            

            FlightTickets ft94;
            ft94 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1601,
                Quantity = 132,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-22)
            };

            

            FlightTickets ft95;
            ft95 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1602,
                Quantity = 131,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-21)
            };

            

            FlightTickets ft96;
            ft96 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1602,
                Quantity = 130,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-21)
            };

            

            FlightTickets ft97;
            ft97 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1602,
                Quantity = 129,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-21)
            };

            

            FlightTickets ft98;
            ft98 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1602,
                Quantity = 128,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-21)
            };

            

            FlightTickets ft99;
            ft99 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1602,
                Quantity = 127,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-20)
            };

            

            FlightTickets ft100;
            ft100 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1604,
                Quantity = 126,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-20)
            };

            

            FlightTickets ft101;
            ft101 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1604,
                Quantity = 125,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-20)
            };

            

            FlightTickets ft102;
            ft102 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1604,
                Quantity = 124,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-20)
            };

            

            FlightTickets ft103;
            ft103 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1606,
                Quantity = 123,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-20)
            };

            

            FlightTickets ft104;
            ft104 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1607,
                Quantity = 122,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-20)
            };

            

            FlightTickets ft105;
            ft105 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1609,
                Quantity = 121,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-20)
            };

            

            FlightTickets ft106;
            ft106 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1610,
                Quantity = 120,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-20)
            };

            

            FlightTickets ft107;
            ft107 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1610,
                Quantity = 119,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-20)
            };

            

            FlightTickets ft108;
            ft108 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1610,
                Quantity = 118,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-20)
            };

            

            FlightTickets ft109;
            ft109 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1610,
                Quantity = 117,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-20)
            };

            

            FlightTickets ft110;
            ft110 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1611,
                Quantity = 116,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-19)
            };

            

            FlightTickets ft111;
            ft111 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1611,
                Quantity = 115,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-19)
            };

            

            FlightTickets ft112;
            ft112 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1613,
                Quantity = 114,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-19)
            };

            

            FlightTickets ft113;
            ft113 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1613,
                Quantity = 113,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-19)
            };

            

            FlightTickets ft114;
            ft114 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1615,
                Quantity = 112,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-19)
            };

            

            FlightTickets ft115;
            ft115 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1616,
                Quantity = 111,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-19)
            };

            

            FlightTickets ft116;
            ft116 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1616,
                Quantity = 110,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-18)
            };

            

            FlightTickets ft117;
            ft117 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1616,
                Quantity = 109,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-18)
            };

            

            FlightTickets ft118;
            ft118 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1617,
                Quantity = 108,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-18)
            };

            

            FlightTickets ft119;
            ft119 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1618,
                Quantity = 107,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-18)
            };

            

            FlightTickets ft120;
            ft120 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1619,
                Quantity = 106,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-18)
            };

            

            FlightTickets ft121;
            ft121 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1619,
                Quantity = 105,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-18)
            };

            

            FlightTickets ft122;
            ft122 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1620,
                Quantity = 104,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-18)
            };

            

            FlightTickets ft123;
            ft123 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1620,
                Quantity = 103,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-18)
            };

            

            FlightTickets ft124;
            ft124 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1620,
                Quantity = 102,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-17)
            };

            

            FlightTickets ft125;
            ft125 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1621,
                Quantity = 101,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-17)
            };

            

            FlightTickets ft126;
            ft126 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1623,
                Quantity = 100,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-16)
            };

            

            FlightTickets ft127;
            ft127 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1623,
                Quantity = 99,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-16)
            };

            

            FlightTickets ft128;
            ft128 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1623,
                Quantity = 98,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-16)
            };

            

            FlightTickets ft129;
            ft129 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1623,
                Quantity = 97,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-16)
            };

            

            FlightTickets ft130;
            ft130 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1623,
                Quantity = 96,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-16)
            };

            

            FlightTickets ft131;
            ft131 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1625,
                Quantity = 95,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-16)
            };

            

            FlightTickets ft132;
            ft132 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1627,
                Quantity = 94,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-16)
            };

            

            FlightTickets ft133;
            ft133 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1629,
                Quantity = 93,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-16)
            };

            

            FlightTickets ft134;
            ft134 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1631,
                Quantity = 92,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-15)
            };

            

            FlightTickets ft135;
            ft135 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1632,
                Quantity = 91,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-15)
            };

            

            FlightTickets ft136;
            ft136 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1634,
                Quantity = 90,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-15)
            };

            

            FlightTickets ft137;
            ft137 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1635,
                Quantity = 89,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-15)
            };

            

            FlightTickets ft138;
            ft138 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1636,
                Quantity = 88,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-14)
            };

            

            FlightTickets ft139;
            ft139 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1637,
                Quantity = 87,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-14)
            };

            

            FlightTickets ft140;
            ft140 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1637,
                Quantity = 86,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-14)
            };

            

            FlightTickets ft141;
            ft141 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1639,
                Quantity = 85,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-14)
            };

            

            FlightTickets ft142;
            ft142 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1640,
                Quantity = 84,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-14)
            };

            

            FlightTickets ft143;
            ft143 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1642,
                Quantity = 83,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-14)
            };

            

            FlightTickets ft144;
            ft144 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1642,
                Quantity = 82,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-14)
            };

            

            FlightTickets ft145;
            ft145 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1644,
                Quantity = 81,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-13)
            };

            

            FlightTickets ft146;
            ft146 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1644,
                Quantity = 80,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-13)
            };

            

            FlightTickets ft147;
            ft147 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1646,
                Quantity = 79,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-13)
            };

            

            FlightTickets ft148;
            ft148 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1647,
                Quantity = 78,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-13)
            };

            

            FlightTickets ft149;
            ft149 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1649,
                Quantity = 77,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-13)
            };

            

            FlightTickets ft150;
            ft150 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1650,
                Quantity = 76,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-13)
            };

            

            FlightTickets ft151;
            ft151 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1651,
                Quantity = 75,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-12)
            };

            

            FlightTickets ft152;
            ft152 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1652,
                Quantity = 74,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-12)
            };

            

            FlightTickets ft153;
            ft153 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1652,
                Quantity = 73,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-12)
            };

            

            FlightTickets ft154;
            ft154 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1654,
                Quantity = 72,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-12)
            };

            

            FlightTickets ft155;
            ft155 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1656,
                Quantity = 71,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-12)
            };

            

            FlightTickets ft156;
            ft156 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1656,
                Quantity = 70,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-11)
            };

            

            FlightTickets ft157;
            ft157 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1658,
                Quantity = 69,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-11)
            };

            

            FlightTickets ft158;
            ft158 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1660,
                Quantity = 68,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-11)
            };

            

            FlightTickets ft159;
            ft159 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1662,
                Quantity = 67,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-10)
            };

            

            FlightTickets ft160;
            ft160 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1664,
                Quantity = 66,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-10)
            };

            

            FlightTickets ft161;
            ft161 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1665,
                Quantity = 65,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-10)
            };

            

            FlightTickets ft162;
            ft162 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1666,
                Quantity = 64,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-10)
            };

            

            FlightTickets ft163;
            ft163 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1667,
                Quantity = 63,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-10)
            };

            

            FlightTickets ft164;
            ft164 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1668,
                Quantity = 62,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-10)
            };

            

            FlightTickets ft165;
            ft165 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1668,
                Quantity = 61,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-10)
            };

            

            FlightTickets ft166;
            ft166 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1669,
                Quantity = 60,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-9)
            };

            

            FlightTickets ft167;
            ft167 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1669,
                Quantity = 59,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-9)
            };

            

            FlightTickets ft168;
            ft168 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1671,
                Quantity = 58,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-9)
            };

            

            FlightTickets ft169;
            ft169 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1672,
                Quantity = 57,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-9)
            };

            

            FlightTickets ft170;
            ft170 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1673,
                Quantity = 56,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-9)
            };

            

            FlightTickets ft171;
            ft171 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1673,
                Quantity = 55,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-9)
            };

            

            FlightTickets ft172;
            ft172 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1673,
                Quantity = 54,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-9)
            };

            

            FlightTickets ft173;
            ft173 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1675,
                Quantity = 53,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-8)
            };

            

            FlightTickets ft174;
            ft174 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1676,
                Quantity = 52,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-8)
            };

            

            FlightTickets ft175;
            ft175 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1678,
                Quantity = 51,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-8)
            };

            

            FlightTickets ft176;
            ft176 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1680,
                Quantity = 50,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-7)
            };

            

            FlightTickets ft177;
            ft177 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1680,
                Quantity = 49,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-7)
            };

            

            FlightTickets ft178;
            ft178 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1682,
                Quantity = 48,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-7)
            };

            

            FlightTickets ft179;
            ft179 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1684,
                Quantity = 47,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-7)
            };

            

            FlightTickets ft180;
            ft180 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1685,
                Quantity = 46,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-7)
            };

            

            FlightTickets ft181;
            ft181 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1686,
                Quantity = 45,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-6)
            };

            

            FlightTickets ft182;
            ft182 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1686,
                Quantity = 44,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-6)
            };

            

            FlightTickets ft183;
            ft183 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1688,
                Quantity = 43,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-6)
            };

            

            FlightTickets ft184;
            ft184 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1689,
                Quantity = 42,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-5)
            };

            

            FlightTickets ft185;
            ft185 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1691,
                Quantity = 41,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-5)
            };

            

            FlightTickets ft186;
            ft186 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1691,
                Quantity = 40,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-5)
            };

            

            FlightTickets ft187;
            ft187 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1691,
                Quantity = 39,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-5)
            };

            

            FlightTickets ft188;
            ft188 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1693,
                Quantity = 38,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-5)
            };

            

            FlightTickets ft189;
            ft189 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1695,
                Quantity = 37,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-5)
            };

            

            FlightTickets ft190;
            ft190 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1697,
                Quantity = 36,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-5)
            };

            

            FlightTickets ft191;
            ft191 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1698,
                Quantity = 35,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-4)
            };

            

            FlightTickets ft192;
            ft192 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1698,
                Quantity = 34,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-4)
            };

            

            FlightTickets ft193;
            ft193 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1700,
                Quantity = 33,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-4)
            };

            

            FlightTickets ft194;
            ft194 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1701,
                Quantity = 32,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-4)
            };

            

            FlightTickets ft195;
            ft195 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1703,
                Quantity = 31,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-4)
            };

            

            FlightTickets ft196;
            ft196 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1705,
                Quantity = 30,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-3)
            };

            

            FlightTickets ft197;
            ft197 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1705,
                Quantity = 29,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-3)
            };

            

            FlightTickets ft198;
            ft198 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1707,
                Quantity = 28,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-3)
            };

            

            FlightTickets ft199;
            ft199 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1707,
                Quantity = 27,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-3)
            };

            

            FlightTickets ft200;
            ft200 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1708,
                Quantity = 26,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-3)
            };

            

            FlightTickets ft201;
            ft201 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1709,
                Quantity = 25,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-3)
            };

            

            FlightTickets ft202;
            ft202 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1710,
                Quantity = 24,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-3)
            };

            

            FlightTickets ft203;
            ft203 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1711,
                Quantity = 23,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-3)
            };

            

            FlightTickets ft204;
            ft204 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1712,
                Quantity = 22,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-3)
            };

            

            FlightTickets ft205;
            ft205 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1714,
                Quantity = 21,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-2)
            };

            

            FlightTickets ft206;
            ft206 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1714,
                Quantity = 20,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-2)
            };

            

            FlightTickets ft207;
            ft207 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1714,
                Quantity = 19,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-2)
            };

            

            FlightTickets ft208;
            ft208 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1715,
                Quantity = 18,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-2)
            };

            

            FlightTickets ft209;
            ft209 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1715,
                Quantity = 17,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-2)
            };

            

            FlightTickets ft210;
            ft210 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1715,
                Quantity = 16,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-2)
            };

            

            FlightTickets ft211;
            ft211 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1717,
                Quantity = 15,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-2)
            };

            

            FlightTickets ft212;
            ft212 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1717,
                Quantity = 14,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-2)
            };

            

            FlightTickets ft213;
            ft213 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1717,
                Quantity = 13,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-2)
            };

            

            FlightTickets ft214;
            ft214 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1717,
                Quantity = 12,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-2)
            };

            

            FlightTickets ft215;
            ft215 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1717,
                Quantity = 11,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-1)
            };

            

            FlightTickets ft216;
            ft216 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1717,
                Quantity = 10,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-1)
            };

            

            FlightTickets ft217;
            ft217 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1719,
                Quantity = 9,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-1)
            };

            

            FlightTickets ft218;
            ft218 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1719,
                Quantity = 8,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-1)
            };

            

            FlightTickets ft219;
            ft219 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1719,
                Quantity = 7,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-0)
            };

            

            FlightTickets ft220;
            ft220 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1719,
                Quantity = 6,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-0)
            };

            

            FlightTickets ft221;
            ft221 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1721,
                Quantity = 5,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-0)
            };

            

            FlightTickets ft222;
            ft222 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1722,
                Quantity = 4,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-0)
            };

            

            FlightTickets ft223;
            ft223 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1722,
                Quantity = 3,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-0)
            };

            

            FlightTickets ft224;
            ft224 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = economy,
                Price = 1722,
                Quantity = 2,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-0)
            };

            

            FlightTickets ft227;
            ft227 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5004,
                Quantity = 45,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-38)
            };

            

            FlightTickets ft228;
            ft228 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5004,
                Quantity = 44,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-38)
            };

            

            FlightTickets ft229;
            ft229 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5006,
                Quantity = 43,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-38)
            };

            

            FlightTickets ft230;
            ft230 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5006,
                Quantity = 42,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-37)
            };

            

            FlightTickets ft231;
            ft231 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5007,
                Quantity = 41,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-37)
            };

            

            FlightTickets ft232;
            ft232 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5008,
                Quantity = 40,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-36)
            };

            

            FlightTickets ft233;
            ft233 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5011,
                Quantity = 39,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-36)
            };

            

            FlightTickets ft234;
            ft234 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5015,
                Quantity = 38,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-36)
            };

            

            FlightTickets ft235;
            ft235 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5015,
                Quantity = 37,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-35)
            };

            

            FlightTickets ft236;
            ft236 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5016,
                Quantity = 36,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-33)
            };

            

            FlightTickets ft237;
            ft237 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5020,
                Quantity = 35,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-33)
            };

            

            FlightTickets ft238;
            ft238 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5024,
                Quantity = 34,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-32)
            };

            

            FlightTickets ft239;
            ft239 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5025,
                Quantity = 33,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-32)
            };

            

            FlightTickets ft240;
            ft240 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5025,
                Quantity = 32,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-31)
            };

            

            FlightTickets ft241;
            ft241 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5028,
                Quantity = 31,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-31)
            };

            

            FlightTickets ft242;
            ft242 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5032,
                Quantity = 30,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-29)
            };

            

            FlightTickets ft243;
            ft243 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5032,
                Quantity = 29,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-27)
            };

            

            FlightTickets ft244;
            ft244 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5035,
                Quantity = 28,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-27)
            };

            

            FlightTickets ft245;
            ft245 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5039,
                Quantity = 27,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-27)
            };

            

            FlightTickets ft246;
            ft246 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5043,
                Quantity = 26,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-25)
            };

            

            FlightTickets ft247;
            ft247 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5045,
                Quantity = 25,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-25)
            };

            

            FlightTickets ft248;
            ft248 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5048,
                Quantity = 24,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-23)
            };

            

            FlightTickets ft249;
            ft249 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5051,
                Quantity = 23,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-21)
            };

            

            FlightTickets ft250;
            ft250 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5053,
                Quantity = 22,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-19)
            };

            

            FlightTickets ft251;
            ft251 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5057,
                Quantity = 21,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-19)
            };

            

            FlightTickets ft252;
            ft252 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5059,
                Quantity = 20,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-18)
            };

            

            FlightTickets ft253;
            ft253 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5059,
                Quantity = 19,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-18)
            };

            

            FlightTickets ft254;
            ft254 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5062,
                Quantity = 18,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-17)
            };

            

            FlightTickets ft255;
            ft255 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5066,
                Quantity = 17,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-17)
            };

            

            FlightTickets ft256;
            ft256 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5070,
                Quantity = 16,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-16)
            };

            

            FlightTickets ft257;
            ft257 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5074,
                Quantity = 15,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-14)
            };

            

            FlightTickets ft258;
            ft258 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5075,
                Quantity = 14,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-12)
            };

            

            FlightTickets ft259;
            ft259 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5075,
                Quantity = 13,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-12)
            };

            

            FlightTickets ft260;
            ft260 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5077,
                Quantity = 12,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-12)
            };

            

            FlightTickets ft261;
            ft261 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5081,
                Quantity = 11,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-11)
            };

            

            FlightTickets ft262;
            ft262 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5083,
                Quantity = 10,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-9)
            };

            

            FlightTickets ft263;
            ft263 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5084,
                Quantity = 9,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-8)
            };

            

            FlightTickets ft264;
            ft264 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5085,
                Quantity = 8,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-8)
            };

            

            FlightTickets ft265;
            ft265 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5085,
                Quantity = 7,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-7)
            };

            

            FlightTickets ft266;
            ft266 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5089,
                Quantity = 6,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-7)
            };

            

            FlightTickets ft267;
            ft267 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5092,
                Quantity = 5,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-7)
            };

            

            FlightTickets ft268;
            ft268 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5096,
                Quantity = 4,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-6)
            };

            

            FlightTickets ft269;
            ft269 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5099,
                Quantity = 3,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-5)
            };

            

            FlightTickets ft270;
            ft270 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = business,
                Price = 5099,
                Quantity = 2,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-3)
            };

            

            FlightTickets ft301;
            ft301 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = firstClass,
                Price = 11016,
                Quantity = 8,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-33)
            };

            

            FlightTickets ft302;
            ft302 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = firstClass,
                Price = 11017,
                Quantity = 7,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-28)
            };

            

            FlightTickets ft303;
            ft303 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = firstClass,
                Price = 11033,
                Quantity = 6,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-24)
            };

            

            FlightTickets ft304;
            ft304 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = firstClass,
                Price = 11040,
                Quantity = 5,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-22)
            };

            

            FlightTickets ft305;
            ft305 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = firstClass,
                Price = 11045,
                Quantity = 4,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-17)
            };

            

            FlightTickets ft306;
            ft306 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = firstClass,
                Price = 11050,
                Quantity = 3,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-14)
            };

            

            FlightTickets ft307;
            ft307 = new FlightTickets()
            {
                Flight = oldshit7,
                Ticket = firstClass,
                Price = 11068,
                Quantity = 2,
                PurchaseDate = new DateTime(2016, 09, 12, 00, 13, 00).AddDays(-14)
            };
=======
            //FlightTicket ft1;
            //ft1 = new FlightTicket()
            //{

            //};
>>>>>>> 86209f0... APIs: Workable Rate

            
    }
}

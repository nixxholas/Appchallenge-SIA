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

            Ticket ticket1;
            ticket1 = new Ticket()
            {
                TicketType = "First Class",
                TicketName = ""
            };
            db.Tickets.Add(ticket1);

            Ticket ticket2;
            ticket2 = new Ticket()
            {
                TicketType = "Business",
                TicketName = ""
            };
            db.Tickets.Add(ticket2);

            Ticket ticket3;
            ticket3 = new Ticket()
            {
                TicketType = "Economy Class",
                TicketName = ""
            };
            db.Tickets.Add(ticket3);

            Ticket ticket4;
            ticket4 = new Ticket()
            {
                TicketType = "Premium Economy Class",
                TicketName = ""
            };
            db.Tickets.Add(ticket4);
            
            db.SaveChanges();
        }
    }
}

namespace InventorySystem.Migrations
{
    using InventorySystem.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<InventorySystem.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(InventorySystem.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            manager.Create(new ApplicationUser
            {
                Email = "enas_osama@outlook.com",
                UserName = "enas_osama@outlook.com"
            }, "Abc123");

        }
    }
}

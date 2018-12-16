namespace InventorySystem.EF.Migrations
{
    using InventorySystem.Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<InventorySystem.EF.InventoryDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(InventorySystem.EF.InventoryDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var brands = new List<Brand>
            {
                new Brand
                {
                    Name = "HTC"
                },
                new Brand
                {
                    Name = "Apple"
                },
                new Brand
                {
                    Name = "Samsung"
                }
            };

            brands.ForEach(b => context.Brands.Add(b));
            context.SaveChanges();

            var categories = new List<Category>
            {
                new Category
                {
                    Name = "Android"
                },
                new Category
                {
                    Name = "IOS"
                }
            };

            categories.ForEach(c => context.Categories.Add(c));
            context.SaveChanges();

        }
    }
}

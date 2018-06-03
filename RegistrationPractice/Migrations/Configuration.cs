namespace RegistrationPractice.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using RegistrationPractice.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<RegistrationPractice.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(RegistrationPractice.Models.ApplicationDbContext context)
        {
            context.Locations.AddOrUpdate(x => x.Id,
            new Location() { LocationText ="winnipeg"},
            new Location() { LocationText = "toronto" }
            );


            context.Categories.AddOrUpdate(x => x.Id,
            new Category() { CategoryText = "pet" },
            new Category() { CategoryText = "vehicle" }
            );
        }
    }
}

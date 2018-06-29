namespace RegistrationPractice.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using RegistrationPractice.Entities;
    using RegistrationPractice.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<RegistrationPractice.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        public object WebSecurity { get; private set; }

        protected override void Seed(RegistrationPractice.Models.ApplicationDbContext context)
        {
            context.Locations.AddOrUpdate(x => x.Id,
            new Location() { LocationText = "winnipeg" },
            new Location() { LocationText = "toronto" }
            );


            context.Categories.AddOrUpdate(x => x.Id,
            new Category() { CategoryText = "pet" },
            new Category() { CategoryText = "vehicle" }
            );

            //if (!context.Roles.Any(r => r.Name == "AppAdmin"))
            //{
            //    var store = new RoleStore<IdentityRole>(context);
            //    var manager = new RoleManager<IdentityRole>(store);
            //    var role = new IdentityRole { Name = "AppAdmin" };

            //    manager.Create(role);
            //}

            //if (!context.Users.Any(u => u.UserName == "founder"))
            //{
            //    var store = new UserStore<ApplicationUser>(context);
            //    var manager = new UserManager<ApplicationUser>(store);
            //    var user = new ApplicationUser { UserName = "founder" };

            //    manager.Create(user, "ChangeItAsap!");
            //    manager.AddToRole(user.Id, "AppAdmin");
            //}
        }
        
    }
}

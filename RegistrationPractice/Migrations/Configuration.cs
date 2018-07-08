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
            //context.Locations.AddOrUpdate(x => x.Id,
            //new Location() { LocationText = "winnipeg" },
            //new Location() { LocationText = "toronto" },
            //new Location() { LocationText = "vancouver" },
            //new Location() { LocationText = "calgary" },
            //new Location() { LocationText = "edmonton" }

            //);


            //context.Categories.AddOrUpdate(x => x.Id,
            //new Category() { CategoryText = "pet" },
            //new Category() { CategoryText = "vehicle" },
            //new Category() { CategoryText = "electronics" },
            //new Category() { CategoryText = "bikes" },
            //new Category() { CategoryText = "phones" },
            //new Category() { CategoryText = "personal items" }

            //);

            //context.PostTypes.AddOrUpdate(x => x.Id,
            //new PostType() { PostTypeText = "lost" },
            //new PostType() { PostTypeText = "found" },
            //new PostType() { PostTypeText = "stolen" }
            //);
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

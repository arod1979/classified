using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RegistrationPractice.Entities;

namespace RegistrationPractice.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        //allan rodkin
        public virtual ICollection<Item> Items { get; set; }
        public string FirstName { get; set; }
        public bool IsActive { get; set; }
        public DateTime Registered { get; set; } = DateTime.Now;
        public bool IsAdmin { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<CategoryPostType> CategoryPostType { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<PostType> PostTypes { get; set; }


        public ApplicationDbContext(string connectionstring)
            : base(connectionstring, throwIfV1Schema: false)
        {
            //Database.SetInitializer<ApplicationDbContext>(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
            Database.SetInitializer<ApplicationDbContext>(null);
        }

        public ApplicationDbContext()
             : base("DefaultConnection", throwIfV1Schema: false)
        {
            //Database.SetInitializer<ApplicationDbContext>(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
            Database.SetInitializer<ApplicationDbContext>(null);
        }


        //deleted to allow simple injector work
        //public static ApplicationDbContext Create()
        //{
        //    return new ApplicationDbContext();
        //}


    }



    public class EmailsDbContext : DbContext
    {

        public DbSet<Email> Emails { get; set; }
        public DbSet<EmailRecipients> EmailRecipients { get; set; }
        public DbSet<HistoryID> HistoryIDs { get; set; }
        public DbSet<FakeEmail> FakeEmails { get; set; }
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }

        public EmailsDbContext() : base("EmailConnection")
        {
            {
                //Database.SetInitializer<ApplicationDbContext>(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
                Database.SetInitializer<EmailsDbContext>(null);
            }
        }

    }
}
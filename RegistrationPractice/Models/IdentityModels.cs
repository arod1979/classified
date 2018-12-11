using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
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
        public DbSet<Totals> Totals { get; set; }


        public ApplicationDbContext(string connectionstring)
            : base(connectionstring, throwIfV1Schema: false)
        {
            Database.SetInitializer<ApplicationDbContext>(null);
            //Database.SetInitializer<ApplicationDbContext>(null);
        }

        public ApplicationDbContext()
             : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer<ApplicationDbContext>(null);
            //Database.SetInitializer<ApplicationDbContext>(null);
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
        //public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }

        public EmailsDbContext() : base("EmailConnection")
        {
            {
                Database.SetInitializer<ApplicationDbContext>(null);
                //Database.SetInitializer<EmailsDbContext>(null);
            }
        }

    }

    public class ExecutionStrategy : DbExecutionStrategy
    {
        /// <summary>
        /// The default retry limit is 5, which means that the total amount of time spent 
        /// between retries is 26 seconds plus the random factor.
        /// </summary>
        public ExecutionStrategy()
        {
        }

        /// <summary>
        /// Creates a new instance of "PharylonExecutionStrategy" with the specified limits for
        /// number of retries and the delay between retries.
        /// </summary>
        /// <param name="maxRetryCount"> The maximum number of retry attempts. </param>
        /// <param name="maxDelay"> The maximum delay in milliseconds between retries. </param>
        public ExecutionStrategy(int maxRetryCount, TimeSpan maxDelay)
            : base(maxRetryCount, maxDelay)
        {
        }

        protected override bool ShouldRetryOn(Exception ex)
        {
            bool retry = false;

            SqlException sqlException = ex as SqlException;
            if (sqlException != null)
            {
                int[] errorsToRetry =
                {
                    1205,  //Deadlock
                    -2,    //Timeout
                    2601  //primary key violation. Normally you wouldn't want to retry these, 
                          //but some procs in my database can cause it, because it's a crappy 
                          //legacy junkpile.
                };
                if (sqlException.Errors.Cast<SqlError>().Any(x => errorsToRetry.Contains(x.Number)))
                {
                    retry = true;
                }
                else
                {
                    //Add some error logging on this line for errors we aren't retrying.
                    //Make sure you record the Number property of sqlError. 
                    //If you see an error pop up that you want to retry, you can look in 
                    //your log and add that number to the list above.
                }
            }
            if (ex is TimeoutException)
            {
                retry = true;
            }
            return retry;
        }
    }

    class AwolrConfiguration : DbConfiguration
    {
        public AwolrConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new ExecutionStrategy());
        }
    }
}
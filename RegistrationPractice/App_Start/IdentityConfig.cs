using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using RegistrationPractice.Models;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Net.Mime;
using System.Net;
using SendGrid;
using SendGrid.Helpers.Mail;
using RegistrationPractice.Classes;

namespace RegistrationPractice
{
    public class EmailService : IIdentityMessageService
    {
        private LoggerWrapper loggerwrapper = new LoggerWrapper();

        public async Task SendAsync(IdentityMessage message)
        {

            // Plug in your email service here to send an email.
            //return Task.FromResult(0);
            //return Task.Factory.StartNew(() =>
            //{
            //    SendMail(message);
            //});
            await SendMail(message);
            //await Execute(message);
        }




        private async Task Execute(IdentityMessage message)
        {


            //var apiKey = "y8S:HJaP6!WL3w/";
            var apiKey = "asdfsdf";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("test@example.com", "Example User");
            var subject = message.Subject;
            var to = new EmailAddress(message.Destination);
            var plainTextContent = string.Format("Please click on this link to {0}:{1}", message.Subject, message.Body);
            var htmlContent = "Please confirm your account by clicking on this link: <a href=\"" + message.Body +
                "\">link</a><br/>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }

        private async Task SendMail(IdentityMessage message)

        {
            string text = string.Format("Please click on this link to {0}:{1}", message.Subject, message.Body);
            string html = "Please confirm your account by clicking on this link: <a href=\"" + message.Body +
                "\">link</a><br/>";
            html += HttpUtility.HtmlEncode(@"Or copy the following link to your browser:" + message.Body);
            string email = System.Configuration.ConfigurationManager.AppSettings["email"];
            string password = System.Configuration.ConfigurationManager.AppSettings["emailpassword"];
            string server = System.Configuration.ConfigurationManager.AppSettings["emailserver"];
            string emailport = System.Configuration.ConfigurationManager.AppSettings["emailport"];
            int port = Int32.Parse(emailport);
            try
            {

                //email = "admin@awolr.com";
                //password = "passWord321$";

                var client = new SmtpClient(server, port)
                {

                    Credentials = new NetworkCredential(email, password),
                    EnableSsl = true
                };


                await client.SendMailAsync("admin@awolr.com", message.Destination, message.Subject, message.Body);
                Console.WriteLine("Sent");
                //Console.ReadLine();

            }
            catch (Exception ex)
            {
                loggerwrapper.PickAndExecuteLogging("email could not be sent" + ex.Message);
            }

        }





    }




    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }




    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        //removed to support simple injector
        //public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context) 
        //{
        //    var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
        //    // Configure validation logic for usernames
        //    manager.UserValidator = new UserValidator<ApplicationUser>(manager)
        //    {
        //        AllowOnlyAlphanumericUserNames = false,
        //        RequireUniqueEmail = true
        //    };

        //    // Configure validation logic for passwords
        //    manager.PasswordValidator = new PasswordValidator
        //    {
        //        RequiredLength = 6,
        //        RequireNonLetterOrDigit = true,
        //        RequireDigit = true,
        //        RequireLowercase = true,
        //        RequireUppercase = true,
        //    };

        //    // Configure user lockout defaults
        //    manager.UserLockoutEnabledByDefault = true;
        //    manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
        //    manager.MaxFailedAccessAttemptsBeforeLockout = 5;

        //    // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
        //    // You can write your own provider and plug it in here.
        //    manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<ApplicationUser>
        //    {
        //        MessageFormat = "Your security code is {0}"
        //    });
        //    manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<ApplicationUser>
        //    {
        //        Subject = "Security Code",
        //        BodyFormat = "Your security code is {0}"
        //    });
        //manager.EmailService = new EmailService();
        //manager.SmsService = new SmsService();
        //    var dataProtectionProvider = options.DataProtectionProvider;
        //    if (dataProtectionProvider != null)
        //    {
        //        manager.UserTokenProvider = 
        //            new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
        //    }
        //    return manager;
        //}
    }

    // Configure the application sign-in manager which is used in this application.
    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
            userManager.EmailService = new EmailService();
            userManager.SmsService = new SmsService();
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }
}

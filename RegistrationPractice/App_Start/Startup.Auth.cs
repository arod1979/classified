using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.Owin.Security.Google;
using Owin;
using RegistrationPractice.DAL;
using RegistrationPractice.Interfaces;
using RegistrationPractice.Models;
using RegistrationPractice.Classes.Session;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using RegistrationPractice.Classes.Globals;
using RegistrationPractice.Classes;
using RegistrationPractice.Controllers;
//using RegistrationPractice.Controllers.aspnetmvc;

namespace RegistrationPractice
{
    public partial class Startup
    {

        // For more information on configuring authentication, please visit https://go.microsoft.com/fwlink/?LinkId=301864

        public static ApplicationUserManager exportUserManager;


        public void ConfigureAuth(IAppBuilder app, Container container)
        {
            // Configure the db context, user manager and signin manager to use a single instance per request
            //removed to support simpleinjector
            //app.CreatePerOwinContext(ApplicationDbContext.Create);
            //app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            //app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);
            app.CreatePerOwinContext(() => container.GetInstance<ApplicationUserManager>());
            exportUserManager = container.GetInstance<ApplicationUserManager>();

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                ExpireTimeSpan = TimeSpan.FromMinutes(5),
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // Enables the application to validate the security stamp when the user logs in.
                    // This is a security feature which is used when you change a password or add an external login to your account.  
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Enables the application to remember the second login verification factor such as phone or email.
            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
            // This is similar to the RememberMe option when you log in.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            app.UseFacebookAuthentication(
               appId: "303700687093451",
               appSecret: "896f3a3797e5c682ed62c8767518618a");


            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            {
                ClientId = "913060532754-nkhkc0t2smn22mt5qpaj59n9c67vl6fp.apps.googleusercontent.com",

                ClientSecret = "BouJXmwmhQSytT0wFh20tHpD"
            });
        }

        public static class SimpleInjectorInitializer
        {
            public static Container Initialize(IAppBuilder app)
            {
                var container = GetInitializeContainer(app);

                container.Verify();

                DependencyResolver.SetResolver(
                    new SimpleInjectorDependencyResolver(container));

                return container;
            }

            public static Container GetInitializeContainer(
                      IAppBuilder app)
            {
                var container = new Container();
                container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
                container.RegisterSingleton<IAppBuilder>(app);



                container.Register<ApplicationUserManager>(Lifestyle.Scoped);

                container.Register<ApplicationSignInManager>(Lifestyle.Scoped);

                container.Register<Classes.Globals.Constants>(Lifestyle.Scoped);

                container.Register<RegistrationPractice.Classes.LoggerWrapper>(Lifestyle.Scoped);

                container.Register<IO_Operations>(Lifestyle.Scoped);


                container.Register<Classes.Globals.CityListing>(Lifestyle.Scoped);

                container.Register<ApplicationDbContext>(()
                  => new ApplicationDbContext(
                   "DefaultConnection"), Lifestyle.Scoped);



                container.Register<IUserStore<
                  ApplicationUser>>(() =>
                    new UserStore<ApplicationUser>(
                      container.GetInstance<ApplicationDbContext>()), Lifestyle.Scoped);

                container.RegisterInitializer<ApplicationUserManager>(
                    manager => InitializeUserManager(manager, app));

                container.Register<SignInManager<ApplicationUser, string>, ApplicationSignInManager>(Lifestyle.Scoped);

                container.Register<IAuthenticationManager>(() =>
    container.IsVerifying
        ? new OwinContext(new Dictionary<string, object>()).Authentication
        : HttpContext.Current.GetOwinContext().Authentication, Lifestyle.Scoped);


                container.RegisterMvcControllers(
                        Assembly.GetExecutingAssembly());

                return container;
            }

            private static void InitializeUserManager(
                ApplicationUserManager manager, IAppBuilder app)
            {
                manager.UserValidator =
                 new UserValidator<ApplicationUser>(manager)
                 {
                     AllowOnlyAlphanumericUserNames = false,
                     RequireUniqueEmail = true
                 };

                //Configure validation logic for passwords
                manager.PasswordValidator = new PasswordValidator()
                {
                    RequiredLength = 6,
                    RequireNonLetterOrDigit = false,
                    RequireDigit = false,
                    RequireLowercase = false,
                    RequireUppercase = false,
                };

                // Configure user lockout defaults
                manager.UserLockoutEnabledByDefault = true;
                manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
                manager.MaxFailedAccessAttemptsBeforeLockout = 5;

                // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
                // You can write your own provider and plug it in here.
                manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<ApplicationUser>
                {
                    MessageFormat = "Your security code is {0}"
                });
                manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<ApplicationUser>
                {
                    Subject = "Security Code",
                    BodyFormat = "Your security code is {0}"
                });
                manager.EmailService = new EmailService();
                manager.SmsService = new SmsService();



                var dataProtectionProvider =
                     app.GetDataProtectionProvider();

                if (dataProtectionProvider != null)
                {
                    manager.UserTokenProvider =
                     new DataProtectorTokenProvider<ApplicationUser>(
                      dataProtectionProvider.Create("ASP.NET Identity"));
                }
            }
        }
    }
}
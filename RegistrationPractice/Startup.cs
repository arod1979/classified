using Microsoft.Owin;
using Owin;
using System.Web.Services.Description;
using Microsoft.AspNet.Session;

[assembly: OwinStartupAttribute(typeof(RegistrationPractice.Startup))]
namespace RegistrationPractice
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        // Use this method to add services to the container.
        public void ConfigureServices(ServiceCollection services)
        {
            //services..AddCaching(); // Adds a default in-memory implementation of IDistributedCache
            //services.AddSession();
        }

    }
}

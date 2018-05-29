using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RegistrationPractice.Startup))]
namespace RegistrationPractice
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

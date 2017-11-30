using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RecuirementAgency.Startup))]
namespace RecuirementAgency
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

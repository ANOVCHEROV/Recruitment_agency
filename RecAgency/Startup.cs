using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RecAgency.Startup))]
namespace RecAgency
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

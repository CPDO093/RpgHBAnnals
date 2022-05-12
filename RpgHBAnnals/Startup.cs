using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RpgHBAnnals.Startup))]
namespace RpgHBAnnals
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

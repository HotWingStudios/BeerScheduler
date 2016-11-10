using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BeerScheduler.Startup))]
namespace BeerScheduler
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

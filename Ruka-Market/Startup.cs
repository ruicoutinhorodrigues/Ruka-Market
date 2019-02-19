using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ruka_Market.Startup))]
namespace Ruka_Market
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ODASApp.Startup))]
namespace ODASApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Guidant.Demo.Portal.Startup))]
namespace Guidant.Demo.Portal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

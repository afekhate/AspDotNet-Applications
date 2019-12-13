using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CenturyCars.Startup))]
namespace CenturyCars
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

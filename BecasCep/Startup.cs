using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BecasCep.Startup))]
namespace BecasCep
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

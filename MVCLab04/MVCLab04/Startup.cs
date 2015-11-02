using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCLab04.Startup))]
namespace MVCLab04
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

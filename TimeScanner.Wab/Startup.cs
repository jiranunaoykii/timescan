using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TimeScanner.Wab.Startup))]
namespace TimeScanner.Wab
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

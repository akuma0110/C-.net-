using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(lolproject.Startup))]
namespace lolproject
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

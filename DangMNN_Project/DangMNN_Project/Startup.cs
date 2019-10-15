using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DangMNN_Project.Startup))]
namespace DangMNN_Project
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

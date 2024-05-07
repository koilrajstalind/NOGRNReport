using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(inventory.Startup))]
namespace inventory
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

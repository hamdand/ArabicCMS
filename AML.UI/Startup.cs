using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AML.UI.Startup))]
namespace AML.UI
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

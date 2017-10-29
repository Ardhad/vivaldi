using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vivaldi.Web.Startup))]
namespace Vivaldi.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

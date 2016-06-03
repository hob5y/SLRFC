using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SLRFC.PlayerManager.Startup))]
namespace SLRFC.PlayerManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FewMainDiamond.Platform.Startup))]
namespace FewMainDiamond.Platform
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

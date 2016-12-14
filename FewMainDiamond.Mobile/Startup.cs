using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FewMainDiamond.Mobile.Startup))]
namespace FewMainDiamond.Mobile
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

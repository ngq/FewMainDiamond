using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FewMainDiamond.Startup))]
namespace FewMainDiamond
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

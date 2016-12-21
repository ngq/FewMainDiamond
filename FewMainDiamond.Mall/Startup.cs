using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FewMainDiamond.Mall.Startup))]
namespace FewMainDiamond.Mall
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

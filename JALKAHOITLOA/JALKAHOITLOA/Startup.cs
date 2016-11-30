using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JALKAHOITLOA.Startup))]
namespace JALKAHOITLOA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SmartCondominium.Startup))]
namespace SmartCondominium
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

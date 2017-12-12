using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ta5.Startup))]
namespace Ta5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

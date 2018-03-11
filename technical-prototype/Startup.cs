using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(technical_prototype.Startup))]
namespace technical_prototype
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

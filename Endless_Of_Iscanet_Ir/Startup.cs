using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Endless_Of_Iscanet_Ir.Startup))]
namespace Endless_Of_Iscanet_Ir
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

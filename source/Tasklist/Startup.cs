using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tasklist.Startup))]
namespace Tasklist
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

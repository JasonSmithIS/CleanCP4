using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlowOut2.Startup))]
namespace BlowOut2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

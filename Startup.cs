using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JuliaBlogv1.Startup))]
namespace JuliaBlogv1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

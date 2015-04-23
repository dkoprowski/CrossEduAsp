using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CrossEduAsp.Startup))]
namespace CrossEduAsp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

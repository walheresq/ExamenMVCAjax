using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExamenMVCAjax.Startup))]
namespace ExamenMVCAjax
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

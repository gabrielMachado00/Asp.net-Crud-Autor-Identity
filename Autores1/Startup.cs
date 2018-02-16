using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Autores1.Startup))]
namespace Autores1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

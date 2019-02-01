using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Movies_App.Startup))]
namespace Movies_App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

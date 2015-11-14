using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(App.Data.Web.Startup))]
namespace App.Data.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

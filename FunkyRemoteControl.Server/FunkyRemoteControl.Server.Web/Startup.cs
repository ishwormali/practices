using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FunkyRemoteControl.Server.Web.Startup))]
namespace FunkyRemoteControl.Server.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}

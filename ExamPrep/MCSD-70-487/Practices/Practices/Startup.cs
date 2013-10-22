using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Practices.Startup))]
namespace Practices
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}

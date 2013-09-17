using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppSecurityDemo.Startup))]
namespace WebAppSecurityDemo
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}

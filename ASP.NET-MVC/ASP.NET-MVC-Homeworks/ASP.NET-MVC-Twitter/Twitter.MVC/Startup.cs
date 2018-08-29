using Microsoft.Owin;
using Owin;
using Twitter.MVC;

[assembly: OwinStartup(typeof (Startup))]

namespace Twitter.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}

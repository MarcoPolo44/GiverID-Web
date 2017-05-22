using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GiverID.Startup))]
namespace GiverID
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

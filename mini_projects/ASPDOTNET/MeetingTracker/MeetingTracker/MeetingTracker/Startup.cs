using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MeetingTracker.Startup))]
namespace MeetingTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

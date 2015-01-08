using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DrivingSchoolMVCApp.Startup))]
namespace DrivingSchoolMVCApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

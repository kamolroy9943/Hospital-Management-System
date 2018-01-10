using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HospitalManagement.Web.Startup))]
namespace HospitalManagement.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

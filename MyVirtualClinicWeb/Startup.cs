using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyVirtualClinicWeb.Startup))]
namespace MyVirtualClinicWeb
{
    public partial class Startup
    {

        public Startup() {
            System.Diagnostics.Debug.WriteLine("in Startup constructor");
        }

        public void Configuration(IAppBuilder app)
        {
            
            System.Diagnostics.Debug.WriteLine("in configutation");

            ConfigureAuth(app);
        }
    }
}

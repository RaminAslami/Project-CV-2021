using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Project_2022_CV.Startup))]
namespace Project_2022_CV
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

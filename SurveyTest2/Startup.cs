using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SurveyTest2.Startup))]
namespace SurveyTest2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;
using PhotoStore.App_Start;

[assembly: OwinStartupAttribute(typeof(PhotoStore.Startup))]
namespace PhotoStore
{
    public partial class Startup
    {

        public void Configuration(IAppBuilder app)
        {
			ConfigureAuth(app);
			AutoMapperBindings.Config();
		}

	}

}

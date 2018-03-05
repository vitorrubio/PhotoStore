using Microsoft.Owin;
using Owin;


[assembly: OwinStartupAttribute(typeof(PhotoStore.Startup))]
namespace PhotoStore
{
    public partial class Startup
    {

        public void Configuration(IAppBuilder app)
        {
			ConfigureAuth(app);
		}

	}

}

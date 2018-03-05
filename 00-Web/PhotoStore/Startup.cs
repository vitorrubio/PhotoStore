using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
using System.Web.Security;
using PhotoStore.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using System.Web.Mvc;
using System.Collections.Generic;
using PhotoStore.Infra.DbContext;
using PhotoStore.Infra.Services;
using PhotoStore.Core.Interfaces.Repositories;
using PhotoStore.Infra.Repository;
using PhotoStore.Core.Interfaces.Services;
using PhotoStore.Core.Services;
using PhotoStore.ApplicationServices.Interfaces;
using PhotoStore.ApplicationServices;

[assembly: OwinStartupAttribute(typeof(PhotoStore.Startup))]
namespace PhotoStore
{
    public partial class Startup
    {

        public void Configuration(IAppBuilder app)
        {
			//var services = new ServiceCollection();

			//o que estava originalmente
			ConfigureAuth(app);



			//ConfigureServices(services);
			//var resolver = new DefaultDependencyResolver(services.BuildServiceProvider());
			//DependencyResolver.SetResolver(resolver);
		}


		/// <summary>
		/// http://scottdorman.github.io/2016/03/17/integrating-asp.net-core-dependency-injection-in-mvc-4/
		/// </summary>
		/// <param name="services"></param>
		//public void ConfigureServices(IServiceCollection services)
		//{
		//	services.AddControllersAsServices(typeof(Startup).Assembly.GetExportedTypes()
		//	   .Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition)
		//	   .Where(t => typeof(IController).IsAssignableFrom(t)
		//		  || t.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase)));

		//	services.AddTransient<ApplicationDbContext, ApplicationDbContext>();

		//	services.AddTransient<IEventoRepository, EventoRepository>();
		//	services.AddTransient<IFotoRepository, FotoRepository>();
		//	services.AddTransient<IPedidoRepository, PedidoRepository>();
		//	services.AddTransient<IProdutoRepository, ProdutoRepository>();
		//	services.AddTransient<ITipoProdutoRepository, TipoProdutoRepository>();


		//	services.AddTransient<IEventoService, EventoService>();
		//	services.AddTransient<IFotoService, FotoService>();
		//	services.AddTransient<IPedidoService, PedidoService>();
		//	services.AddTransient<IProdutoService, ProdutoService>();
		//	services.AddTransient<ITipoProdutoService, TipoProdutoService>();


		//	services.AddTransient<IEventoApplicationService, EventoApplicationService>();
		//	services.AddTransient<IFotoApplicationService, FotoApplicationService>();
		//	services.AddTransient<IPedidoApplicationService, PedidoApplicationService>();
		//	services.AddTransient<IProdutoApplicationService, ProdutoApplicationService>();
		//	services.AddTransient<ITipoProdutoApplicationService, TipoProdutoApplicationService>();

		//	services.AddTransient<ApplicationUserManager, ApplicationUserManager>();
		//	services.AddTransient<ApplicationSignInManager, ApplicationSignInManager>();
		//	services.AddTransient<ApplicationRoleManager, ApplicationRoleManager>();

		//}
	}


	//public class DefaultDependencyResolver : System.Web.Mvc.IDependencyResolver
	//{
	//	protected IServiceProvider serviceProvider;

	//	public DefaultDependencyResolver(IServiceProvider serviceProvider)
	//	{
	//		this.serviceProvider = serviceProvider;


	//	}

	//	public object GetService(Type serviceType)
	//	{
	//		return this.serviceProvider.GetService(serviceType);
	//	}

	//	public IEnumerable<object> GetServices(Type serviceType)
	//	{
	//		return this.serviceProvider.GetServices(serviceType);
	//	}

	//}


	//public static class ServiceProviderExtensions
	//{
	//	public static IServiceCollection AddControllersAsServices(this IServiceCollection services, IEnumerable<Type> controllerTypes)		  
	//	{
			
	//		foreach (var type in controllerTypes)
	//		{
	//			services.AddTransient(type);
	//		}

	//		return services;
	//	}
	//}
}

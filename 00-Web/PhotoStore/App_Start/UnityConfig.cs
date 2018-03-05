using PhotoStore.ApplicationServices;
using PhotoStore.ApplicationServices.Interfaces;
using PhotoStore.Core.Interfaces.Repositories;
using PhotoStore.Core.Interfaces.Services;
using PhotoStore.Core.Services;
using PhotoStore.Infra.DbContext;
using PhotoStore.Infra.Repository;
using PhotoStore.Infra.Services;
using System;

using Unity;
using Unity.AspNet.Mvc;

namespace PhotoStore
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
			// NOTE: To load from web.config uncomment the line below.
			// Make sure to add a Unity.Configuration to the using statements.
			// container.LoadConfiguration();

			// TODO: Register your type's mappings here.
			// container.RegisterType<IProductRepository, ProductRepository>();

			container.RegisterType<ApplicationDbContext, ApplicationDbContext>(new PerRequestLifetimeManager());

			container.RegisterType<IEventoRepository, EventoRepository>();
			container.RegisterType<IFotoRepository, FotoRepository>();
			container.RegisterType<IPedidoRepository, PedidoRepository>();
			container.RegisterType<IProdutoRepository, ProdutoRepository>();
			container.RegisterType<ITipoProdutoRepository, TipoProdutoRepository>();


			container.RegisterType<IEventoService, EventoService>();
			container.RegisterType<IFotoService, FotoService>();
			container.RegisterType<IPedidoService, PedidoService>();
			container.RegisterType<IProdutoService, ProdutoService>();
			container.RegisterType<ITipoProdutoService, TipoProdutoService>();


			container.RegisterType<IEventoApplicationService, EventoApplicationService>();
			container.RegisterType<IFotoApplicationService, FotoApplicationService>();
			container.RegisterType<IPedidoApplicationService, PedidoApplicationService>();
			container.RegisterType<IProdutoApplicationService, ProdutoApplicationService>();
			container.RegisterType<ITipoProdutoApplicationService, TipoProdutoApplicationService>();

			container.RegisterType<ApplicationUserManager, ApplicationUserManager>();
			container.RegisterType<ApplicationSignInManager, ApplicationSignInManager>();
			container.RegisterType<ApplicationRoleManager, ApplicationRoleManager>();
		}
	}
}
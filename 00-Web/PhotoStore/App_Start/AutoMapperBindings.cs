using PhotoStore.Core.Model;
using PhotoStore.ViewModel;

namespace PhotoStore.App_Start
{

	public static class AutoMapperBindings
	{
		private static bool _inicializado = false;


		static AutoMapperBindings()
		{
			AutoMapperBindings.Config();
		}


		public static void Config()
		{

			if (!AutoMapperBindings._inicializado)
			{

				AutoMapper.Mapper.Initialize(cfg =>
				{
					DomainToDomain(cfg);

					DomainToViewModel(cfg);

					ViewModelToDomain(cfg);

				});



				AutoMapperBindings._inicializado = true;

			}
		}

		private static void ViewModelToDomain(AutoMapper.IMapperConfigurationExpression cfg)
		{
			cfg.CreateMap<EventoViewModel, Evento>();
			cfg.CreateMap<ProdutoViewModel, Produto>();
			cfg.CreateMap<TipoProdutoViewModel, TipoProduto>();
			cfg.CreateMap<FotoViewModel, Foto>();
			cfg.CreateMap<UploadFotoViewModel, Foto>();
			cfg.CreateMap<PedidoViewModel, Pedido>();
			cfg.CreateMap<ItemDoPedidoViewModel, ItemDoPedido>();
			cfg.CreateMap<ApplicationUserViewModel, ApplicationUser>();

			cfg.CreateMap<ArquivoFotoViewModel, ArquivoFoto>();
			cfg.CreateMap<ArquivoCapaViewModel, ArquivoCapa>();
		}

		private static void DomainToViewModel(AutoMapper.IMapperConfigurationExpression cfg)
		{
			cfg.CreateMap<Evento, EventoViewModel>();
			cfg.CreateMap<Produto, ProdutoViewModel>();
			cfg.CreateMap<TipoProduto, TipoProdutoViewModel>();
			cfg.CreateMap<Foto, FotoViewModel>();
			cfg.CreateMap<Foto, UploadFotoViewModel>();
			cfg.CreateMap<Pedido, PedidoViewModel>();
			cfg.CreateMap<ItemDoPedido, ItemDoPedidoViewModel>();
			cfg.CreateMap<ApplicationUser, ApplicationUserViewModel>();

			cfg.CreateMap<ArquivoFoto, ArquivoFotoViewModel>();
			cfg.CreateMap<ArquivoCapa, ArquivoCapaViewModel>();
		}

		private static void DomainToDomain(AutoMapper.IMapperConfigurationExpression cfg)
		{
			cfg.CreateMap<Evento, Evento>();
			cfg.CreateMap<Produto, Produto>();
			cfg.CreateMap<TipoProduto, TipoProduto>();
			cfg.CreateMap<Foto, Foto>();
			cfg.CreateMap<Pedido, Pedido>();
			cfg.CreateMap<ItemDoPedido, ItemDoPedido>();
			cfg.CreateMap<ArquivoFoto, ArquivoFoto>();
			cfg.CreateMap<ArquivoCapa, ArquivoCapa>();
		}
	}
}
using PhotoStore.Core.Model;
using PhotoStore.ViewModel;

namespace PhotoStore.App_Start
{

	public static class AutoMapperBindings
	{
		public static void Config()
		{

			AutoMapper.Mapper.Initialize(cfg =>
			{
				DomainToDomain(cfg);

				DomainToViewModel(cfg);

				ViewModelToDomain(cfg);

			});
		}

		private static void ViewModelToDomain(AutoMapper.IMapperConfigurationExpression cfg)
		{
			cfg.CreateMap<EventoViewModel, Evento>()
				.ForMember(x => x.Fotos, member => {
					member.MapFrom(src => src.Fotos);
					member.UseDestinationValue();
				})
				.PreserveReferences();
			cfg.CreateMap<ProdutoViewModel, Produto>()
				.PreserveReferences();
			cfg.CreateMap<TipoProdutoViewModel, TipoProduto>()
				.PreserveReferences();
			cfg.CreateMap<FotoViewModel, Foto>()
				.PreserveReferences();
			cfg.CreateMap<UploadFotoViewModel, Foto>()
				.PreserveReferences();
			cfg.CreateMap<PedidoViewModel, Pedido>()
				.PreserveReferences();
			cfg.CreateMap<ItemDoPedidoViewModel, ItemDoPedido>()
				.PreserveReferences();
			cfg.CreateMap<ApplicationUserViewModel, ApplicationUser>()
				.PreserveReferences();

			cfg.CreateMap<ArquivoFotoViewModel, ArquivoFoto>()
				.PreserveReferences();
			cfg.CreateMap<ArquivoCapaViewModel, ArquivoCapa>()
				.PreserveReferences();
		}

		private static void DomainToViewModel(AutoMapper.IMapperConfigurationExpression cfg)
		{
			cfg.CreateMap<Evento, EventoViewModel>()
				.ForMember(x => x.Fotos, member => {
					member.MapFrom(src => src.Fotos);
					member.UseDestinationValue();
				})
				.PreserveReferences();
			cfg.CreateMap<Produto, ProdutoViewModel>()
				.PreserveReferences();
			cfg.CreateMap<TipoProduto, TipoProdutoViewModel>()
				.PreserveReferences();
			cfg.CreateMap<Foto, FotoViewModel>()
				.PreserveReferences();
			cfg.CreateMap<Foto, UploadFotoViewModel>()
				.PreserveReferences();
			cfg.CreateMap<Pedido, PedidoViewModel>()
				.PreserveReferences();
			cfg.CreateMap<ItemDoPedido, ItemDoPedidoViewModel>()
				.PreserveReferences();
			cfg.CreateMap<ApplicationUser, ApplicationUserViewModel>()
				.PreserveReferences();

			cfg.CreateMap<ArquivoFoto, ArquivoFotoViewModel>()
				.PreserveReferences();
			cfg.CreateMap<ArquivoCapa, ArquivoCapaViewModel>()
				.PreserveReferences();
		}

		private static void DomainToDomain(AutoMapper.IMapperConfigurationExpression cfg)
		{
			cfg.CreateMap<Evento, Evento>()
			.PreserveReferences();
			cfg.CreateMap<Produto, Produto>()
				.PreserveReferences();
			cfg.CreateMap<TipoProduto, TipoProduto>()
				.PreserveReferences();
			cfg.CreateMap<Foto, Foto>()
				.PreserveReferences();
			cfg.CreateMap<Pedido, Pedido>()
				.PreserveReferences();
			cfg.CreateMap<ItemDoPedido, ItemDoPedido>()
				.PreserveReferences();
			cfg.CreateMap<ArquivoFoto, ArquivoFoto>()
				.PreserveReferences();
			cfg.CreateMap<ArquivoCapa, ArquivoCapa>()
				.PreserveReferences();
		}
	}
}
using PhotoStore.Core.Model;


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

					cfg.CreateMap<Evento, Evento>();
					cfg.CreateMap<Produto, Produto>();
					cfg.CreateMap<TipoProduto, TipoProduto>();
					cfg.CreateMap<Foto, Foto>();
					cfg.CreateMap<Pedido, Pedido>();
					cfg.CreateMap<ItemDoPedido, ItemDoPedido>();


				});



				AutoMapperBindings._inicializado = true;

			}
		}
	}
}
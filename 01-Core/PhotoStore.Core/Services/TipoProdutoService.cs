using PhotoStore.Core.Interfaces.Repositories;
using PhotoStore.Core.Interfaces.Services;
using PhotoStore.Core.Model;


namespace PhotoStore.Core.Services
{
	public class TipoProdutoService : GenericService<TipoProduto>, ITipoProdutoService
	{
		private readonly ITipoProdutoRepository _tipoProdutoRepository;

		public TipoProdutoService(ITipoProdutoRepository rep)
			: base(rep)
		{
			_tipoProdutoRepository = rep;
		}
	
	}
}

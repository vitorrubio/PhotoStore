using PhotoStore.Core.Interfaces.Repositories;
using PhotoStore.Core.Interfaces.Services;
using PhotoStore.Core.Model;


namespace PhotoStore.Core.Services
{
	public class ProdutoService : GenericService<Produto>, IProdutoService
	{
		private readonly IProdutoRepository _produtoRepository;

		public ProdutoService(IProdutoRepository rep)
			: base(rep)
		{
			_produtoRepository = rep;
		}
	
	}
}

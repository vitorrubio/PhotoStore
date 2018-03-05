using PhotoStore.Core.Interfaces.Repositories;
using PhotoStore.Core.Model;
using PhotoStore.Infra.DbContext;


namespace PhotoStore.Infra.Repository
{
	public class TipoProdutoRepository : GenericRepository<TipoProduto>, ITipoProdutoRepository
	{
		public TipoProdutoRepository(ApplicationDbContext ctx) : base(ctx)
		{

		}
	}
}

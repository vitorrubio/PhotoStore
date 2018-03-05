using PhotoStore.Core.Interfaces.Repositories;
using PhotoStore.Core.Model;
using PhotoStore.Infra.DbContext;


namespace PhotoStore.Infra.Repository
{
	public class ProdutoRepository : GenericRepository<Produto>, IProdutoRepository
	{
		public ProdutoRepository(ApplicationDbContext ctx) : base(ctx)
		{

		}
	}
}

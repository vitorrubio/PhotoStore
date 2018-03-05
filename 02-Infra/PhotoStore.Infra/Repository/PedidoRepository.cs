using PhotoStore.Core.Interfaces.Repositories;
using PhotoStore.Core.Model;
using PhotoStore.Infra.DbContext;


namespace PhotoStore.Infra.Repository
{
	public class PedidoRepository : GenericRepository<Pedido>, IPedidoRepository
	{
		public PedidoRepository(ApplicationDbContext ctx) : base(ctx)
		{

		}
	}
}

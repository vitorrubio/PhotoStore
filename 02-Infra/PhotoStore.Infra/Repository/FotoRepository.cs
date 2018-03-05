using PhotoStore.Core.Interfaces.Repositories;
using PhotoStore.Core.Model;
using PhotoStore.Infra.DbContext;


namespace PhotoStore.Infra.Repository
{
	public class FotoRepository : GenericRepository<Foto>, IFotoRepository
	{
		public FotoRepository(ApplicationDbContext ctx) : base(ctx)
		{

		}
	}
}

using PhotoStore.Core.Interfaces.Repositories;
using PhotoStore.Core.Model;
using PhotoStore.Infra.DbContext;


namespace PhotoStore.Infra.Repository
{
	public class EventoRepository : GenericRepository<Evento>, IEventoRepository
	{
		public EventoRepository(ApplicationDbContext ctx) : base(ctx)
		{

		}
	}
}

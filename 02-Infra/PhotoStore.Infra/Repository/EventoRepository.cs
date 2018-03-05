using PhotoStore.Core.Interfaces.Repositories;
using PhotoStore.Core.Model;
using PhotoStore.Infra.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStore.Infra.Repository
{
	public class EventoRepository : GenericRepository<Evento>, IEventoRepository
	{
		public EventoRepository(ApplicationDbContext ctx) : base(ctx)
		{

		}
	}
}

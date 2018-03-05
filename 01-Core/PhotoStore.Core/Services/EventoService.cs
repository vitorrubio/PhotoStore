using PhotoStore.Core.Interfaces.Repositories;
using PhotoStore.Core.Interfaces.Services;
using PhotoStore.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStore.Core.Services
{
	public class EventoService : GenericService<Evento>, IEventoService
	{
		private readonly IEventoRepository _eventoRepository;

		public EventoService(IEventoRepository rep)
			: base(rep)
		{
			_eventoRepository = rep;
		}
	}
}

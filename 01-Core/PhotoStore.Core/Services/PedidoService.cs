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
	public class PedidoService : GenericService<Pedido>, IPedidoService
	{
		private readonly IPedidoRepository _pedidoRepository;

		public PedidoService(IPedidoRepository rep)
			: base(rep)
		{
			_pedidoRepository = rep;
		}
	
	}
}

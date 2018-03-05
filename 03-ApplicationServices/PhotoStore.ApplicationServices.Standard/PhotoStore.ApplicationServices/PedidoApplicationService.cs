using PhotoStore.ApplicationServices.Interfaces;
using PhotoStore.Core.Interfaces.Services;
using PhotoStore.Core.Model;
using PhotoStore.Infra.DbContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoStore.ApplicationServices
{
    public class PedidoApplicationService :  GenericApplicationService<Pedido>, IPedidoApplicationService
	{
		public PedidoApplicationService(IPedidoService svc) : base(svc)
		{

		}
	}
}

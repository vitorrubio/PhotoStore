using PhotoStore.ApplicationServices.Interfaces;
using PhotoStore.Core.Interfaces.Services;
using PhotoStore.Core.Model;


namespace PhotoStore.ApplicationServices
{
    public class PedidoApplicationService :  GenericApplicationService<Pedido>, IPedidoApplicationService
	{
		public PedidoApplicationService(IPedidoService svc) : base(svc)
		{

		}
	}
}

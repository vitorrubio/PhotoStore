using PhotoStore.ApplicationServices.Interfaces;
using PhotoStore.Core.Interfaces.Services;
using PhotoStore.Core.Model;


namespace PhotoStore.ApplicationServices
{
    public class ProdutoApplicationService :  GenericApplicationService<Produto>, IProdutoApplicationService
	{
		public ProdutoApplicationService(IProdutoService svc) : base(svc)
		{

		}
	}
}

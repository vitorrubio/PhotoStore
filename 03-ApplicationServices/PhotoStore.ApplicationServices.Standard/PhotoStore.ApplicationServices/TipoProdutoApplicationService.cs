using PhotoStore.ApplicationServices.Interfaces;
using PhotoStore.Core.Interfaces.Services;
using PhotoStore.Core.Model;


namespace PhotoStore.ApplicationServices
{
    public class TipoProdutoApplicationService :  GenericApplicationService<TipoProduto>, ITipoProdutoApplicationService
	{
		public TipoProdutoApplicationService(ITipoProdutoService svc) : base(svc)
		{

		}
	}
}

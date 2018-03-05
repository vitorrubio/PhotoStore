using PhotoStore.ApplicationServices.Interfaces;
using PhotoStore.Core.Interfaces.Services;
using PhotoStore.Core.Model;
using PhotoStore.Infra.DbContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoStore.ApplicationServices
{
    public class ProdutoApplicationService :  GenericApplicationService<Produto>, IProdutoApplicationService
	{
		public ProdutoApplicationService(IProdutoService svc) : base(svc)
		{

		}
	}
}

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
	public class TipoProdutoService : GenericService<TipoProduto>, ITipoProdutoService
	{
		private readonly ITipoProdutoRepository _tipoProdutoRepository;

		public TipoProdutoService(ITipoProdutoRepository rep)
			: base(rep)
		{
			_tipoProdutoRepository = rep;
		}
	
	}
}

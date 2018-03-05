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
	public class ProdutoRepository : GenericRepository<Produto>, IProdutoRepository
	{
		public ProdutoRepository(ApplicationDbContext ctx) : base(ctx)
		{

		}
	}
}

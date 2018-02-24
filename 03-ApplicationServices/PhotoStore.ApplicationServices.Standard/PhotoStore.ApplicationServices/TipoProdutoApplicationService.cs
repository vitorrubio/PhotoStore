using PhotoStore.Core.Model;
using PhotoStore.Infra.DbContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoStore.ApplicationServices
{
    public class TipoProdutoApplicationService : GenericApplicationService<TipoProduto>
    {
        public TipoProdutoApplicationService(ApplicationDbContext ctx):base(ctx)
        {

        }
    }
}

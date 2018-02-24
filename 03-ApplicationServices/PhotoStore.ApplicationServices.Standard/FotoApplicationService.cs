using PhotoStore.Core.Model;
using PhotoStore.Infra.DbContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoVendor.ApplicationServices
{
    public class FotoApplicationService : GenericApplicationService<Foto>
    {
        public FotoApplicationService(ApplicationDbContext ctx) : base(ctx)
        {

        }
    }
}

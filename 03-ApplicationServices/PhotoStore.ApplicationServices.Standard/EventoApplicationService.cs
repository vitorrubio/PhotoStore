﻿using PhotoStore.Core.Model;
using PhotoStore.Infra.DbContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoVendor.ApplicationServices
{
    public class EventoApplicationService : GenericApplicationService<Evento>
    {
        public EventoApplicationService(ApplicationDbContext ctx) : base(ctx)
        {

        }
    }
}

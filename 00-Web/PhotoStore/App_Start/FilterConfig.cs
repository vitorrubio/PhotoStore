﻿
using PhotoStore.Infra.Services;
using System.Web;
using System.Web.Mvc;

namespace PhotoStore
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new PhotoStoreAuthorizeAttribute());
        }
    }
}

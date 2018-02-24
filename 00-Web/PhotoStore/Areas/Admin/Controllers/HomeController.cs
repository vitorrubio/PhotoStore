using PhotoStore.Controllers;
using PhotoStore.Infra.DbContext;
using PhotoStore.Infra.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoStore.Areas.Admin.Controllers
{
    [PhotoStoreAuthorize(Roles = "Administrator")]
    [RouteArea("Admin")]
    public class HomeController : BaseController
    {
		public HomeController(ApplicationDbContext ctx) : base(ctx)
		{

		}

		public ActionResult Index()
        {
            return View();
        }
    }
}
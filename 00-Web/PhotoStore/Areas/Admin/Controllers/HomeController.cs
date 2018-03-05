using PhotoStore.Controllers;
using PhotoStore.Infra.Services;
using System.Web.Mvc;

namespace PhotoStore.Areas.Admin.Controllers
{
    [PhotoStoreAuthorize(Roles = "Administrator")]
    [RouteArea("Admin")]
    public class HomeController : BaseController
    {

		public ActionResult Index()
        {
            return View();
        }
    }
}
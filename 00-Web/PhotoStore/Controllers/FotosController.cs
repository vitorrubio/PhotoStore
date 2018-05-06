using PhotoStore.ApplicationServices.Interfaces;
using PhotoStore.Infra.DbContext;
using PhotoStore.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace PhotoStore.Controllers
{
    public class FotosController : BaseController
    {
		private IFotoApplicationService _fotoApp;

		public FotosController(IFotoApplicationService fotoSvc)
		{
			_fotoApp = fotoSvc;
		}


		public ActionResult Index()
        {
            return View();
        }


		[HttpPost]
		public JsonResult UploadFoto(UploadFotoViewModel vm)
		{
			try
			{
				return Json(new
				{
					Sucesso = true,
					Mensagem = "",
					IdFoto = 0
				});
			}
			catch(Exception err)
			{
				return Json(new
				{
					Sucesso = false,
					Mensagem = err.Message,
					IdFoto = 0
				});
			}
		}


		[OutputCache(Duration = 3600, VaryByParam = "id", Location = OutputCacheLocation.ServerAndClient)]
		public ActionResult Foto(int id)
		{
			var dir = Server.MapPath("~/Content/Images/thumbnails/");
			var path = Path.Combine(dir, string.Format("{0}.thumb.jpg", id));

			if (System.IO.File.Exists(path))
			{
				return File(path, "image/jpeg");
			}
			else
			{
				return File(Server.MapPath("~/Content/Images/thumbnails/0.thumb.jpg"), "image/jpeg");
			}
		}


	}
}

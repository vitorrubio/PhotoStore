using PhotoStore.Infra.DbContext;
using PhotoStore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoStore.Controllers
{
    public class FotosController : BaseController
    {

		public FotosController() 
		{

		}

		// GET: Fotos
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
	}
}

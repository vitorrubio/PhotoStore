using PhotoStore.Infra.DbContext;
using PhotoStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoStore.Controllers
{
    public class FotosController : BaseController
    {

		public FotosController(ApplicationDbContext ctx) : base(ctx)
		{

		}

		// GET: Fotos
		public ActionResult Index()
        {
            return View();
        }



        //public JsonResult UploadFoto(UploadFotoViewModel vm)
        //{
            
        //}



    }
}

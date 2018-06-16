using PhotoStore.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace PhotoStore.Controllers
{
    public class EventosController : Controller
    {


		private IEventoApplicationService _eventoApp;
		private IFotoApplicationService _fotoApp;

		public EventosController(IFotoApplicationService fotoSvc, IEventoApplicationService evtSvc)
		{
			_eventoApp = evtSvc;
			_fotoApp = fotoSvc;
		}

		public ActionResult Index(int id)
		{
			var evento = _eventoApp.GetById(id);
			if (evento == null)
			{
				//return new HttpNotFoundResult("Evento não encontrado");
				return RedirectToAction("Index", "Home");
			}

			return View(evento);

		}

		[OutputCache(Duration = 3600, VaryByParam = "id", Location = OutputCacheLocation.ServerAndClient)]
		public ActionResult CapaDoEvento(int id)
		{
			int idThumb = 0;
			var evento = _eventoApp.GetById(id);
			if(evento != null)
			{
				if(evento.ArquivoCapa != null && evento.ArquivoCapa.Bytes.Length > 0)
				{
					return File(evento.ArquivoCapa.Bytes, "image/jpeg");
				}
				else
				{
					var primeiraFoto =
						evento.Fotos.Where(x => x.CapaDeEvento).FirstOrDefault() ?? //primeira capa de evento
						evento.Fotos.Where(x => x.Vitrine).FirstOrDefault() ?? //primeira foto de vitrine
						evento.Fotos.FirstOrDefault(); //primeira qualquer

					idThumb = primeiraFoto?.Id??0;

				}
			}

			var dir = Server.MapPath("~/Content/Images/thumbnails/");
			var path = Path.Combine(dir, string.Format("{0}.cover.jpg", idThumb));

			if (System.IO.File.Exists(path))
			{
				return File(path, "image/jpeg");
			}
			else
			{
				path = Path.Combine(dir, string.Format("{0}.thumb.jpg", idThumb));
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
}
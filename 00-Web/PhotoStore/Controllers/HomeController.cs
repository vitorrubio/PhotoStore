using AutoMapper;
using PhotoStore.ApplicationServices.Interfaces;
using PhotoStore.Core.Model;
using PhotoStore.Infra.Services;
using PhotoStore.ViewModel;
using PhotoStore.ViewModel.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace PhotoStore.Controllers
{
	[PhotoStoreAuthorize(Roles = "Administrator")]
	public class HomeController : Controller
    {
		private IEventoApplicationService _eventoApp;
		private IFotoApplicationService _fotoApp;

		public HomeController(IFotoApplicationService fotoSvc, IEventoApplicationService evtSvc)
		{
			_eventoApp = evtSvc;
			_fotoApp = fotoSvc;
		}

		public ActionResult Index()
		{
			var qryRecentes = _eventoApp.GetAllDetached(x => x.Fotos)
				.OrderByDescending(x => x.Inicio)
				.Take(4)
				.ToList();

			var idsNovos = qryRecentes.Select(r => r.Id).ToList();

			var qryAntigos = _eventoApp.GetAllDetached(x => x.Fotos)
				.Where(x => x.Vitrine && !idsNovos.Contains(x.Id))
				.ToList();

			var eventosRecentes = Mapper.Map<List<Evento>, List<EventoViewModel>>(qryRecentes);
			var eventosAntigos = Mapper.Map<List<Evento>, List<EventoViewModel>>(qryAntigos);

			return View(new HomeIndexViewModel
			{
				EventosMaisRecentes = eventosRecentes,
				EventosMaisAntigos = eventosAntigos
			});
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Index(HomeIndexViewModel vm)
		{
			var qry = _fotoApp.GetAllDetached(x => x.Evento);

			if (!string.IsNullOrWhiteSpace(vm.Evento))
				qry = qry.Where(x => x.Evento.Nome.Contains(vm.Evento));

			if (!string.IsNullOrWhiteSpace(vm.Nome))
				qry = qry.Where(x => x.Nome.Contains(vm.Nome));

			if (!string.IsNullOrWhiteSpace(vm.Numero))
				qry = qry.Where(x => x.Numero.Contains(vm.Numero));

			var fotos = Mapper.Map<List<Foto>, List<FotoViewModel>>(await qry.ToListAsync());

			vm.Fotos = fotos;

			return View(vm);
		}


	}
}
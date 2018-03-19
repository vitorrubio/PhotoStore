using PhotoStore.ApplicationServices.Interfaces;
using PhotoStore.Infra.Services;
using PhotoStore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PhotoStore.Core.Model;
using System.Data.Entity.Infrastructure;
using AutoMapper;
using PhotoStore.ViewModel.Admin.FotoAdmin;
using PhotoStore.Controllers;

namespace PhotoStore.Areas.Admin.Controllers
{
	[PhotoStoreAuthorize(Roles = "Administrator")]
	[RouteArea("Admin")]
	public class FotoAdminController : BaseController
	{

		private IFotoApplicationService _appSvc;
		private IEventoApplicationService _evtSvc;

		public FotoAdminController(IFotoApplicationService appSvc, IEventoApplicationService evtSvc)
		{
			_appSvc = appSvc;
			_evtSvc = evtSvc;
		}

		public ActionResult Index()
		{
			return View(new FotoAdminIndexViewModel());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Index(FotoAdminIndexViewModel vm)
		{
			var qry = _appSvc.GetAll(x => x.Evento);

			if (!string.IsNullOrWhiteSpace(vm.Evento))
				qry = qry.Where(x => x.Evento.Nome.Contains(vm.Evento));

			if (!string.IsNullOrWhiteSpace(vm.Nome))
				qry = qry.Where(x => x.Nome.Contains(vm.Nome));

			if (!string.IsNullOrWhiteSpace(vm.Evento))
				qry = qry.Where(x => x.Numero.Contains(vm.Numero));

			var fotos = Mapper.Map<List<Foto>, List<FotoViewModel>>(await _appSvc.GetAll(x => x.Evento).ToListAsync());

			vm.Fotos = fotos;

			return View(vm);
		}


		public async Task<ActionResult> Editar(int? id)
		{
			if ((id == null) || (id == 0))
			{
				return View(new Foto());
			}

			try
			{
				Foto ft = await _appSvc.GetByIdAsync(id.Value);

				if (ft != null)
				{
					return View(ft);
				}
				else
				{
					MensagemParaUsuarioViewModel.MensagemErro("Esse registro não pôde ser encontrado. ", TempData, ModelState);
				}
			}
			catch (Exception err)
			{
				MensagemParaUsuarioViewModel.MensagemErro("Esse registro não pôde ser visualizado. " + err.Message, TempData, ModelState);
			}

			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Editar(FotoViewModel fotoVm)
		{
			PopulaEventos(fotoVm?.IdEvento);
			if (ModelState.IsValid)
			{
				try
				{
					Foto foto = await _appSvc.GetByIdAsync(fotoVm.Id) ?? new Foto();
					Mapper.Map(fotoVm, foto);
					await _appSvc.SaveAsync(foto);

					MensagemParaUsuarioViewModel.MensagemSucesso("Registro Salvo.", TempData);
					return View(fotoVm);
				}
				catch (DbUpdateConcurrencyException duce)
				{
					MensagemParaUsuarioViewModel.MensagemErro(" Talvez esse registro tenha sido excluído por outra pessoa. " + duce.Message, TempData, ModelState);
				}
				catch (Exception err)
				{
					MensagemParaUsuarioViewModel.MensagemErro("Esse registro não pôde ser salvo. " + err.Message, TempData, ModelState);
				}
			}
			return View(fotoVm);
		}



		public async Task<ActionResult> Detalhes(int id)
		{
			if (id == 0)
			{
				MensagemParaUsuarioViewModel.MensagemErro("Foto não encontrada. ", TempData, ModelState);
				RedirectToAction("Index");
			}

			try
			{
				Foto ft = await _appSvc.GetByIdAsync(id);

				if (ft != null)
				{
					FotoViewModel ftvm = Mapper.Map<FotoViewModel>(ft);
					return View(ftvm);
				}
				else
				{
					MensagemParaUsuarioViewModel.MensagemErro("Esse registro não pôde ser encontrado. ", TempData, ModelState);
				}
			}
			catch (Exception err)
			{
				MensagemParaUsuarioViewModel.MensagemErro("Esse registro não pôde ser visualizado. " + err.Message, TempData, ModelState);
			}

			return View();
		}

		public async Task<ActionResult> Delete(int? id)
		{
			if (id == null)
			{
				MensagemParaUsuarioViewModel.MensagemErro("Não foi especificado um item para excluir", TempData, ModelState);
				return RedirectToAction("index");
			}

			try
			{
				Foto ft = await _appSvc.GetByIdAsync(id.Value);
				if (ft == null)
				{
					MensagemParaUsuarioViewModel.MensagemErro("O item não foi encontrado", TempData, ModelState);
					return RedirectToAction("index");
				}
				FotoViewModel ftvm = Mapper.Map<FotoViewModel>(ft);
				return View(ftvm);
			}
			catch (Exception err)
			{
				MensagemParaUsuarioViewModel.MensagemErro(err.Message, TempData, ModelState);
				return RedirectToAction("index");
			}
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> DeleteConfirmed(int id)
		{
			Foto ft = await _appSvc.GetByIdAsync(id);
			if (ft != null)
			{
				try
				{

					await _appSvc.DeleteAsync(id);
					MensagemParaUsuarioViewModel.MensagemSucesso("Registro Excluido.", TempData);
					return RedirectToAction("Index");
				}
				catch (DbUpdateConcurrencyException duce)
				{
					MensagemParaUsuarioViewModel.MensagemErro(" Talvez esse registro tenha sido excluído por outra pessoa. " + duce.Message, TempData, ModelState);
				}
				catch (Exception err)
				{
					MensagemParaUsuarioViewModel.MensagemErro("Esse registro não pôde ser excluído. " + err.Message, TempData, ModelState);
				}

			}
			else
			{
				MensagemParaUsuarioViewModel.MensagemErro("Registro não encontrado.", TempData, ModelState);
			}

			return View(ft);
		}


		public virtual ActionResult Upload()
		{
			PopulaEventos();
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual ActionResult Upload(UploadFotoViewModel fotoVm)
		{
			PopulaEventos(fotoVm.IdEvento);
			if (ModelState.IsValid)
			{
				try
				{
					var currentUsername = !string.IsNullOrWhiteSpace(this.HttpContext?.User?.Identity?.Name)
					? HttpContext.User.Identity.Name
					: "Anonymous";

					Foto foto =  _appSvc.UpoadDeFoto(
							fotoVm,
							currentUsername,
							Server.MapPath("~/content/images/horizontal.png"),
							Server.MapPath("~/content/images/vertical.png"),
							Server.MapPath("~/content/images/thumbnails/"),
							450
						);

					if (foto != null)
					{
						MensagemParaUsuarioViewModel.MensagemSucesso("Registro Salvo.", TempData);
						return RedirectToAction("Detalhes", new { id = foto.Id });
					}
					else
					{
						MensagemParaUsuarioViewModel.MensagemErro(" Não foi possível salvar a foto ", TempData, ModelState);
					}
				}
				catch (DbUpdateConcurrencyException duce)
				{
					MensagemParaUsuarioViewModel.MensagemErro(" Talvez esse registro tenha sido excluído por outra pessoa. " + duce.Message, TempData, ModelState);
				}
				catch (Exception err)
				{
					MensagemParaUsuarioViewModel.MensagemErro("Esse registro não pôde ser salvo. " + err.Message, TempData, ModelState);
				}
			}
			return View(fotoVm);
		}



		private void PopulaEventos(int? selecionado = null)
		{
			var eventos = _evtSvc.GetAll().ToList();
			var eventosList = new SelectList(eventos, "Id", "Nome", selecionado);
			ViewBag.ComboEventos = eventosList;
		}

	}
}
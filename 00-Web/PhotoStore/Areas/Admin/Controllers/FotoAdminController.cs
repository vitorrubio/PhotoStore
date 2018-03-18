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

namespace PhotoStore.Areas.Admin.Controllers
{
	[PhotoStoreAuthorize(Roles = "Administrator")]
	[RouteArea("Admin")]
	public class FotoAdminController : Controller
    {

		private IFotoApplicationService _appSvc;


		public FotoAdminController(IFotoApplicationService appSvc)
		{
			_appSvc = appSvc;
		}

		public async Task<ActionResult> Index()
		{
			return View(await _appSvc.GetAll().ToListAsync());
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
				return View(ft);
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
	}
}
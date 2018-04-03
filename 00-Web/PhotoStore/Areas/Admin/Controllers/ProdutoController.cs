using PhotoStore.ApplicationServices.Interfaces;
using PhotoStore.Controllers;
using PhotoStore.Core.Model;
using PhotoStore.Infra.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PhotoStore.ViewModel;
using System.Data.Entity.Infrastructure;

namespace PhotoStore.Areas.Admin.Controllers
{

	[PhotoStoreAuthorize(Roles = "Administrator")]
	[RouteArea("Admin")]
	public class ProdutoController : BaseController
	{
		private IProdutoApplicationService _appSvc;
		private ITipoProdutoApplicationService _appTipoProdSvc;

		public ProdutoController(IProdutoApplicationService svc, ITipoProdutoApplicationService appTipoProdSvc)
		{
			_appSvc = svc;
			_appTipoProdSvc = appTipoProdSvc;
		}


		public virtual async Task<ActionResult> Index()
		{
			List<Produto> produtos = await _appSvc.GetAll().ToListAsync<Produto>();

			return View(produtos);
		}


		public async Task<ActionResult> Editar(int? id)
		{
			ComboTipoProduto();
			if ((id == null) || (id == 0))
			{
				return View(new Produto());
			}

			try
			{
				Produto pd = await _appSvc.GetByIdAsync(id.Value);

				if (pd != null)
				{
					return View(pd);
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
		public async Task<ActionResult> Editar([Bind(Include = "Id, Nome, Descricao, Preco, TipoProdutoId")] Produto pd)
		{
			ComboTipoProduto(pd?.IdTipoProduto);
			if (ModelState.IsValid)
			{
				try
				{

					await _appSvc.SaveAsync(pd);

					MensagemParaUsuarioViewModel.MensagemSucesso("Registro Salvo.", TempData);
					return View(pd);
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
			return View(pd);
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
				Produto tp = await _appSvc.GetByIdAsync(id.Value);
				if (tp == null)
				{
					MensagemParaUsuarioViewModel.MensagemErro("O item não foi encontrado", TempData, ModelState);
					return RedirectToAction("index");
				}
				return View(tp);
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
			Produto tp = await _appSvc.GetByIdAsync(id);
			if (tp != null)
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

			return View(tp);
		}



		private void ComboTipoProduto(int? selecionado = null)
		{
			var tipos = _appTipoProdSvc.GetAll().ToList();
			var list = new SelectList(tipos, "Id", "Nome", selecionado);
			ViewBag.ComboTipos = list;
		}

	}
}

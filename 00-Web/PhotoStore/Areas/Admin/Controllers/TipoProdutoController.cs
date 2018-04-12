using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using PhotoStore.Infra.Services;
using PhotoStore.Core.Model;
using PhotoStore.Controllers;
using PhotoStore.ApplicationServices.Interfaces;
using PhotoStore.ViewModel;

namespace PhotoStore.Areas.Admin.Controllers
{
    [PhotoStoreAuthorize(Roles = "Administrator")]
    [RouteArea("Admin")]
    public class TipoProdutoController : BaseController
    {

        private ITipoProdutoApplicationService _appSvc;


        public TipoProdutoController(ITipoProdutoApplicationService svc)
		{
			_appSvc = svc;
        }


		public virtual async Task<ActionResult> Index()
		{
			List<TipoProduto> produtos = await _appSvc.GetAll().ToListAsync<TipoProduto>();

			return View(produtos);
		}


		public async Task<ActionResult> Editar(int? id)
        {
            if ((id == null) || (id == 0))
            {
                return View(new TipoProduto());
            }

            try
            {
                TipoProduto tp = await _appSvc.GetByIdAsync(id.Value);

                if (tp != null)
                {
                    return View(tp);
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
        public async Task<ActionResult> Editar([Bind(Include = "Id, Nome, Descricao, PrecoSugerido")] TipoProduto tp)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    await _appSvc.SaveAsync(tp);

                    MensagemParaUsuarioViewModel.MensagemSucesso("Registro Salvo.", TempData);
					tp.Descricao = "zic zixa ";
                    return View(tp);
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
            return View(tp);
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
                TipoProduto tp = await _appSvc.GetByIdAsync(id.Value);
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
            TipoProduto tp = await _appSvc.GetByIdAsync(id);
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

    }
}
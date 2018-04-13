﻿using PhotoStore.Controllers;
using PhotoStore.Core.Model;
using PhotoStore.Infra.Services;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using System.Web.Mvc;
using PhotoStore.ApplicationServices.Interfaces;
using PhotoStore.ViewModel;

namespace PhotoStore.Areas.Admin.Controllers
{

    [PhotoStoreAuthorize(Roles = "Administrator")]
    [RouteArea("Admin")]
    public class EventosController : BaseController
    {

        private IEventoApplicationService _appSvc;
        

        public EventosController(IEventoApplicationService appSvc)
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
                return View(new Evento());
            }

            try
            {
                Evento ev = await _appSvc.GetByIdAsync(id.Value);

                if (ev != null)
                {
                    return View(ev);
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
        public async Task<ActionResult> Editar([Bind(Include = "Id, Nome, Descricao, Inicio, Fim")] Evento ev)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    await _appSvc.SaveAsync(ev);

					MensagemParaUsuarioViewModel.MensagemSucesso("Registro Salvo.", TempData);
					ModelState.Clear();
					//ModelState["Id"].Value = new ValueProviderResult(ev.Id, "", new System.Globalization.CultureInfo("pt-BR"));

					return View(ev);
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
            return View(ev);
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
                Evento ev = await  _appSvc.GetByIdAsync(id.Value);
                if (ev == null)
                {
                    MensagemParaUsuarioViewModel.MensagemErro("O item não foi encontrado", TempData, ModelState);
                    return RedirectToAction("index");
                }
                return View(ev);
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
            Evento ev = await _appSvc.GetByIdAsync(id);
            if (ev != null)
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

            return View(ev);
        }

    }
}
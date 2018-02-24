using PhotoStore.Controllers;
using PhotoStore.Core.Model;
using PhotoStore.Infra.DbContext;
using PhotoStore.Infra.Services;
using PhotoStore.Models.ViewModels;
using PhotoStore.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PhotoStore.Areas.Admin.Controllers
{

    [PhotoStoreAuthorize(Roles = "Administrator")]
    [RouteArea("Admin")]
    public class EventosController : BaseController
    {

        private EventoApplicationService _appSvc;
        

        public EventosController(ApplicationDbContext ctx):base(ctx)
        {
            _appSvc = new EventoApplicationService(this.Context);
        }

        public async Task<ActionResult> Index()
        {
            return View(await Context.Eventos.ToListAsync());
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

                    //if (ev.Id == 0)
                    //{
                    //    Context.Eventos.Add(ev);
                    //}
                    //else
                    //{
                    //    Context.Entry(ev).State = EntityState.Modified;
                    //}
                    //await Context.SaveChangesAsync();

                    await _appSvc.SaveAsync(ev);

                    MensagemParaUsuarioViewModel.MensagemSucesso("Registro Salvo.", TempData);
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
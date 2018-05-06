using PhotoStore.ApplicationServices.Interfaces;
using PhotoStore.Controllers;
using PhotoStore.Infra.Services;
using PhotoStore.ViewModel.Home;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Linq;
using AutoMapper;
using PhotoStore.Core.Model;
using System.Collections.Generic;
using PhotoStore.ViewModel;
using System.Data.Entity;

namespace PhotoStore.Areas.Admin.Controllers
{
    [PhotoStoreAuthorize(Roles = "Administrator, Fotografo")]
    [RouteArea("Admin")]
    public class HomeController : BaseController
    {

		private IEventoApplicationService _eventoApp;
		private IFotoApplicationService _fotoApp;

		public HomeController(IFotoApplicationService fotoSvc, IEventoApplicationService evtSvc)
		{
			_eventoApp = evtSvc;
			_fotoApp = fotoSvc;
		}


    }
}
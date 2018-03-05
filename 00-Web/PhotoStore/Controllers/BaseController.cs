using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using PhotoStore.Infra.DbContext;

namespace PhotoStore.Controllers
{
	public class BaseController : Controller
	{

		#region métodos públicos

		/// <summary>
		/// verifica se o request é ajax, e se for retorna condicionalmente uma partial view em vez da view
		/// </summary>
		/// <param name="viewName"></param>
		/// <param name="model"></param>
		/// <returns></returns>
		public virtual ActionResult PartialViewIfAjax(string viewName, object model)
		{
			if (Request.IsAjaxRequest())
			{
				return PartialView(viewName: viewName, model: model);
			}
			else
			{
				return View(viewName: viewName, model: model);
			}
		}


		/// <summary>
		/// verifica se o request é ajax, e se for retorna condicionalmente uma partial view em vez da view
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public virtual ActionResult PartialViewIfAjax(object model)
		{
			if (Request.IsAjaxRequest())
			{
				return PartialView(model: model);
			}
			else
			{
				return View(model: model);
			}
		}


		#endregion

	}



}
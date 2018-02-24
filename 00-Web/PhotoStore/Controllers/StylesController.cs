using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoStore.Controllers
{
    /// <summary>
    /// http://blog.pmunin.com/2013/04/dynamic-javascript-css-in-aspnet-mvc.html
    /// Since I don't want to register action for every single CSS and JS file, I override HandleUnknownAction to handle all requests to controller that were not associated with declared action.
    /// </summary>
    /// 
    [AllowAnonymous]
    public class StylesController : Controller
    {
        public ActionResult Index()
        {
            return Content("Styles folder");
        }

        protected override void HandleUnknownAction(string actionName)
        {
            var res = this.CssFromView(actionName);
            res.ExecuteResult(ControllerContext);
        }
    }
}
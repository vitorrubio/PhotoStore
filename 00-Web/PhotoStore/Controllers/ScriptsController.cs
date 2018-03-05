using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhotoStore.CrossCutting;

namespace PhotoStore.Controllers
{
    /// <summary>
    /// http://blog.pmunin.com/2013/04/dynamic-javascript-css-in-aspnet-mvc.html
    /// For DynamicWithModel.js i want to pass model, retrieving it from input parameter. In this case since I cannot create method containing dot in a name, I have to use attribute ActionName (alternatively I can avoid using dots in resource names in Index.chtml).
    /// </summary>
    /// 
    [AllowAnonymous]
    public class ScriptsController : Controller
    {

        public ActionResult DynamicCulture(string message)
        {
            return this.JavaScriptFromView(model: message);
        }

        public ActionResult Index()
        {
            return Content("Scripts folder");
        }

        protected override void HandleUnknownAction(string actionName)
        {
            var res = this.JavaScriptFromView();
            res.ExecuteResult(ControllerContext);
        }

    }
}
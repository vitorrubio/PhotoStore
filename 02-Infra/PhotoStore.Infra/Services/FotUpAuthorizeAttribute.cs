using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PhotoStore.Infra.Services
{
    public class PhotoStoreAuthorizeAttribute : System.Web.Mvc.AuthorizeAttribute
    {
        #region métodos protegidos




        protected override void HandleUnauthorizedRequest(System.Web.Mvc.AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                /*
                 * EM HIPÓTESE ALGUMA CHAMAR HandleUnauthorizedRequest SE O USUÁRIO JÁ ESTIVER AUTENTICADO
                 * DEVIDO A UMA MUDANÇA NAS ESPECIFICAÇÕES DO PROTOCOLO HTTP E UMA IMPLEMENTAÇÃO ERRÔNEA DA MICROSOFT
                 * ISSO CAUSA UM ERRO DE LOOP INFINITO
                 * */

                //para pegar o nome da action dentro do HandleUnauthorizedRequest

                string action = filterContext.ActionDescriptor.ActionName;
                string controller = filterContext.RequestContext.RouteData.GetRequiredString("controller");

                string msg = string.Format("Você não tem acesso a essa página.");

                filterContext.HttpContext.Response.Write("Não Autorizado.");
                filterContext.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                //filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
                filterContext.Result = new System.Web.Mvc.HttpStatusCodeResult((int)System.Net.HttpStatusCode.Forbidden, "Não Autorizado.");
                throw new HttpException((int)System.Net.HttpStatusCode.Forbidden, "Não Autorizado.");


            }
            else
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.HttpContext.Response.Clear();

                    filterContext.Result = new System.Web.Mvc.HttpStatusCodeResult((int)System.Net.HttpStatusCode.Unauthorized, "Não Autenticado. Talvez a sessão tenha caído.");
                    filterContext.HttpContext.Response.Write("Não Autenticado. Talvez a sessão tenha caído.");
                    filterContext.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
                    filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
                    filterContext.HttpContext.Response.End();


                }
                else
                {
                    //em vez de fazer o que está definido na base de AuthorizeAttribute, redirecionamos para a página de login
                    //segundo:
                    //https://stackoverflow.com/questions/38517518/how-to-use-both-internal-forms-authenticationas-well-as-azure-ad-authentication
                    //https://stackoverflow.com/questions/26517925/redirect-user-to-custom-login-page-when-using-azure-ad

                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                    {
                        {"action", "Login"},
                        { "controller", "Account"}
                    });

                }



            }
        }


        #endregion
    }
}
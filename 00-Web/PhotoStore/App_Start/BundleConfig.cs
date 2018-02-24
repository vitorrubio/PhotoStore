using System.Web;
using System.Web.Optimization;

namespace PhotoStore
{
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {

            #region bibliotecas javascript

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/globalize").Include(
                "~/Scripts/cldr.js",
                "~/Scripts/cldr/event.js",
                "~/Scripts/cldr/supplemental.js",
                "~/Scripts/cldr/unresolved.js",

                "~/Scripts/globalize.js",
                "~/Scripts/globalize/message.js",
                "~/Scripts/globalize/number.js",
                "~/Scripts/globalize/plural.js",
                "~/Scripts/globalize/date.js",
                "~/Scripts/globalize/currency.js",


                "~/Scripts/globalize/relative-time.js",
                "~/Scripts/globalize/unit.js"

                ));



            bundles.Add(new ScriptBundle("~/bundles/jquerymask").Include(
                "~/Scripts/jquery.mask.min.js",
                "~/Scripts/jquery.maskMoney.min.js"));



            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                      "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/umd/popper.min.js",
                      "~/Scripts/gijgo/modular/core.min.js",
                      "~/Scripts/gijgo/modular/datepicker.min.js",
                      "~/Scripts/bootbox.min.js"


                      ));


            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                      "~/Scripts/jszip.min.js",
                      "~/Scripts/DataTables/jquery.dataTables.min.js",
                      "~/Scripts/DataTables/dataTables.bootstrap.min.js",
                      "~/Scripts/DataTables/dataTables.buttons.min.js",
                      "~/Scripts/DataTables/buttons.bootstrap.min.js",
                      "~/Scripts/DataTables/buttons.colVis.min.js",
                      "~/Scripts/DataTables/buttons.flash.min.js",
                      "~/Scripts/DataTables/buttons.html5.min.js",
                      "~/Scripts/DataTables/buttons.print.min.js",
                      "~/Scripts/DataTables/dataTables.checkboxes.min.js",
                      "~/Scripts/DataTables/dataTables.select.min.js"
                      ));


            bundles.Add(new ScriptBundle("~/bundles/select2").Include(
                  "~/Scripts/select2.min.js",
                  "~/Scripts/i18n/pt-BR.js"

          ));


            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate.min.js",
                        "~/Scripts/jquery.validate.unobtrusive.min.js",
                        "~/Scripts/jquery.validate.globalize.min.js"));


            bundles.Add(new ScriptBundle("~/bundles/treeviewJsBundle").Include(
                "~/Scripts/jstree/jstree.min.js",
                "~/Scripts/ContextMenu/contextMenu.min.js"

                ));


            #endregion










            #region javascript PhotoVendor

            bundles.Add(new ScriptBundle("~/bundles/vtr")
                .Include("~/Scripts/VTRWidgets.js"));


            #endregion









            #region css
            var cssBundle = new StyleBundle("~/bundles/cssbundle")
                .Include("~/Content/bootstrap.min.css", new CssRewriteUrlTransform())
                .Include("~/Content/bootstrap-theme.min.css", new CssRewriteUrlTransform())

                .Include("~/Content/gijgo/modular/core.min.css", new CssRewriteUrlTransform())
                .Include("~/Content/gijgo/modular/datepicker.min.css", new CssRewriteUrlTransform())

                .Include("~/Content/DataTables/css/dataTables.bootstrap.min.css", new CssRewriteUrlTransform())
                .Include("~/Content/DataTables/css/dataTables.checkboxes.css", new CssRewriteUrlTransform())
                .Include("~/Content/DataTables/css/select.dataTables.min.css", new CssRewriteUrlTransform())
                .Include("~/Content/DataTables/css/buttons.bootstrap.min.css", new CssRewriteUrlTransform())
                .Include("~/Content/font-awesome.min.css", new CssRewriteUrlTransform())
                .Include("~/Content/octicons.css", new CssRewriteUrlTransform())
                .Include("~/Content/css/select2.min.css", new CssRewriteUrlTransform())
                .Include("~/Content/css/select2-bootstrap.min.css", new CssRewriteUrlTransform())
                .Include("~/Content/site.css", new CssRewriteUrlTransform())
                ;


            var treeviewCssBundle = new StyleBundle("~/bundles/treeviewCssBundle")
                .Include("~/Scripts/jstree/themes/default/style.min.css", new CssRewriteUrlTransform())
                .Include("~/Scripts/ContextMenu/contextMenu.min.css", new CssRewriteUrlTransform());


            bundles.Add(cssBundle);
            bundles.Add(treeviewCssBundle);


            #endregion


            BundleTable.EnableOptimizations = false;

        }
    }
}

using System.Web.Optimization;

namespace IdentitySample
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Asset/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Asset/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Asset/Scripts/bootstrap.js",
                      "~/Asset/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      //DashBoard
                      "~/Asset/Content/assets/css/bootstrap1.css",
                      "~/Asset/Content/assets/css/font-awesome.css",
                      "~/Asset/Content/assets/css/custom.css",

                      //Side bar Menu
                      "~/Asset/Content/simple-sidebar.css",

                      //Jquery DataTables
                      //"~/Content/dataTables.bootstrap.css",
                      "~/dataTables/buttons.dataTables.min.css",
                      "~/dataTables/dataTables.bootstrap.min.css",
                      "~/dataTables/buttons.bootstrap.min.css",

                      //newadmin
                      "~/Asset/Content/newadmin/css/sb-admin.css",

                      //Chosen Select
                      "~/ChosenSelect/chosen.css"
                      ));
        }
    }
}

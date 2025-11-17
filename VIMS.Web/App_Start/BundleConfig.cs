using System.Web;
using System.Web.Optimization;

namespace VIMS.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/css").Include(
             "~/Assets/css/tabler.min.css",
             "~/Assets/css/tabler-flags.min.css",
             "~/Assets/css/tabler-payments.min.css",
             "~/Assets/css/tabler-vendors.min.css",
             "~/Assets/icons/tabler-icons.min.css",
             "~/Assets/toaster/toastr.min.css",
             "~/Assets/css/demo.min.css",
             "~/Assets/datatables/css/dataTables.bootstrap4.css",
             "~/Assets/css/zebra_datepicker.css",
             "~/Assets/css/zebra_datepicker.min.css",
             "~/Assets/select2/select2.min.css",
             "~/Assets/fontawesome/css/fontawesome.min.css",
             "~/Assets/fontawesome/css/all.min.css",
             "~/Assets/css/Style.css",
             "~/Assets/dropify/css/dropify.min.css"
             ));

            bundles.Add(new ScriptBundle("~/bundles/toastr").Include(
                    "~/Scripts/toastr.js*",
                    "~/Scripts/toastrImp.js"));

            BundleTable.EnableOptimizations = false;
        }
    }
}

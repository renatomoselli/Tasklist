using System.Web;
using System.Web.Optimization;

namespace Tasklist
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            string components = "~/Scripts/tasklist/components/";
            string plugins = "~/Scripts/tasklist/plugins/";
            string tasklist = "~/Scripts/tasklist/";

            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/jquery-3.3.1.min.js")
                .Include("~/Scripts/jquery.validate.min.js")
                .Include("~/Scripts/jquery.validate.unobtrusive.min.js")
                .Include("~/Scripts/jquery-3.3.1.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/lib")
                .Include(components + "jquery-ui/jquery-ui.min.js")
                .Include("~/Scripts/bootstrap.min.js")
                .Include(components + "raphael/raphael.min.js")
                .Include(components + "morris.js/morris.min.js")
                .Include(components + "chart.js/Chart.min.js")
                .Include(components + "Flot/jquery.flot.js")
                .Include(components + "Flot/jquery.flot.resize.js")
                .Include(components + "Flot/jquery.flot.pie.js")
                .Include(components + "Flot/jquery.flot.categories.js")
                .Include(components + "jquery-sparkline/dist/jquery.sparkline.min.js")
                .Include(plugins + "jvectormap/jquery-jvectormap-1.2.2.min.js")
                .Include(plugins + "jvectormap/jquery-jvectormap-world-mill-en.js")
                .Include(components + "jquery-knob/dist/jquery.knob.min.js")
                .Include(components + "moment/moment.js")
                .Include(components + "PACE/pace.min.js")
                .Include(components + "ckeditor/ckeditor.js")
                .Include(components + "datatables.net/js/jquery.dataTables.min.js")
                .Include(components + "datatables.net-bs/js/dataTables.bootstrap.min.js")
                .Include(components + "bootstrap-daterangepicker/daterangepicker.js")
                .Include(components + "bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js")
                .Include(components + "bootstrap-colorpicker/dist/js/bootstrap-colorpicker.min.js")
                .Include(plugins + "bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js")
                .Include(components + "jquery-slimscroll/jquery.slimscroll.min.js")
                .Include(components + "fastclick/lib/fastclick.js")
                .Include(tasklist + "js/adminlte.min.js")
                .Include(tasklist + "js/demo.js")
                .Include(plugins + "bootstrap-slider/bootstrap-slider.js")
                .Include(components + "select2/dist/js/select2.full.min.js")
                .Include(plugins + "input-mask/jquery.inputmask.js")
                .Include(plugins + "input-mask/jquery.inputmask.date.extensions.js")
                .Include(plugins + "input-mask/jquery.inputmask.extensions.js")
                .Include(plugins + "timepicker/bootstrap-timepicker.min.js")
                .Include(plugins + "iCheck/icheck.min.js")
                .Include(plugins + "bootstrap-table/bootstrap-table.min.js")
                .Include(plugins + "bootstrap-table/locale/bootstrap-table-pt-BR.min.js")
                .Include(components + "fullcalendar/dist/fullcalendar.min.js"));

            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/bootstrap.min.css")
                .Include("~/Content/bootstrap-table.min.css")
                .Include(components + "font-awesome/css/font-awesome.min.css")
                .Include(components + "Ionicons/css/ionicons.min.css")
                .Include(components + "datatables.net-bs/css/dataTables.bootstrap.min.css")
                .Include("~/Content/tasklist/css/AdminLTE.min.css")
                .Include("~/Content/tasklist/css/skins/_all-skins.min.css")
                .Include(components + "morris.js/morris.css")
                .Include(components + "jvectormap/jquery-jvectormap.css")
                .Include(components + "bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css")
                .Include(components + "bootstrap-daterangepicker/daterangepicker.css")
                .Include(plugins + "bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css")
                .Include(plugins + "bootstrap-slider/slider.css")
                .Include(components + "select2/dist/css/select2.min.css")
                .Include(components + "bootstrap-colorpicker/dist/css/bootstrap-colorpicker.min.css")
                .Include(plugins + "timepicker/bootstrap-timepicker.min.css")
                .Include(plugins + "iCheck/all.css")
                .Include(plugins + "pace/pace.min.css")
                .Include(components + "fullcalendar/dist/fullcalendar.min.css"));
        }
    }
}

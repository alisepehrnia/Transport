using System.Web.Optimization;

namespace X.WebUI
{
	public class BundleConfig
	{
		// For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery")
				.Include("~/Assets/packages/jquery/jquery*"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryval")
				.Include("~/Assets/packages/jquery-validation/dist/jquery.validate.min.js")
				.Include("~/Assets/packages/jquery-validation-unobtrusive/dist/jquery.validate.unobtrusive.min"));

			// Use the development version of Modernizr to develop with and learn from. Then, when you're
			// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
						"~/Assets/packages/modernizr/modernizr*"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap")
				.Include("~/Assets/packages/bootstrap/js/bootstrap.min.js"));

			bundles.Add(new ScriptBundle("~/bundles/js")
				.Include("~/Assets/js/site.js"));

			bundles.Add(new StyleBundle("~/bundles/css")
				.Include(
				"~/Assets/packages/bootstrap/css/bootstrap.rtl.min.css",
				"~/Assets/packages/bootstrap-icons/font/bootstrap-icons.min.css",
				"~/Assets/css/set.css",
				"~/Assets/css/site.css"));
		}
	}
}
using System.Web.Optimization;
using BundleTransformer.Core.Builders;
using BundleTransformer.Core.Bundles;
using BundleTransformer.Core.Orderers;
using BundleTransformer.Core.Resolvers;

namespace Transport.WebUI
{
	public class BundleConfig
	{
		// For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			_ = new NullBuilder();
			var nullOrderer = new NullOrderer();

			BundleResolver.Current = new CustomBundleResolver();
			var commonStyleBundle = new CustomStyleBundle("~/bundles/sass")
				.Include(
				"~/Assets/sass/site.scss"
				);

			commonStyleBundle.Orderer = nullOrderer;
			bundles.Add(commonStyleBundle);

			bundles.Add(new CustomStyleBundle("~/bundles/sass-login")
				.Include(
				"~/Assets/sass/login.scss"
				));

			bundles.Add(new ScriptBundle("~/bundles/jquery")
				.Include("~/Assets/packages/jquery/jquery*"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryval")
				.Include("~/Assets/packages/jquery-validation/dist/jquery.validate.min.js")
				.Include("~/Assets/packages/jquery-validation/dist/additional-methods.min.js")
				.Include("~/Assets/packages/jquery-validation/dist/localization/messages_fa.min.js")
				.Include("~/Assets/packages/jquery-validation-unobtrusive/dist/jquery.validate.unobtrusive.min"));

			// Use the development version of Modernizr to develop with and learn from. Then, when you're
			// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
						"~/Assets/packages/modernizr/modernizr*"));

			//bundles.Add(new ScriptBundle("~/bundles/bootstrap")
			//	.Include("~/Assets/packages/bootstrap/js/bootstrap.min.js"));

			bundles.Add(new ScriptBundle("~/bundles/js")
				.Include("~/Assets/js/site.js"));

			bundles.Add(new StyleBundle("~/bundles/css")
				.Include(
				"~/Assets/packages/bootstrap/css/bootstrap.rtl.min.css",
				"~/Assets/packages/bootstrap-icons/font/bootstrap-icons.min.css"));
		}
	}
}
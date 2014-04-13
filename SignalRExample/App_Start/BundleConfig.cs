using System.Web;
using System.Web.Optimization;

namespace SignalRExample
{
	public class BundleConfig
	{
		// For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(
				new ScriptBundle("~/bundles/js/common")
				.Include(
					"~/Scripts/jquery-{version}.js",
					"~/Scripts/bootstrap.js",
					"~/Scripts/jquery.signalR-2.0.3.js"					
				)
			);

			bundles.Add(
				new StyleBundle("~/Content/css/common")
				.Include(
					"~/Content/bootstrap.css",
					"~/Content/bootstrap-theme.css",
					"~/Content/site.css"
				)
			);
		}
	}
}
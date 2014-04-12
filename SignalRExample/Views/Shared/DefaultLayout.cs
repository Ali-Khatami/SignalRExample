using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using MOD.Web.Element;
using MOD.Web.Element.Modules;

namespace SignalRExample.Views.Shared
{
	public class DefaultLayout : HtmlDocument
	{
		public override Node Render()
		{
			base.Head.Add(
				Element.Create("meta", "charset", "utf-8"),
				Element.Create("meta", "http-equiv", "X-UA-Compatible", "content", "IE=edge"), // latest version of IE only
				Element.Create("meta", "name", "viewport", "content", "width=device-width, initial-scale=1"),
				Element.Create("title").Add(base.Title)
			);

			// add style bundles
			base.Head.AddHtml(
				Styles.Render("~/Content/css/common").ToHtmlString()
			);

			base.Body.Add(
				PageView
			);

			// add script bundles
			base.Body.AddHtml(
				Scripts.Render("~/bundles/js/common").ToHtmlString(),
				string.Format("<script src=\"{0}\" type=\"text/javascript\"></script>", VirtualPathUtility.ToAbsolute("~/signalr/hubs")),
				string.Format("<script src=\"{0}\" type=\"text/javascript\"></script>", VirtualPathUtility.ToAbsolute("~/Scripts/Example.js"))					
			);

			// add the head and body
			base.Container.Add(
				base.Head,
				base.Body
			);

			return base.Container;
		}
	}
}
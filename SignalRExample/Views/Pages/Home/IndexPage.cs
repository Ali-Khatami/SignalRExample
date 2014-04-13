using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MOD.Web.Element;
using MOD.Web.Element.Modules;

namespace SignalRExample.Views.Pages.Home
{
	public class IndexPage : ViewModule
	{
		public IndexPage() : base("div#HomeIndexPage.container") { }

		public override MOD.Web.Element.Node Render()
		{
			base.Render();

			base.Container.Add(
				Element.Create("div.row").Add(
					Element.Create("div.col-md-12").Add(
						Element.Create("h1").AddText("Hello World!")
					)
				),
				Element.Create("div.row").Add(
					Element.Create("div.col-md-12").Add(
						Element.Create("button#StartStream.btn.btn-success", "style", "margin-right: 7px;").AddText("Start Stream"),
						Element.Create("button#StopStream.btn.btn-danger").AddText("Stop Stream"),
						Element.Create("br"),
						Element.Create("br")
					)
				),
				Element.Create("div.row").Add(
					Element.Create("div.col-md-6").Add(
						Element.Create("div.panel.panel-default", "style", "max-height: 200px; overflow-y: auto;").Add(
							Element.Create("div#MessageSpace.panel-body")
						)
					)
				)
			);

			return base.Container;
		}
	}
}
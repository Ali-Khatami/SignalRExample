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
		public IndexPage() : base("div#HomeIndexPage") { }

		public override MOD.Web.Element.Node Render()
		{
			base.Render();

			base.Container.Add(
				Element.Create("h1").AddText("Hello World!")
			);

			return base.Container;
		}
	}
}
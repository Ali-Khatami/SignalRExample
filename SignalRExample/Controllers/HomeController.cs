using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MOD.Web.Element.Controllers;
using SignalRExample.Views.Pages.Home;
using SignalRExample.Views.Shared;

namespace SignalRExample.Controllers
{
    public class HomeController : ElementController
    {
        public ActionResult Index()
        {
			return View(
				new DefaultLayout()
				{
					PageView = new IndexPage(),
					Title = "Hello World!"
				}
			);
        }
    }
}

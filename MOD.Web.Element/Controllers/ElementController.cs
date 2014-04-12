using System.Text;
using System.Web.Mvc;

namespace MOD.Web.Element.Controllers
{
	/// <summary>
	/// ElementController provides necessary View() methods that allow you to display your IRenderable page views and/or modules.
	/// </summary>
	public abstract class ElementController : Controller
	{
		/// <summary>
		/// Simple struct that contains HTML doctype declarations. Source: http://www.w3schools.com/tags/tag_doctype.asp
		/// </summary>
		public struct DocTypes
		{
			public const string HTML5 = "<!DOCTYPE html>";
			/// <summary>
			/// This DTD contains all HTML elements and attributes, but does NOT INCLUDE presentational or deprecated elements (like font). Framesets are not allowed.
			/// </summary>
			public const string HTML_4_01_STRICT = "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01//EN\" \"http://www.w3.org/TR/html4/strict.dtd\">";
			/// <summary>
			/// This DTD contains all HTML elements and attributes, INCLUDING presentational and deprecated elements (like font). Framesets are not allowed.
			/// </summary>
			public const string HTML_4_01_TRANSITIONAL = "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01 Transitional//EN\" \"http://www.w3.org/TR/html4/loose.dtd\">";
			/// <summary>
			/// This DTD is equal to HTML 4.01 Transitional, but allows the use of frameset content.
			/// </summary>
			public const string HTML_4_01_FRAMESET = "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01 Frameset//EN\" \"http://www.w3.org/TR/html4/frameset.dtd\">";
			/// <summary>
			/// This DTD contains all HTML elements and attributes, but does NOT INCLUDE presentational or deprecated elements (like font). Framesets are not allowed. The markup must also be written as well-formed XML.
			/// </summary>
			public const string XHTML_1_0_STRICT = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Strict//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd\">";
			/// <summary>
			/// This DTD contains all HTML elements and attributes, INCLUDING presentational and deprecated elements (like font). Framesets are not allowed. The markup must also be written as well-formed XML.
			/// </summary>
			public const string XHTML_1_0_TRANSITIONAL = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">";
			/// <summary>
			/// This DTD is equal to XHTML 1.0 Transitional, but allows the use of frameset content.
			/// </summary>
			public const string XHTML_1_0_FRAMESET = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Frameset//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-frameset.dtd\">";
			/// <summary>
			/// This DTD is equal to XHTML 1.0 Strict, but allows you to add modules (for example to provide ruby support for East-Asian languages).
			/// </summary>
			public const string XHTML_1_1 = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.1//EN\" \"http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd\">";
		}

		/// <summary>
		/// Allows you to pass an Element view, generally a layout document but any IRenderable will do. Will return content as
		/// text/html, encdoded in UTF8.
		/// </summary>
		/// <param name="view">
		/// The IRenderable instance you want to render as a page.
		/// </param>
		/// <returns>
		/// Returns Content of view.Render().ToString(). With content type of text/html, encoded in UTF8.
		/// </returns>
		protected ActionResult View(IRenderable view)
		{
			// write the doc type
			Response.Write(DocTypes.HTML5);

			// write the view
			return View(view, "text/html", Encoding.UTF8);
		}

		/// <summary>
		/// Allows you to pass an Element view, generally a layout document but any IRenderable will do. Will return content as
		/// whatever content type you pass, encdoded in UTF8.
		/// </summary>
		/// <param name="view">
		/// The IRenderable instance you want to render as a page.
		/// </param>
		/// <param name="contentType">
		/// The content type you want the page to be served as.
		/// </param>
		/// <returns>
		/// Returns Content of view.Render().ToString(). With content type of whatever you pass, encoded in UTF8
		/// </returns>
		protected ActionResult View(IRenderable view, string contentType)
		{
			return View(view, contentType, Encoding.UTF8);
		}

		/// <summary>
		/// Allows you to pass an Element view, generally a layout document but any IRenderable will do. Will return content as
		/// whatever content type you pass, encoded as whatever you pass.
		/// </summary>
		/// <param name="view">
		/// The IRenderable instance you want to render as a page.
		/// </param>
		/// <param name="contentType">
		/// The content type you want the page to be served as.
		/// </param>
		/// /// <param name="encoding">
		/// The encoding you want to use for the view.
		/// </param>
		/// <returns>
		/// Returns Content of view.Render().ToString(). With content type of whatever you pass, encoded as whatever you pass.
		/// </returns>
		protected ActionResult View(IRenderable view, string contentType, Encoding encoding)
		{
			return Content(view.Render().ToString(), contentType, encoding);
		}
	}
}
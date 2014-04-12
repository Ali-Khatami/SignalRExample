using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MOD.Web.Element.Modules
{
	public abstract class HtmlDocument : ViewModule
	{
		/// <summary>
		/// The title for the page.
		/// </summary>
		public string Title { get; set; }
		/// <summary>
		/// The language the page will be served in.
		/// </summary>
		public string Language { get; set; }
		/// <summary>
		/// The way the page will be encoded.
		/// </summary>
		public string Charset { get; set; }

		/// <summary>
		/// The renderable instance that represents the page view you want to render.
		/// </summary>
		public IRenderable PageView { get; set; }

		#region Body
		private Element _Body = null;

		/// <summary>
		/// The Element that represents body for the page.
		/// </summary>
		protected Element Body
		{
			get { return _Body = _Body ?? CreateBody(); }
			set { _Body = value; }
		}
		#endregion

		#region Head
		private Element _Head = null;

		/// <summary>
		/// The Element that represents head for the page.
		/// </summary>
		protected Element Head
		{
			get { return _Head = _Head ?? CreateHead(); }
			set { _Head = value; }
		}
		#endregion

		/// <summary>
		/// Setups the parts of a default page.
		/// </summary>
		public HtmlDocument()
			: base("html")
		{
		}

		/// <summary>
		/// Used to create the body tag. By default will create the body with no attributes, classes, or child nodes.
		/// </summary>
		/// <returns>
		///	Returns the Element instance of the body tag. This likely doesn't need to be overridden
		///	as you'll be able to add classes and attributes to the instance of Body in your overriding
		///	Render() method.
		/// </returns>
		protected virtual Element CreateBody()
		{
			return Element.Create("body");
		}

		/// <summary>
		/// Used to create the head tag. By default will create the head with no attributes or classes and adds
		/// a title tag using the Title field.
		/// </summary>
		/// <returns>
		///	Returns the Element instance of the head tag. This likely doesn't need to be overridden
		///	as you'll be able to add classes and attributes to the instance of Head in your overriding
		///	Render() method.
		/// </returns>
		protected virtual Element CreateHead()
		{
			return Element.Create("head").Add(
				Element.Create("title").AddText(this.Title)
			);
		}

		/// <summary>
		/// Renders the entire page using the container (html tag) and adding the head then the body. Inside the body
		/// the pageview will be added.
		/// </summary>
		/// <returns>
		/// Returns a Node instance of the entire page (html tag).
		///	</returns>
		public override Node Render()
		{
			base.Render();

			return base.Container.Add(
				Head,
				Body.Add(
					this.PageView
				)
			);
		}
	}
}

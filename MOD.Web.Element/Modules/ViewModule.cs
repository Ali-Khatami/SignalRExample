
namespace MOD.Web.Element.Modules
{
	public class ViewModule : IRenderable
	{
		protected Element _Container = null;
		/// <summary>
		/// The Element that represents markup for the module.
		/// </summary>
		protected Element Container
		{
			get { return _Container = _Container ?? CreateContainer(); }
			set { _Container = value; }
		}
		
		/// <summary>
		/// The tag definition to use to create the container by default
		/// </summary>
		private string _TagDefinition;

		/// <summary>
		/// Create the ViewModule instance with a container of div with no classes or other attributes.
		/// </summary>
		public ViewModule() : this("div") { }

		/// <summary>
		/// Creates the ViewModule instance with a container created with whatever tag definition you pass for the container.
		/// </summary>
		/// <param name="nodeDefinition">
		///	The tag definition you want to create the container with.
		/// </param>
		public ViewModule(string nodeDefinition)
		{
			this._TagDefinition = nodeDefinition;
		}

		public virtual Node Render() { return Container; }

		/// <summary>
		/// Implement this method to override control the Container Element that is created for each instance
		/// </summary>
		/// <returns>Container Element</returns>
		protected virtual Element CreateContainer()
		{
			return Element.Create(this._TagDefinition);
		}
	}
}

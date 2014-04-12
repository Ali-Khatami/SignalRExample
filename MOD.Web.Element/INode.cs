using System.Text;

namespace MOD.Web.Element
{
	/// <summary>
	/// INode interface. Usefull for polymorphism
	/// </summary>
	public interface INode
	{
		void ToString(StringBuilder sb);
	}
}

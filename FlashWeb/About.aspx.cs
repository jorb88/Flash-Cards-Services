using System;
using System.Web.UI;
using System.Reflection;

namespace FlashWeb
{
	public partial class About : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Label1.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
		}
	}
}
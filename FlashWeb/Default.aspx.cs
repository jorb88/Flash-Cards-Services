using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FlashWeb
{
	public partial class _Default : Page
	{
		private FlashEntities db;
		protected void Page_Load(object sender, EventArgs e)
		{
			db = (FlashEntities)Session["db"];
		}

		protected void btnLogin_Click(object sender, EventArgs e)
		{
			IEnumerable<Student> result;
			string code = txtStudentCode.Text.ToLower();
			result = from s in db.Students
					 where s.Id.ToLower() == code
					 select s;
			Student user = result.FirstOrDefault();
			if (user != null)
			{
				Session["user"] = user;
				Response.Redirect("QuizPage.aspx");
			}
			lblError.Text = "Invalid ID, please try again";
		}
	}
}
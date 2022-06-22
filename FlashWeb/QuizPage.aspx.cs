using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FlashLib;

namespace FlashWeb
{
	public partial class QuizPage : System.Web.UI.Page
	{
		private FlashCard quiz;
		private FlashEntities db;
		private Student user;
		protected void Page_Load(object sender, EventArgs e)
		{
			db = (FlashEntities)Session["db"];
			if (Session["user"] == null)
				Response.Redirect("~/Default.aspx");
			user = (Student)Session["user"];
			if (Session["quiz"] == null)
			{
				quiz = new FlashCard();
				Session["quiz"] = quiz;
			}
			else
			{
				quiz = (FlashCard)Session["quiz"];
			}
			if (!IsPostBack)
			{
				quiz.Op = "+";
				btnAnswer.Enabled = false;
				lblQuestion.Text = "----------";
				lblCorrect.Text = "";
				lblWelcome.Text = "Welcome " + user.FirstName + " " + user.LastName;
				lblMessage.Visible = false;
				lblCorrect.Visible = false;
			}
		}
		protected void btnQuestion_Click(object sender, EventArgs e)
		{
			lblQuestion.Text = quiz.BuildEquation();
			txtAnswer.Text = "";
			user.Tries++;
			db.SaveChanges();
			btnQuestion.Enabled = false;
			btnAnswer.Enabled = true;
			lblMessage.Visible = false;
			lblCorrect.Visible = false;
		}
		protected void btnAnswer_Click(object sender, EventArgs e)
		{
			if (txtAnswer.Text.Trim().Length == 0)
			{
				lblMessage.Text = "Please enter an answer.";
				lblMessage.Visible = true;
				return;
			}
			try
			{
				int answer = int.Parse(txtAnswer.Text);
				try
				{
					if (quiz.CheckAnswer(answer) == true)
					{
						lblCorrect.Text = "Correct";
						user.Correct++;
						db.SaveChanges();
					}
					else
					{
						lblCorrect.Text = "Incorrect";
						lblMessage.Text = "The correct answer is " + quiz.CalcAnswer();
						lblMessage.Visible = true;
					}
					lblCorrect.Text = lblCorrect.Text + " - " + user.Correct + " correct out of " + user.Tries + " tries";
					lblCorrect.Visible = true;
				}
				catch (Exception ex)
				{
					lblMessage.Text = ex.Message;
					lblMessage.Visible = true;
				}
				btnQuestion.Enabled = true;
				btnAnswer.Enabled = false;
			}
			catch(Exception ex)
            {
				lblMessage.Text = ex.Message;
				lblMessage.Text += " Please enter another answer.";
				lblMessage.Visible = true;
			}
		}
		protected void rbAdd_CheckedChanged(object sender, EventArgs e) // Used for all operations
		{
			RadioButton rb = (RadioButton)sender;
			quiz.Op = rb.Text;
		}
	}
}
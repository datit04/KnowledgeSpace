using System;
using System.Web.UI;

namespace CalculatorWebApp
{
	public partial class Result : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			// Lấy kết quả từ QueryString
			if (Request.QueryString["result"] != null)
			{
				lblResult.Text = Request.QueryString["result"];
			}
			else
			{
				lblResult.Text = "Không có kết quả!";
			}
		}
	}
}
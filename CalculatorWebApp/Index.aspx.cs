using System;
using System.Web.UI;

namespace CalculatorWebApp
{
	public partial class Index : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
		}

		protected void btnCalculate_Click(object sender, EventArgs e)
		{
			// Lấy giá trị từ input
			if (double.TryParse(txtA.Text, out double a) && double.TryParse(txtB.Text, out double b))
			{
				string operation = rblOperation.SelectedValue;
				double result = 0;

				// Thực hiện phép tính
				switch (operation)
				{
					case "+":
						result = a + b;
						break;
					case "-":
						result = a - b;
						break;
					case "*":
						result = a * b;
						break;
					case "/":
						if (b != 0)
							result = a / b;
						else
						{
							Response.Write("Lỗi: Không thể chia cho 0!");
							return;
						}
						break;
				}

				// Chuyển hướng sang trang kết quả, truyền kết quả qua QueryString
				Response.Redirect("Result.aspx?result=" + result);
			}
			else
			{
				Response.Write("Vui lòng nhập số hợp lệ!");
			}
		}
	}
}
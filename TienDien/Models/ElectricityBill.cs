namespace TienDien.Models
{
	public class ElectricityBill
	{
		public string CustomerName { get; set; }
		public bool IsPriority { get; set; } // Hộ ưu tiên
		public string UsageType { get; set; } // Loại điện: Sinh hoạt
		public double OldIndex { get; set; } // Chỉ số cũ
		public double NewIndex { get; set; } // Chỉ số mới
		public double Consumption { get; set; } // Tiêu thụ = New - Old
		public double TotalAmount { get; set; } // Tiền điện
	}
}
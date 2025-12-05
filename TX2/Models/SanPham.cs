namespace TX2.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("SanPham")]
	public partial class SanPham
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Required(ErrorMessage = "Mã sản phẩm không được để trống")]
		[Display(Name = "Mã sản phẩm")]
		public int MaSP { get; set; }
		[Required(ErrorMessage = "Mã sản phẩm không được để trống")]
		[Display(Name = "Mã sản phẩm")]
		[StringLength(100)]
		public string TenSP { get; set; }
		[Required(ErrorMessage = "Mã sản phẩm không được để trống")]
		[Display(Name = "Mã sản phẩm")]
		public int? SoLuong { get; set; }
		[Required(ErrorMessage = "Mã sản phẩm không được để trống")]
		[Display(Name = "Mã sản phẩm")]
		public decimal? DonGia { get; set; }
		[Required(ErrorMessage = "Mã sản phẩm không được để trống")]
		[Display(Name = "Mã sản phẩm")]
		[StringLength(50)]
		public string HinhAnh { get; set; }
		[Required(ErrorMessage = "Mã sản phẩm không được để trống")]
		[Display(Name = "Mã sản phẩm")]
		public int? MaHang { get; set; }

		public virtual HangSanXuat HangSanXuat { get; set; }
	}
}

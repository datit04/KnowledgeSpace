namespace TX2.Models
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("HangSanXuat")]
	public partial class HangSanXuat
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public HangSanXuat()
		{
			SanPhams = new HashSet<SanPham>();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Required(ErrorMessage = "Mã sản phẩm không được để trống")]
		[Display(Name = "Mã sản phẩm")]
		public int MaHang { get; set; }
		[Required(ErrorMessage = "Mã sản phẩm không được để trống")]
		[Display(Name = "Mã sản phẩm")]

		[StringLength(100)]
		public string TenHang { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<SanPham> SanPhams { get; set; }
	}
}

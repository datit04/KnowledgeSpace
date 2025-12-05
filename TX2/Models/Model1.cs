using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace TX2.Models
{
	public partial class Model1 : DbContext
	{
		public Model1()
			: base("name=Model1")
		{
		}

		public virtual DbSet<HangSanXuat> HangSanXuats { get; set; }
		public virtual DbSet<SanPham> SanPhams { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<SanPham>()
				.Property(e => e.DonGia)
				.HasPrecision(10, 2);
		}
	}
}

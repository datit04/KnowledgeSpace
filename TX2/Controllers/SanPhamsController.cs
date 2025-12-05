using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TX2.Models;

namespace TX2.Controllers
{
	public class SanPhamsController : Controller
	{
		private Model1 db = new Model1();

		// GET: SanPhams
		public ActionResult Index(string searchString)
		{
			bool check = false;
			var sanPhams = db.SanPhams.Include(s => s.HangSanXuat);
			ViewBag.msg = "";
			if (int.TryParse(searchString, out int donGia))
			{
				sanPhams = sanPhams.Where(sp => sp.DonGia >= donGia);
				check = true;
			}
			else
			{
				ViewBag.msg = !check ? "Đơn giá nhập phải là số nguyên" : "";
				//ModelState.AddModelError("DonGia", "Đơn giá phải là số nguyên");
			}
			return View(sanPhams.ToList());
		}

		// GET: SanPhams/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			SanPham sanPham = db.SanPhams.Find(id);
			if (sanPham == null)
			{
				return HttpNotFound();
			}
			return View(sanPham);
		}

		// GET: SanPhams/Create
		public ActionResult Create()
		{
			ViewBag.MaHang = new SelectList(db.HangSanXuats, "MaHang", "TenHang");
			return View();
		}

		// POST: SanPhams/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "MaSP,TenSP,SoLuong,DonGia,HinhAnh,MaHang")] SanPham sanPham, HttpPostedFileBase file)
		{
			if (ModelState.IsValid)
			{
				if (!db.SanPhams.Any(sp => sp.MaSP == sanPham.MaSP))
				{
					if (file != null && file.ContentLength > 0)
					{
						var fileName = System.IO.Path.GetFileName(file.FileName);
						var path = System.IO.Path.Combine(Server.MapPath("~/images"), fileName);
						file.SaveAs(path);

						sanPham.HinhAnh = fileName;
					}
					db.SanPhams.Add(sanPham);
					db.SaveChanges();
					return RedirectToAction("Index");
				}
				else
				{
					ModelState.AddModelError("MaSP", "Mã sản phẩm không được trùng. Vui lòng nhập lại");
				}
			}

			ViewBag.MaHang = new SelectList(db.HangSanXuats, "MaHang", "TenHang", sanPham.MaHang);
			return View(sanPham);
		}

		// GET: SanPhams/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			SanPham sanPham = db.SanPhams.Find(id);
			if (sanPham == null)
			{
				return HttpNotFound();
			}
			ViewBag.MaHang = new SelectList(db.HangSanXuats, "MaHang", "TenHang", sanPham.MaHang);
			return View(sanPham);
		}

		// POST: SanPhams/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "MaSP,TenSP,SoLuong,DonGia,HinhAnh,MaHang")] SanPham sanPham, HttpPostedFileBase file)
		{
			if (ModelState.IsValid)
			{
				if (file != null && file.ContentLength > 0)
				{
					var fileName = System.IO.Path.GetFileName(file.FileName);
					var path = System.IO.Path.Combine(Server.MapPath("~/images"), fileName);
					file.SaveAs(path);

					sanPham.HinhAnh = fileName;
				}
				else
				{
					sanPham.HinhAnh = db.SanPhams.AsNoTracking().FirstOrDefault().HinhAnh;
				}
				db.Entry(sanPham).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.MaHang = new SelectList(db.HangSanXuats, "MaHang", "TenHang", sanPham.MaHang);
			return View(sanPham);
		}

		// GET: SanPhams/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			SanPham sanPham = db.SanPhams.Find(id);
			if (sanPham == null)
			{
				return HttpNotFound();
			}
			return View(sanPham);
		}

		// POST: SanPhams/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			SanPham sanPham = db.SanPhams.Find(id);
			db.SanPhams.Remove(sanPham);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}

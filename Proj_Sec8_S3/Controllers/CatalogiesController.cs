using Proj_Sec8_S3.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Proj_Sec8_S3.Controllers
{
	public class CatalogiesController : Controller
	{
		private Model1 db = new Model1();

		// GET: Catalogies
		public ActionResult Index()
		{
			return View(db.Catalogies.ToList());
		}

		// GET: Catalogies/Details/5
		public ActionResult Details(string id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Catalogy catalogy = db.Catalogies.Find(id);
			if (catalogy == null)
			{
				return HttpNotFound();
			}
			return View(catalogy);
		}

		// GET: Catalogies/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Catalogies/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "CatalogyID,CatalogyName,Description")] Catalogy catalogy)
		{
			if (ModelState.IsValid)
			{
				db.Catalogies.Add(catalogy);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(catalogy);
		}

		// GET: Catalogies/Edit/5
		public ActionResult Edit(string id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Catalogy catalogy = db.Catalogies.Find(id);
			if (catalogy == null)
			{
				return HttpNotFound();
			}
			return View(catalogy);
		}

		// POST: Catalogies/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "CatalogyID,CatalogyName,Description")] Catalogy catalogy)
		{
			if (ModelState.IsValid)
			{
				db.Entry(catalogy).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(catalogy);
		}

		// GET: Catalogies/Delete/5
		public ActionResult Delete(string id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Catalogy catalogy = db.Catalogies.Find(id);
			if (catalogy == null)
			{
				return HttpNotFound();
			}
			return View(catalogy);
		}

		// POST: Catalogies/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(string id)
		{
			Catalogy catalogy = db.Catalogies.Find(id);
			try
			{
				db.Catalogies.Remove(catalogy);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				ViewBag.err = "Không xóa được bản ghi này";
				return View("Delete", catalogy);
			}
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

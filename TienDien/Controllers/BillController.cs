using System;
using System.Web.Mvc;
using TienDien.Models;

namespace TienDien.Controllers
{
	public class BillController : Controller
	{
		// GET: Bill/Index
		public ActionResult Index()
		{
			return View(new ElectricityBill());
		}

		// POST: Bill/Calculate
		[HttpPost]
		public ActionResult Calculate(ElectricityBill model)
		{
			if (ModelState.IsValid)
			{
				model.Consumption = model.NewIndex - model.OldIndex;

				if (model.Consumption < 0)
				{
					ModelState.AddModelError("", "Chỉ số mới phải lớn hơn chỉ số cũ!");
				}
				else
				{
					// Tính tiền điện theo bậc thang
					double total = 0;
					double remaining = model.Consumption;

					if (remaining > 0)
					{
						double tier1 = Math.Min(remaining, 100);
						total += tier1 * 2000;
						remaining -= tier1;

						if (remaining > 0)
						{
							double tier2 = Math.Min(remaining, 50);
							total += tier2 * 2500;
							remaining -= tier2;

							if (remaining > 0)
							{
								double tier3 = Math.Min(remaining, 50);
								total += tier3 * 3000;
								remaining -= tier3;

								if (remaining > 0)
								{
									total += remaining * 4000;
								}
							}
						}
					}

					// Áp dụng tăng giá theo loại điện
					if (model.UsageType == "Kinh doanh")
					{
						total *= 1.20; // Tăng 20%
					}
					else if (model.UsageType == "Sản xuất")
					{
						total *= 1.30; // Tăng 30%
					}

					// Áp dụng giảm giá cho hộ ưu tiên
					if (model.IsPriority)
					{
						total *= 0.90; // Giảm 10%
					}

					model.TotalAmount = total;
				}
			}

			// Chuyển hướng sang trang kết quả nếu không có lỗi
			if (ModelState.IsValid)
			{
				return RedirectToAction("Result", model);
			}

			return View("Index", model);
		}

		// GET: Bill/Result
		public ActionResult Result(ElectricityBill model)
		{
			return View(model);
		}
	}
}
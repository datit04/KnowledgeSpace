using ExamScoreApp.Models;
using System.Web.Mvc;

namespace ExamScoreApp.Controllers
{
	public class ScoreController : Controller
	{
		// GET: Score/Index
		public ActionResult Index()
		{
			return View(new ExamScore());
		}

		// POST: Score/Calculate
		[HttpPost]
		public ActionResult Calculate(ExamScore model)
		{
			if (ModelState.IsValid)
			{
				// Tính điểm ưu tiên khu vực
				double areaScore = 0;
				if (model.Area == "A") areaScore = 1;
				else if (model.Area == "B") areaScore = 2;
				else if (model.Area == "C") areaScore = 3;

				// Tính điểm ưu tiên gia đình chính sách
				double policyScore = model.IsPolicyFamily ? 1 : 0;

				// Tính tổng điểm
				model.TotalScore = model.MathScore + model.PhysicsScore + model.ChemistryScore + areaScore + policyScore;

				// Xác định kết quả
				if (model.TotalScore >= 20)
					model.Result = "Đỗ đại học";
				else if (model.TotalScore >= 15)
					model.Result = "Đỗ cao đẳng";
				else if (model.TotalScore >= 10)
					model.Result = "Đỗ trung cấp";
				else
					model.Result = "Thi trượt";

				// Chuyển hướng sang trang kết quả
				return RedirectToAction("Result", model);
			}

			// Nếu không hợp lệ, trả về trang nhập với lỗi
			return View("Index", model);
		}

		// GET: Score/Result
		public ActionResult Result(ExamScore model)
		{
			return View(model);
		}
	}
}
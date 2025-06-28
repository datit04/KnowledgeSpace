using KnowledgeSpace.WebPortal.Services;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeSpace.WebPortal.Controllers.Components
{
	public class FooterViewComponent : ViewComponent
	{
		private ICategoryApiClient _categoryApiClient;

		public FooterViewComponent(ICategoryApiClient categoryApiClient)
		{
			_categoryApiClient = categoryApiClient;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var categories = await _categoryApiClient.GetCategories();
			return View("Default", categories);
		}
	}
}
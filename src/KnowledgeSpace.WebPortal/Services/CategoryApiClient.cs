using KnowledgeSpace.ViewModels.Contents;

namespace KnowledgeSpace.WebPortal.Services
{
	public class CategoryApiClient : BaseApiClient, ICategoryApiClient
	{
		public CategoryApiClient(IHttpClientFactory httpClientFactory,
			IConfiguration configuration,
			IHttpContextAccessor httpContextAccessor) : base(httpClientFactory, configuration, httpContextAccessor)
		{
		}

		public async Task<List<CategoryVm>> GetCategories()
		{
			return await GetListAsync<CategoryVm>("/api/categories");
		}

		public async Task<CategoryVm> GetCategoryById(int id)
		{
			return await GetAsync<CategoryVm>($"/api/categories/{id}");
		}
	}
}
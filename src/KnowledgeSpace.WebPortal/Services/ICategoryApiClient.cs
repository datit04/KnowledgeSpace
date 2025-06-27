using KnowledgeSpace.ViewModels.Contents;

namespace KnowledgeSpace.WebPortal.Services
{
	public interface ICategoryApiClient
	{
		Task<List<CategoryVm>> GetCategories();
	}
}
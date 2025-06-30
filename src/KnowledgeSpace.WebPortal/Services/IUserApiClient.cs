using KnowledgeSpace.ViewModels.Systems;

namespace KnowledgeSpace.WebPortal.Services
{
	public interface IUserApiClient
	{
		Task<UserVm> GetById(string id);
	}
}
using KnowledgeSpace.ViewModels;
using KnowledgeSpace.ViewModels.Contents;
using KnowledgeSpace.ViewModels.Systems;

namespace KnowledgeSpace.WebPortal.Services
{
	public class UserApiClient : BaseApiClient, IUserApiClient
	{
		public UserApiClient(IHttpClientFactory httpClientFactory,
			IConfiguration configuration,
			IHttpContextAccessor httpContextAccessor)
			: base(httpClientFactory, configuration, httpContextAccessor)
		{
		}

		public async Task<UserVm> GetById(string id)
		{
			return await GetAsync<UserVm>($"/api/users/{id}", true);
		}

		public async Task<Pagination<KnowledgeBaseQuickVm>> GetKnowledgeBasesByUserId(string userId, int pageIndex, int pageSize)
		{
			var apiUrl = $"/api/users/{userId}/knowledgeBases?pageIndex={pageIndex}&pageSize={pageSize}";
			return await GetAsync<Pagination<KnowledgeBaseQuickVm>>(apiUrl, true);
		}
	}
}
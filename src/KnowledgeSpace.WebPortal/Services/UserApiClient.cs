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
	}
}
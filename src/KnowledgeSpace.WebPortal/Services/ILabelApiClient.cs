using KnowledgeSpace.ViewModels.Contents;

namespace KnowledgeSpace.WebPortal.Services
{
	public interface ILabelApiClient
	{
		Task<List<LabelVm>> GetPopularLabels(int take);

		Task<LabelVm> GetLabelById(string labelId);
	}
}
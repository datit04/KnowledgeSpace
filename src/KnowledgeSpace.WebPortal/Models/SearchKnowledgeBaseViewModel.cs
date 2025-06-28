using KnowledgeSpace.ViewModels;
using KnowledgeSpace.ViewModels.Contents;

namespace KnowledgeSpace.WebPortal.Models
{
	public class SearchKnowledgeBaseViewModel
	{
		public Pagination<KnowledgeBaseQuickVm> Data { set; get; }

		public string Keyword { set; get; }
	}
}
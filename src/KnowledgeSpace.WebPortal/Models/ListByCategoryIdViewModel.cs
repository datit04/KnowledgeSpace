using KnowledgeSpace.ViewModels;
using KnowledgeSpace.ViewModels.Contents;

namespace KnowledgeSpace.WebPortal.Models
{
	public class ListByCategoryIdViewModel
	{
		public Pagination<KnowledgeBaseQuickVm> Data { set; get; }

		public CategoryVm Category { set; get; }
	}
}
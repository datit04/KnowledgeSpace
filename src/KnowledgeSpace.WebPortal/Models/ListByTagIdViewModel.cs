using KnowledgeSpace.ViewModels;
using KnowledgeSpace.ViewModels.Contents;

namespace KnowledgeSpace.WebPortal.Models
{
	public class ListByTagIdViewModel
	{
		public Pagination<KnowledgeBaseQuickVm> Data { set; get; }

		public LabelVm LabelVm { set; get; }
	}
}
using KnowledgeSpace.ViewModels.Contents;
using KnowledgeSpace.ViewModels.Systems;

namespace KnowledgeSpace.WebPortal.Models
{
	public class KnowledgeBaseDetailViewModel
	{
		public CategoryVm Category { set; get; }
		public KnowledgeBaseVm Detail { get; set; }

		public List<LabelVm> Labels { get; set; }

		public UserVm CurrentUser { get; set; }
	}
}
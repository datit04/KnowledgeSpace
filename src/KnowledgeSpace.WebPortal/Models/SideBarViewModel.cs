using KnowledgeSpace.ViewModels.Contents;

namespace KnowledgeSpace.WebPortal.Models
{
	public class SideBarViewModel
	{
		public List<KnowledgeBaseQuickVm> PopularKnowledgeBases { get; set; }

		public List<CategoryVm> Categories { get; set; }

		public List<CommentVm> RecentComments { get; set; }
	}
}
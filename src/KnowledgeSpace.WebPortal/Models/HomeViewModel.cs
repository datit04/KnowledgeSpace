using KnowledgeSpace.ViewModels.Contents;

namespace KnowledgeSpace.WebPortal.Models
{
	public class HomeViewModel
	{
		public List<KnowledgeBaseQuickVm> LatestKnowledgeBases { get; set; }
		public List<KnowledgeBaseQuickVm> PopularKnowledgeBases { get; set; }

		public List<LabelVm> PopularLabels { get; set; }
	}
}
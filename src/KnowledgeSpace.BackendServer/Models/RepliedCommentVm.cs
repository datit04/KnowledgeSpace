namespace KnowledgeSpace.BackendServer.Models
{
	public class RepliedCommentVm
	{
		public string RepliedName { get; set; }

		public string CommentContent { get; set; }

		public string KnowledgeBaseTitle { get; set; }

		public int KnowledeBaseId { get; set; }

		public string KnowledgeBaseSeoAlias { get; set; }
	}
}
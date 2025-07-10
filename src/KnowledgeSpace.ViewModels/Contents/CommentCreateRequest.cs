namespace KnowledgeSpace.ViewModels.Contents
{
	public class CommentCreateRequest
	{
		public string Content { get; set; }

		public int KnowledgeBaseId { get; set; }

		public int? ReplyId { get; set; }
	}
}
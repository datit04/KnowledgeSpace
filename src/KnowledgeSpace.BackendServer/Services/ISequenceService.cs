namespace KnowledgeSpace.BackendServer.Services
{
	public interface ISequenceService
	{
		Task<int> GetKnowledgeBaseNewId();
	}
}
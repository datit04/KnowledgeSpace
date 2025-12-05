namespace RagApp.Services.Llm
{
	public interface ILlmChatProvider
	{
		Task<string> AskAsyns(String system, string user, CancellationToken cancellationToken = default);
	}
}


namespace RagApp.Services.Llm
{
	public class OllamaChatProvider : ILlmChatProvider
	{
		public Task<string> AskAsyns(string system, string user, CancellationToken cancellationToken = default)
		{
			throw new NotImplementedException();
		}
	}
}

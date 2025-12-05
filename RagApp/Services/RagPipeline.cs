using RagApp.Services.Llm;

namespace RagApp.Services
{
	public class RagPipeline
	{
		private readonly ILlmChatProvider _llmChatProvider;
		public RagPipeline(ILlmChatProvider llmChatProvider)
		{
			_llmChatProvider = llmChatProvider;
		}
		public async Task<string> AskAsync(string question, CancellationToken cancellationToken = default)
		{
			string relevantDocs = string.Empty;
			var systemPrompt = "You are a helpful assistant.";
			var userPrompt = $"{string.Join("\n\n", relevantDocs)}\n\nQuestion: {question}";
			var answer = await _llmChatProvider.AskAsyns(systemPrompt, userPrompt, cancellationToken);
			return answer;
		}
	}
}

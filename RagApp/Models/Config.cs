namespace RagApp.Models
{
	public class Config
	{
		public string Provider { get; set; } = "OpenAI"; // or "Ollama"
		public OpenAIConfig OpenAI { get; set; } = new();
	}
	public class OpenAIConfig
	{
		public string ApiKey { get; set; } = string.Empty;
		public string ChatModel { get; set; } = "gpt-4o-mini";
	}
}

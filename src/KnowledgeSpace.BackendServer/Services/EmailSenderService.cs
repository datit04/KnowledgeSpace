using Microsoft.AspNetCore.Identity.UI.Services;

namespace KnowledgeSpace.BackendServer.Services
{
	public class EmailSenderService : IEmailSender
	{
		public Task SendEmailAsync(string email, string subject, string htmlMessage)
		{
			Console.WriteLine($"[DEV MODE] Email to: {email}, Subject: {subject}");
			// hoặc dùng logger nếu có sẵn
			// _logger.LogInformation($"[DEV MODE] Email to: {email}, Subject: {subject}");
			return Task.CompletedTask;
		}

	}
}
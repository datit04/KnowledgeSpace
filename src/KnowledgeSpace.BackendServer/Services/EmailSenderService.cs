using KnowledgeSpace.ViewModels;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using RestSharp;
using RestSharp.Authenticators;

namespace KnowledgeSpace.BackendServer.Services
{
	public class EmailSenderService : IEmailSender
	{
		private readonly EmailSettings _emailSettings;

		public EmailSenderService(IOptions<EmailSettings> emailOptions)
		{
			_emailSettings = emailOptions.Value;
		}

		public async Task SendEmailAsync(string email, string subject, string htmlMessage)
		{
			var options = new RestClientOptions(_emailSettings.ApiBaseUri)
			{
				Authenticator = new HttpBasicAuthenticator("api", _emailSettings.ApiKey)
			};

			var client = new RestClient(options);

			// Endpoint của Mailgun hoặc API bạn đang dùng, ví dụ: https://api.mailgun.net/v3/{domain}/messages
			var request = new RestRequest($"{_emailSettings.Domain}/messages", Method.Post);

			// Gửi form-urlencoded (Mailgun yêu cầu định dạng này)
			request.AddParameter("from", _emailSettings.From);
			request.AddParameter("to", email);
			request.AddParameter("subject", subject);
			request.AddParameter("html", htmlMessage);

			// Thực hiện request
			var response = await client.ExecuteAsync(request);

			// Bạn có thể kiểm tra response nếu cần
			if (!response.IsSuccessful)
			{
				throw new Exception($"Gửi email thất bại: {response.StatusCode} - {response.Content}");
			}
		}
	}
}

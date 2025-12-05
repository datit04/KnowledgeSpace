using Microsoft.AspNetCore.Mvc;
using RagApp.Models;
using RagApp.Services;

namespace RagApp.Controllers
{
	[Route("query")]
	[ApiController]
	public class QueryController : ControllerBase
	{
		private readonly RagPipeline _rag;
		public QueryController(RagPipeline rag)
		{
			_rag = rag;
		}
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] QueryRequest request, CancellationToken cancellationToken)
		{
			if (string.IsNullOrWhiteSpace(request.Question))
			{
				return BadRequest("Question cannot be empty.");
			}
			var answer = await _rag.AskAsync(request.Question, cancellationToken);
			return Ok(answer);
		}
	}
}

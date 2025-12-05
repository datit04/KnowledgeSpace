using OpenAI.Chat;
using RagApp.Models;
using RagApp.Services;
using RagApp.Services.Llm;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
if (builder.Environment.IsDevelopment())
{
	builder.Configuration.AddUserSecrets<Program>(optional: true);
}
var configuration = builder.Configuration.Get<Config>() ?? new Config();
builder.Services.AddSingleton(configuration);

//Register Open AI
if (configuration.Provider == "OpenAI")
{
	builder.Services.AddSingleton<ILlmChatProvider, OpenAIChatProvider>();
	builder.Services.AddSingleton(new ChatClient(configuration.OpenAI.ChatModel, configuration.OpenAI.ApiKey));
}
else
{
	//Register Ollama
	builder.Services.AddSingleton<ILlmChatProvider, OllamaChatProvider>();
}

//Register RAG Pipeline
builder.Services.AddSingleton<RagPipeline>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "RAG API", Version = "V1" }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

﻿using KnowledgeSpace.BackendServer.Data;
using Serilog;

namespace KnowledgeSpace.BackendServer
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Log.Logger = new LoggerConfiguration()
							 .Enrich.FromLogContext()
							 .WriteTo.Console()
							 .CreateLogger();
			var host = CreateHostBuilder(args).Build();

			using (var scope = host.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				try
				{
					Log.Information("Seeding data...");
					var dbInitializer = services.GetService<DbInitializer>();
					dbInitializer.Seed().Wait();
				}
				catch (Exception ex)
				{
					var logger = services.GetRequiredService<ILogger<Program>>();
					logger.LogError(ex, "An error occurred while seeding the database.");
				}
			}
			host.Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
					 .UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
					.ReadFrom.Configuration(hostingContext.Configuration))
					.ConfigureWebHostDefaults(webBuilder =>

					{
						webBuilder.UseStartup<Startup>();
					});
	}
}
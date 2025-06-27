using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace KnowledgeSpace.BackendServer.Data
{
	public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
	{
		public ApplicationDbContext CreateDbContext(string[] args)
		{
			var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
			IConfigurationRoot configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.AddJsonFile($"appsettings.{environmentName}.json")
				.Build();
			var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
			var connectionString = configuration.GetConnectionString("DefaultConnection");
			builder.UseSqlServer(connectionString);
			return new ApplicationDbContext(builder.Options);
		}
	}
}
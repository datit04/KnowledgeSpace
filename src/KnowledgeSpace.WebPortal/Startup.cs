﻿using KnowledgeSpace.WebPortal.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;

namespace KnowledgeSpace.WebPortal
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{

			services.AddHttpClient();
			//IdentityModelEventSource.ShowPII = true; //Add this line
			services.AddAuthentication(options =>
			{
				options.DefaultScheme = "Cookies";
				options.DefaultChallengeScheme = "oidc";
			})
				.AddCookie("Cookies")
				.AddOpenIdConnect("oidc", options =>
				{
					options.Authority = Configuration["Authorization:AuthorityUrl"];
					options.RequireHttpsMetadata = false;
					options.GetClaimsFromUserInfoEndpoint = true;

					options.ClientId = Configuration["Authorization:ClientId"];
					options.ClientSecret = Configuration["Authorization:ClientSecret"];
					options.ResponseType = "code";

					options.SaveTokens = true;

					options.Scope.Add("openid");
					options.Scope.Add("profile");
					options.Scope.Add("offline_access");
					options.Scope.Add("api.knowledgespace");

					options.TokenValidationParameters = new TokenValidationParameters
					{
						NameClaimType = "name",
						RoleClaimType = "role"
					};
				});
			var builder = services.AddControllersWithViews();
			var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
			if (environment == Environments.Development)
			{
				builder.AddRazorRuntimeCompilation();
			}

			//Declare DI containers
			services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

			services.AddTransient<ICategoryApiClient, CategoryApiClient>();
			services.AddTransient<IKnowledgeBaseApiClient, KnowledgeBaseApiClient>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
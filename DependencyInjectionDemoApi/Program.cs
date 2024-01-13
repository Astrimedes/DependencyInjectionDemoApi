using DependencyInjectionDemoApi.Services;

namespace DependencyInjectionDemoApi
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// custom setup
			Startup(builder);

			// Add base services to the container.
			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			// build
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
		}

		private static void Startup(WebApplicationBuilder builder)
		{
			builder.Services.ConfigureRandomService(builder.Configuration);
			builder.Services.AddRandomService(builder.Configuration);
		}
	}
}
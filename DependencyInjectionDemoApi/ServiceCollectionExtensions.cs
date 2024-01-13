using DependencyInjectionDemoApi.Configuration;
using DependencyInjectionDemoApi.Services;

namespace DependencyInjectionDemoApi;

public static class ServiceCollectionExtensions
{
	private static readonly string OptionSection = "RandomNumberOptions";

	public static IServiceCollection AddRandomService(this IServiceCollection services, IConfiguration config)
	{
		var options = config.GetSection(OptionSection).Get<RandomNumberServiceConfig>();

		return services.
			AddSingleton<IRandomNumberService>(x => new RandomNumberService(options.Seed, options.Min, options.Max));
	}

	public static IServiceCollection ConfigureRandomService(this IServiceCollection services, IConfiguration configuration)
	{
		var section = configuration.GetSection(OptionSection);
		
		if (!section.Exists())
		{
			throw new Exception("missing config");
		}

		services
			.AddOptions<RandomNumberServiceConfig>()
			.Bind(section)
			.ValidateDataAnnotations()
			.ValidateOnStart();

		return services;
	}

}

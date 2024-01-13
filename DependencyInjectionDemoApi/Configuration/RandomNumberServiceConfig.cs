using System.ComponentModel.DataAnnotations;

namespace DependencyInjectionDemoApi.Configuration;

public class RandomNumberServiceConfig
{
	public int? Seed { get; set; }

	[Required]
	public int Min { get; set; }

	[Required]
	public int Max { get; set; }
}

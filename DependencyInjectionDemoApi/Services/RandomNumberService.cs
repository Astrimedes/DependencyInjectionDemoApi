namespace DependencyInjectionDemoApi.Services;

public class RandomNumberService : IRandomNumberService
{
	private Random rng;
	private int min;
	private int max;

	public RandomNumberService(int? seed, int min, int max)
	{
		rng = seed.HasValue ? new Random(seed.Value) : new Random();
		this.min = min;
		this.max = max;
	}

	public int NextRandomNumber()
	{
		return rng.Next(min, max);
	}
}

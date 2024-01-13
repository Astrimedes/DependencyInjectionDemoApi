using DependencyInjectionDemoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionDemoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class RandomNumberController : ControllerBase
{
	private readonly IRandomNumberService rngService;

	public RandomNumberController(IRandomNumberService rngService)
	{
		this.rngService = rngService;
	}

	[HttpGet(Name = "GetRandomNumber")]
	public int Get()
	{
		return rngService.NextRandomNumber();
	}
}
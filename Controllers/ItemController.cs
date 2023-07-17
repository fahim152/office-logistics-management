using Microsoft.AspNetCore.Mvc;
using mlbd_logistics_management.Services;

namespace mlbd_logistics_management.Controllers;

[ApiController]
[Route("api/item ")]
public class ItemController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ItemService _itemService;

    public ItemController(ItemService itemService)
    {
        this._itemService = itemService; 
    }

    [HttpGet("data")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}

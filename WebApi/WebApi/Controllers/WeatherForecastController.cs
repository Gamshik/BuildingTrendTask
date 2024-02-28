using Microsoft.AspNetCore.Mvc;
using WebApi.Entities.TagEntities;
using WebApi.Entities.TotalChatsEntities;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private TotalChats _totalChats;
        private Tag _tag;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _totalChats = new TotalChats();
            _tag = new Tag();
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {
            return Ok(_tag.ToJson()); 

            
        }
    }
}

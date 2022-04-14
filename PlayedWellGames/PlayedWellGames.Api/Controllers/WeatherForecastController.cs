using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlayedWellGames.Application.Users.Commands;
using PlayedWellGames.Core;

namespace PlayedWellGames.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        private readonly IMediator _mediator;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            var user = await _mediator.Send(new AddUserCommand
            {
                FirstName = "Ovidiu",
                LastName = "Bogosel",
                UserName = "ovidiu.bogosel",
                Pass = "1234",
                Mail = "ovidiu.bogosel@gmail.com",
                Address = "72 Merthyr Road",
                Phone = "(777)249-9915",
                Role = Role.Regular
            });

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
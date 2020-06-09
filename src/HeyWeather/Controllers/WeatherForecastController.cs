using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeyWeather.DAL.DataObjects;
using HeyWeather.DAL.Entities;
using HeyWeather.DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HeyWeather.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherPreferencesController : ControllerBase
    {
        private readonly ILogger<WeatherPreferencesController> _logger;
        private readonly IWeatherPreferenceRepository _weatherForecastRepository;

        public WeatherPreferencesController(ILogger<WeatherPreferencesController> logger, IWeatherPreferenceRepository weatherForecastRepository)
        {
            _logger = logger;
            _weatherForecastRepository = weatherForecastRepository;
        }

        [HttpPost]
        public WeatherPreference SetPreference(WeatherPreferenceDTO preference)
        {
            var newPreference = new WeatherPreference(preference.Email, preference.Lat, preference.Lng, preference.Unit);
            _weatherForecastRepository.AddPreference(newPreference);
            return newPreference;
        }

        [HttpGet]
        public async Task<List<WeatherPreference>> ListUserPreferencesAsync(Guid weatherPreference)
        {
            return await _weatherForecastRepository.ListAllAsync();
        }
    }
}

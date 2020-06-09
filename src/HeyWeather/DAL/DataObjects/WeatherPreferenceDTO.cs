using System;
using HeyWeather.DAL.Entities;

namespace HeyWeather.DAL.DataObjects
{
    public class WeatherPreferenceDTO
    {
        public string Email { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public UnitFormat Unit { get; set; }
    }
}

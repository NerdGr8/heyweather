using System;
using NpgsqlTypes;

namespace HeyWeather.DAL.Entities
{
    public enum UnitFormat
    {
        Standard,
        Metric,
        Imperial
    }
    public class WeatherPreference
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public NpgsqlPoint Location { get; set; }
        public UnitFormat Unit { get; set; }
        public WeatherPreference(string email, double lat, double lng, UnitFormat unit = UnitFormat.Standard)
        {
            Email = email;
            Location = new NpgsqlPoint(lat, lng);
            Unit = unit;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeyWeather.DAL.DataObjects;
using HeyWeather.DAL.Entities;
using Messaging.API.DAL;
using Microsoft.EntityFrameworkCore;

namespace HeyWeather.DAL.Repository
{
    public interface IWeatherPreferenceRepository
    {
        WeatherPreference GetPreference(Guid preferenceId);
        WeatherPreference AddPreference(WeatherPreference preference);
        Task<bool> UpdatePreference(WeatherPreference preference);
        Task<List<WeatherPreference>> ListAllAsync();
    }
    public class WeatherPreferenceRepository : IWeatherPreferenceRepository
    {
        public readonly RepositoryContext _repositoryContext;
        public WeatherPreferenceRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public async Task<List<WeatherPreference>> ListAllAsync()
        {
            return await _repositoryContext.WeatherPreferences.ToListAsync();
        }
        public WeatherPreference GetPreference(Guid preferenceId)
        {
            return _repositoryContext.WeatherPreferences.Where(x=>x.Id == preferenceId).FirstOrDefault();
        }
        public WeatherPreference AddPreference(WeatherPreference preference)
        {
            _repositoryContext.WeatherPreferences.Add(preference);
            return preference;
        }
        public async Task<bool> UpdatePreference(WeatherPreference preference)
        {
            _repositoryContext.Entry(await _repositoryContext.WeatherPreferences.FirstOrDefaultAsync(x => x.Id == preference.Id)).CurrentValues.SetValues(preference);
            return (await _repositoryContext.SaveChangesAsync()) > 0;
        }
    }
}

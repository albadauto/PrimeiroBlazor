using PrimeiroBlazor.Models;

namespace PrimeiroBlazor.Services.Interface
{
    public interface IWeatherforecast
    {
        Task<List<WeatherForecast>> GetAll();
    }
}

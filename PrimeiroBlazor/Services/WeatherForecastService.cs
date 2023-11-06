using Newtonsoft.Json;
using PrimeiroBlazor.Models;
using PrimeiroBlazor.Services.Interface;

namespace PrimeiroBlazor.Services
{
    public class WeatherForecastService : IWeatherforecast
    {
        private readonly string APIURL = "https://192.168.18.225:7237/WeatherForecast";
        
        public async Task<List<WeatherForecast>> GetAll()
        {
            using(var client = new HttpClient())
            {
                var result = await client.GetAsync(APIURL);
                var read = await result.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<List<WeatherForecast>>(read);
                return json;
            }
        }
    }
}

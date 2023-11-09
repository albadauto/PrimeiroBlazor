using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PrimeiroBlazor;
using PrimeiroBlazor.Services;
using PrimeiroBlazor.Services.Interface;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<IWeatherforecast, WeatherForecastService>();
builder.Services.AddScoped<IGameService, GameService>();
await builder.Build().RunAsync();

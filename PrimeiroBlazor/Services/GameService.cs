using Microsoft.JSInterop;
using Newtonsoft.Json;
using PrimeiroBlazor.Models;
using PrimeiroBlazor.Models.DTO;
using PrimeiroBlazor.Services.Interface;
using PrimeiroBlazor.Settings;
using System.Text;

namespace PrimeiroBlazor.Services
{
    public class GameService : IGameService
    {
        private string APIURL = ApiSettings.APIURL;
        private IJSRuntime javascript;

        public GameService(IJSRuntime js)
        {
            javascript = js;
        }

        public async Task<List<GamesDTO>> GetAllGames()
        {
           using(var client = new HttpClient())
            {
                var message = await client.GetAsync($"{APIURL}/GetGames");
                var content = await message.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<GamesDTO>>(content);
            }
        }

        public async Task InsertGame(GamesDTO dto)
        {
            using (var client = new HttpClient())
            {
                var serialized = JsonConvert.SerializeObject(dto);
                var insert = await client.PostAsync($"{APIURL}/AddGame", new StringContent(serialized, Encoding.UTF8, "application/json"));
                if (insert.IsSuccessStatusCode)
                {
                    var readed = await insert.Content.ReadAsStringAsync();
                    await javascript.InvokeAsync<bool>("confirm", "Inserido com sucesso");
                }
                else
                {
                    await javascript.InvokeAsync<bool>("confirm", "não Inserido com sucesso");
                }

            }
        }

    }
}

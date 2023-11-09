using PrimeiroBlazor.Models.DTO;

namespace PrimeiroBlazor.Services.Interface
{
    public interface IGameService
    {
        Task InsertGame(GamesDTO dto);
        Task<List<GamesDTO>> GetAllGames();
    }
}

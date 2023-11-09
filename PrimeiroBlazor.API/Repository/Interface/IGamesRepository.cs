using PrimeiroBlazor.Models.DTO;

namespace PrimeiroBlazor.API.Repository.Interface
{
    public interface IGamesRepository
    {
        Task<GamesDTO> InsertGames(GamesDTO games);
        Task<List<GamesDTO>> GetAllGames();
    }
}

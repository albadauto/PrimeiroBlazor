using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PrimeiroBlazor.API.Context;
using PrimeiroBlazor.API.Repository.Interface;
using PrimeiroBlazor.Models;
using PrimeiroBlazor.Models.DTO;

namespace PrimeiroBlazor.API.Repository
{
    public class GamesRepository : IGamesRepository
    {
        private readonly SqlServerContext _context;
        private readonly IMapper _mapper;
        public GamesRepository(SqlServerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GamesDTO>> GetAllGames()
        {
            var allgames = await _context.Games.ToListAsync();
            return _mapper.Map<List<GamesDTO>>(allgames);
        }

        public async Task<GamesDTO> InsertGames(GamesDTO games)
        {
            var toInsert = _mapper.Map<Games>(games);
            await _context.Games.AddAsync(toInsert);
            await _context.SaveChangesAsync();
            return _mapper.Map<GamesDTO>(toInsert);
        }
    }
}

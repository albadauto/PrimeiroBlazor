using AutoMapper;
using PrimeiroBlazor.Models;
using PrimeiroBlazor.Models.DTO;

namespace PrimeiroBlazor.API.Config
{
    public static class MapperConfig
    {
        public static MapperConfiguration ConfigureMapper()
        {
            var map = new MapperConfiguration(mapper =>
            {
                mapper.CreateMap<Games, GamesDTO>();
                mapper.CreateMap<GamesDTO, Games>();

            });
            return map;
        }
    }
}

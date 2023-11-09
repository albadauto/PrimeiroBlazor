using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrimeiroBlazor.API.Repository.Interface;
using PrimeiroBlazor.Models;
using PrimeiroBlazor.Models.DTO;

namespace PrimeiroBlazor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGamesRepository _repository;
        public GamesController(IGamesRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("/AddGame")]
        public async Task<ActionResult> AddGame([FromBody] GamesDTO dto)
        {
            try
            {
                await _repository.InsertGames(dto);
                return Ok(new ApiResponse { Data = null, Success = true, Message = "Insertido com sucesso" });
            }
            catch (Exception ex)
            {

                return BadRequest(new ApiResponse { Data = ex.StackTrace, Success = false, Message = ex.Message });

            }
        }

        [HttpGet("/GetGames")]
        public async Task<ActionResult<List<GamesDTO>>> GetGames()
        {
            try
            {
                return await _repository.GetAllGames();
            }
            catch (Exception ex)
            {

                return BadRequest(new ApiResponse { Data = ex.StackTrace, Success = false, Message = ex.Message });
            }
        }
    }
}

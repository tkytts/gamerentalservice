using GameRentalService.Infrastructure.Models;
using GameRentalService.Infrastructure.UseCases.Games;
using GameRentalService.Infrastructure.UseCases.Games.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GamesRentalService.Application.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/games")]
    public class GamesController : ControllerBase
    {
        private readonly ILogger<GamesController> _logger;

        public GamesController(ILogger<GamesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get(
            [FromQuery] PaginationParameters paginationParameters,
            [FromServices] IGetPaginatedGamesUseCase useCase)
        {
            return Ok(await useCase.Execute(paginationParameters));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(
        [FromRoute] int id,
        [FromServices] IGetGameUseCase useCase)
        {
            var result = await useCase.Execute(id);

            if (result != null)
                return Ok(result);

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Post(
            GameViewModel game,
            [FromServices] ICreateGameUseCase useCase)
        {
            var result = await useCase.ExecuteAsync(game);
            return CreatedAtAction(nameof(Get), result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(
            [FromRoute] int id,
            [FromServices] IDeleteGameUseCase useCase)
        {
            await useCase.Execute(id);
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch(
            [FromRoute] int id,
            [FromBody] GameViewModel game,
            [FromServices] IUpdateGameUseCase useCase)
        {
            game.Id = id;
            await useCase.Execute(game);
            return Ok();
        }
    }
}

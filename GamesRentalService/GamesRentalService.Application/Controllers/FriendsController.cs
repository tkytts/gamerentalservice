using GameRentalService.Infrastructure.Models;
using GamesRentalService.Infrastructure.Models;
using GamesRentalService.Infrastructure.UseCases.Friends.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GamesRentalService.Application.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/friends")]
    public class FriendsController : Controller
    {
        private readonly ILogger<FriendsController> _logger;

        public FriendsController(ILogger<FriendsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get(
            [FromQuery] PaginationParameters paginationParameters,
            [FromServices] IGetPaginatedFriendsUseCase useCase)
        {
            return Ok(await useCase.Execute(paginationParameters));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(
        [FromRoute] int id,
        [FromServices] IGetFriendUseCase useCase)
        {
            var result = await useCase.Execute(id);
            
            if (result != null)
                return Ok(result);

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Post(
            FriendViewModel friend,
            [FromServices] ICreateFriendUseCase useCase)
        {
            var result = await useCase.ExecuteAsync(friend);
            return CreatedAtAction(nameof(Get), result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(
            [FromRoute] int id,
            [FromServices] IDeleteFriendUseCase useCase)
        {
            await useCase.Execute(id);
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch(
            [FromRoute] int id,
            [FromBody] FriendViewModel friend,
            [FromServices] IUpdateFriendUseCase useCase)
        {
            friend.Id = id;
            await useCase.Execute(friend);
            return Ok();
        }
    }
}

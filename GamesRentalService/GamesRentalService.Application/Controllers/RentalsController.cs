using GamesRentalService.Infrastructure.Models;
using GamesRentalService.Infrastructure.UseCases.Rentals.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GamesRentalService.Application.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/rentals")]
    public class RentalsController : Controller
    {
        [HttpPost]
        public async Task<ActionResult> Post(
        RentalViewModel rental,
        [FromServices] IRentGameUseCase useCase)
        {
            var result = await useCase.Execute(rental);

            if (result.Success)
                return Ok();

            return BadRequest(result.ErrorMessages);
        }
    }
}

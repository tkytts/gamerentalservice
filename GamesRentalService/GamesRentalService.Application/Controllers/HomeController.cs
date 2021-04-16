using GamesRentalService.Application.Services;
using GamesRentalService.Domain.Entities;
using GamesRentalService.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GamesRentalService.Application.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate(
            [FromBody] User model,
            [FromServices] IUserRepository userRepository,
            [FromServices] ITokenService tokenService)
        {
            // Recupera o usuário
            var user = userRepository.GetUser(model.Username, model.Password);

            // Verifica se o usuário existe
            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // Gera o Token
            var token = tokenService.GenerateToken(user);

            // Oculta a senha
            user.Password = "";

            // Retorna os dados
            return new
            {
                user = user,
                token = token
            };
        }
    }
}

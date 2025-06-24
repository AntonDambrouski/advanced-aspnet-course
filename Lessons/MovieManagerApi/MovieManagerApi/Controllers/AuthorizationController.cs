using Microsoft.AspNetCore.Mvc;
using MovieManager.Core.Interfaces;
using MovieManagerApi.DTOs;

namespace MovieManagerApi.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthorizationController(ITokensService tokensService) : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDTO loginDTO)
    {
        // Validate the user credentials (this is a placeholder, implement your own logic)
        var (token, expiration) = tokensService.GenerateAccessToken();

        return Ok(new
        {
            token,
            expiration,
        });
    }

}

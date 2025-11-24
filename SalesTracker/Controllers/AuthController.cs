using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel model)
    {
        // Простейшая проверка пользователя (замените на свою логику при необходимости)
        if (model.Username == "admin" && model.Password == "password")
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, model.Username)
            };

            // Ключ и параметры должны совпадать с настройками в Program.cs
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysuperlongsecretkeyforjwt1234567890"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "SalesTrackerIssuer",
                audience: "SalesTrackerAudience",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new { token = tokenString });
        }

        return Unauthorized();
    }
}

public class LoginModel
{
    public string Username { get; set; }
    public string Password { get; set; }
}
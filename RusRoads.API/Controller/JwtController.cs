using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RusRoads.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtController : ControllerBase
    {
        private readonly IConfiguration _config;

        public JwtController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public IActionResult GenerateToken()
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, "user") };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
            Console.WriteLine(key);

            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: _config["Jwt:Issuer"],
                    audience: _config["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(30)),
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));


            return Ok(new JwtSecurityTokenHandler().WriteToken(jwt));
        }
    }
}

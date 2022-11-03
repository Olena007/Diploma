using Application.Providers;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using WebApi.ModelsDTO;
using Domen.Models;
using Application.Services;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IClientProvider _clientProvider;
        private readonly JwtService _jwtService;

        public AuthController(IClientProvider client, JwtService jwtService)
        {
            _clientProvider = client;
            _jwtService = jwtService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetAll()
        {
            var getAll = await _clientProvider.GetAll();

            return getAll;
        }


        [HttpPost("register")]
        public ActionResult<Client> Register([FromBody] RegisterDto dto)
        {
            var d = new Client() {  Email = dto.Email, Password = BCrypt.Net.BCrypt.HashPassword(dto.Password) };
             _clientProvider.Create(d);

            return Ok(d);
        }
        
        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var client = _clientProvider.GetByEmail(dto.Email);

            if(client == null)
            {
                return BadRequest(new { message = "Invalid Operation" });
            }

            if(!BCrypt.Net.BCrypt.Verify(dto.Password, client.Password))
            {
                return BadRequest(new { message = "Invalid Operation" });
            }


            var jwt = _jwtService.Generate(client.ClientId);

            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true
            });




            return Ok(new { messege = "jwt is received"});
        }

        [HttpGet("client")]
        public IActionResult Client()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);

                int clientId = int.Parse(token.Issuer);

                var client = _clientProvider.GetById(clientId);

                return Ok(client);
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");

            return Ok(new
            {
                message = "logouted"
            });
        }


    }
}

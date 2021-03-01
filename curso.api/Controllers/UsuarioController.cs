using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using curso.api.Filters;
using curso.api.Models.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace curso.api.Controllers
{
    [Route("api/v1/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        [Route("logar")]
        [CustomModelStateValidation]
        public IActionResult Login(LoginViewModelInput loginViewModelInput)
        {
            var userViewModelOutput = new UserViewModelOutput()
            {
                Codigo = 1,
                Login = "danielfranca",
                Email = "daniel@dominio.com"
            };
            
            var secret = Encoding.ASCII.GetBytes("segredo");
            var symmetricSecurityKey = new SymmetricSecurityKey(secret);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userViewModelOutput.Codigo.ToString()),
                    new Claim(ClaimTypes.Name, userViewModelOutput.Login.ToString()),
                    new Claim(ClaimTypes.Email, userViewModelOutput.Email.ToString())
                }),

                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature),

            };

            var jwtSecurityTokenHadler = new JwtSecurityTokenHandler();
            var tokenGenerated = jwtSecurityTokenHadler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHadler.WriteToken(tokenGenerated);

            return Ok(new
            {
                Token = tokenGenerated,
                User = userViewModelOutput

            });
        }

        [HttpPost]
        [Route("registrar")]
        public IActionResult Register(RegisterViewModelInput registerViewModelInput)
        {
            return Created("", registerViewModelInput);
        }
        
    }
}
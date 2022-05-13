using Delivery.Application.Features.Commands.Authentications;
using Delivery.Application.Features.Queries.Authentications.GetUser;
using Delivery.Application.Models.Authentications;
using Delivery.Application.Settings.Authentications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly JwtSettings _jwtSettings;

        public AuthController(IMediator mediator,
            IOptionsSnapshot<JwtSettings> jwtSettings)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _jwtSettings = jwtSettings.Value;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpUserCommand signUpUserCommand)
        {
            var result = await _mediator.Send(signUpUserCommand);

            if (result != 0)
            {
                return Ok();
            }

            return BadRequest("User not created");
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(string email, string password)
        {
            var query = new GetUserByEmailAndPasswordQuery(email, password);
            var userModel = await _mediator.Send(query);

            if (userModel != null)
            {
                return Ok(GenerateJwt(userModel));
            }

            return BadRequest("Email or password incorrect.");
        }


        private string GenerateJwt(UserViewModel userModel)
        {
            var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, userModel.Id.ToString()),
                    new Claim(ClaimTypes.Name, userModel.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.NameIdentifier, userModel.Id.ToString())
                };

            var roleClaims = userModel.Roles.Select(r => new Claim(ClaimTypes.Role, r));
            claims.AddRange(roleClaims);

            //Security  Key'in alıyoruz.
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));

            //Şifrelenmiş kimliği oluşturuyoruz.
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //Bitiş Zamanını ayarlayabiliyoruz
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_jwtSettings.ExpirationInDays));

            // Oluşturulacak token ayarlarını veriyoruz.
             var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Issuer,
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

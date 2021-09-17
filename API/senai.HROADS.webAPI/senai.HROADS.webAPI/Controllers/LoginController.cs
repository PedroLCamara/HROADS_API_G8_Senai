using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.HROADS.webAPI.Domains;
using senai.HROADS.webAPI.Interfaces;
using senai.HROADS.webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai.HROADS.webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        IUsuarioRepository URepositorio;

        public LoginController()
        {
            URepositorio = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Logar(string Email, string Senha)
        {
            Usuario UsuarioBuscado = URepositorio.Logar(Email, Senha);

            try
            {
                if (UsuarioBuscado != null)
                {
                    var Claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Email, UsuarioBuscado.Email),
                        new Claim(ClaimTypes.Role, UsuarioBuscado.IdTipoUsuarioNavigation.TituloTipoUsuario),
                        new Claim(JwtRegisteredClaimNames.NameId, UsuarioBuscado.IdUsuario.ToString())
                    };
                    var Chave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("ChaveHROADSSeguranca"));
                    var Credenciais = new SigningCredentials(Chave, SecurityAlgorithms.HmacSha256);
                    var Token = new JwtSecurityToken
                    (
                        issuer: "senai.HROADS.webAPI",
                        audience: "senai.HROADS.webAPI",
                        claims: Claims,
                        expires: DateTime.Now.AddHours(1.5),
                        signingCredentials: Credenciais
                    );
                    return Ok(new JwtSecurityTokenHandler().WriteToken(Token));
                }
                else return NotFound("Email ou senha inválidos! Usuário não encontrado!!!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }
    }
}
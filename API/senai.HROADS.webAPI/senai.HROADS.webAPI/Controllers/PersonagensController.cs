using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.HROADS.webAPI.Domains;
using senai.HROADS.webAPI.Interfaces;
using senai.HROADS.webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace senai.HROADS.webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonagensController : ControllerBase
    {
        private IPersonagemRepository PRepositorio;
        public PersonagensController()
        {
            PRepositorio = new PersonagemRepository();
        }

        [HttpGet]
        [Authorize(Roles = "Jogador")]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(PRepositorio.LerTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }

        [HttpGet("{IdPersonagemBuscado}")]
        [Authorize(Roles = "Jogador, Administrador")]
        public IActionResult BuscarPorId(int IdPersonagemBuscado)
        {
            try
            {
                if (PRepositorio.BuscarPorId(IdPersonagemBuscado) != null)
                {
                    return Ok(PRepositorio.BuscarPorId(IdPersonagemBuscado));
                }
                else return NotFound("Id de personagem inválido!!!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }
        [HttpPost]
        [Authorize(Roles = "Jogador")]
        public IActionResult Cadastrar(Personagem NovoPersonagem)
        {
            try
            {
                NovoPersonagem.IdUsuario = Convert.ToInt32(User.Claims.Where(C => C.Type == JwtRegisteredClaimNames.NameId));
                PRepositorio.Cadastrar(NovoPersonagem);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }

        [HttpPut("{IdPersonagemAtualizado}")]
        [Authorize(Roles = "Jogador")]
        public IActionResult Atualizar(Personagem PersonagemAtualizado, int IdPersonagemAtualizado)
        {
            try
            {
                if (Convert.ToInt32(User.Claims.Where(C => C.Type == JwtRegisteredClaimNames.NameId)) != IdPersonagemAtualizado)
                {
                    return Unauthorized("Apenas o jogador que criou o personagem pode atualiza-lo!");
                }
                else
                {
                    PRepositorio.Atualizar(PersonagemAtualizado, IdPersonagemAtualizado);
                    return NoContent();
                }
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }

        [HttpDelete("{IdPersonagemDeletado}")]
        [Authorize(Roles = "Jogador")]
        public IActionResult Deletar(int IdPersonagemDeletado)
        {
            try
            {
                if (Convert.ToInt32(User.Claims.Where(C => C.Type == JwtRegisteredClaimNames.NameId)) != IdPersonagemDeletado)
                {
                    return Unauthorized("Apenas o jogador que criou o personagem pode deleta-lo!");
                }
                else
                {
                    PRepositorio.Deletar(IdPersonagemDeletado);
                    return NoContent();
                }
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }
    }
}

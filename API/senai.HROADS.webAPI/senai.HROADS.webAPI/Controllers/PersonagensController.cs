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
using System.Security.Claims;
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
        [Authorize(Roles = "Jogador, Administrador")]
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

        [HttpGet("ListarComJogadores")]
        [Authorize(Roles = "Administrador")]
        public IActionResult ListarComJogadores()
        {
            try
            {
                return Ok(PRepositorio.LerComJogador());
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
                List<Claim> ListaClaims = User.Claims.ToList();
                NovoPersonagem.IdUsuario = Convert.ToInt32(ListaClaims.Find(C => C.Type == ClaimTypes.NameIdentifier).Value);
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
                List<Claim> ListaClaims = User.Claims.ToList();
                if (Convert.ToInt32(ListaClaims.Find(C => C.Type == ClaimTypes.NameIdentifier).Value) != PRepositorio.BuscarPorId(IdPersonagemAtualizado).IdUsuario)
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
        [Authorize(Roles = "Jogador, Administrador")]
        public IActionResult Deletar(int IdPersonagemDeletado)
        {
            try
            {
                List<Claim> ListaClaims = User.Claims.ToList();
                if (ListaClaims.Find(C => C.Type == ClaimTypes.Role).Value.ToString() == "Jogador")
                {
                    if (Convert.ToInt32(ListaClaims.Find(C => C.Type == ClaimTypes.NameIdentifier)) != PRepositorio.BuscarPorId(IdPersonagemDeletado).IdUsuario)
                    {
                        return Unauthorized("Apenas o jogador que criou o personagem pode deleta-lo!");
                    }
                    else
                    {
                        PRepositorio.Deletar(IdPersonagemDeletado);
                        return NoContent();
                    }
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

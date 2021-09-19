using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.HROADS.webAPI.Domains;
using senai.HROADS.webAPI.Interfaces;
using senai.HROADS.webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.HROADS.webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        IUsuarioRepository URepositorio;

        public UsuariosController()
        {
            URepositorio = new UsuarioRepository();
        }

        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(URepositorio.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }

        [HttpGet("{IdUsuarioBuscado}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult BuscarPorId(int IdUsuarioBuscado) {
            try
            {
                if (URepositorio.BuscarPorId(IdUsuarioBuscado) != null)
                {
                    return Ok(URepositorio.BuscarPorId(IdUsuarioBuscado));
                }
                else return NotFound("Id de usuário não encontrado!!!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Cadastrar(Usuario NovoUsuario)
        {
            try
            {
                URepositorio.Cadastrar(NovoUsuario);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }

        [HttpPut("{IdUsuarioAtualizado}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Atualizar(Usuario UsuarioAtualizado, int IdUsuarioAtualizado)
        {
            try
            {
                URepositorio.Atualizar(UsuarioAtualizado, IdUsuarioAtualizado);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }

        [HttpDelete("{IdUsuarioDeletado}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Deletar(int IdUsuarioDeletado)
        {
            try
            {
                URepositorio.Deletar(IdUsuarioDeletado);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }
    }
}

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
    public class TiposUsuariosController : ControllerBase
    {
        ITipoUsuarioRepository TpURepositorio;

        public TiposUsuariosController()
        {
            TpURepositorio = new TipoUsuarioRepository();
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(TpURepositorio.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }
        [HttpGet("IdTpUsuarioBuscado")]
        public IActionResult BuscarPorId(int IdTpUsuarioBuscado)
        {
            try
            {
                if (TpURepositorio.BuscarPorId(IdTpUsuarioBuscado) != null)
                {
                    return Ok(TpURepositorio.BuscarPorId(IdTpUsuarioBuscado));
                }
                else return NotFound("Id não encontrado!!!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }
        [HttpPost]
        public IActionResult Cadastrar(TipoUsuario NovoTpUsuario)
        {
            try
            {
                TpURepositorio.Cadastrar(NovoTpUsuario);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
                throw;
            }
        }
        [HttpPut]
        public IActionResult 
    }
}

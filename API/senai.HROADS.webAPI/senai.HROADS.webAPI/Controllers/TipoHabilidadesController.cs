using Microsoft.AspNetCore.Authorization;
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

    public class TipoHabilidadesController : Controller
    {
        private ITipoHabilidadeRepository _tipoHabilidadeRepository { get; set; }

        public TipoHabilidadesController()
        {
            _tipoHabilidadeRepository = new TipoHabilidadeRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_tipoHabilidadeRepository.ListarTodos());
        }

        [HttpGet("{idTipoHabilidadeB}")]
        public IActionResult BuscarPorId(int idTipoHabilidadeB)
        {
            return Ok(_tipoHabilidadeRepository.BuscarPorId(idTipoHabilidadeB));
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Cadastrar(TipoHabilidade tipoHabilidadeC)
        {
            _tipoHabilidadeRepository.Cadastrar(tipoHabilidadeC);

            return StatusCode(201);
        }

        [HttpPut("{idTipoHabilidadeA}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Atualizar(int idTipoHabilidadeA, TipoHabilidade tipoHabilidadeA)
        {
            _tipoHabilidadeRepository.Atualizar(idTipoHabilidadeA, tipoHabilidadeA);

            return StatusCode(204);
        }

        [HttpDelete("{idTipoHabilidadeD}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Deletar(int idTipoHabilidadeD)
        {
            _tipoHabilidadeRepository.Deletar(idTipoHabilidadeD);

            return StatusCode(204);
        }

    }
}

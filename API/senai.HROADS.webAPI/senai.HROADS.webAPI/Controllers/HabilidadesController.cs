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
    public class HabilidadesController : Controller
    {
        private IHabilidadeRepository _habilidadeRepository { get; set; }

        public HabilidadesController()
        {
            _habilidadeRepository = new HabilidadeRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_habilidadeRepository.ListarTodos());
        }

        [HttpGet("{idHabilidadeB}")]
        public IActionResult BuscarPorId(int idHabilidadeB)
        {
            return Ok(_habilidadeRepository.BuscarPorId(idHabilidadeB));
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Cadastrar(Habilidade idHabilidadeC)
        {
            _habilidadeRepository.Cadastrar(idHabilidadeC);

            return StatusCode(201);
        }

        [HttpPut("{idHabilidadeA}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Atualizar(int idHabilidadeA, Habilidade novaHabilidadeA)
        {
            _habilidadeRepository.Atualizar(idHabilidadeA, novaHabilidadeA);

            return StatusCode(204);
        }

        [HttpDelete("{idHabilidadeD}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Deletar(int idHabilidadeD)
        {
            _habilidadeRepository.Deletar(idHabilidadeD);

            return StatusCode(204);
        }
    }
}

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

    public class ClassesController : Controller
    {
        private IClasseRepository _classeRepository { get; set; }

        public ClassesController()
        {
            _classeRepository = new ClasseRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_classeRepository.ListarTodos());
        }

        [HttpGet("{idClasseB}")]
        public IActionResult BuscarPorId(int idClasseB)
        {
            return Ok(_classeRepository.BuscarPorId(idClasseB));
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Cadastrar(Classe novaClasse)
        {
            _classeRepository.Cadastrar(novaClasse);

            return StatusCode(201);
        }

        [HttpPut("{idClasseA}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Atualizar(int idClasseA, Classe novaClasseA)
        {
            _classeRepository.Atualizar(novaClasseA, idClasseA);

            return StatusCode(204);
        }

        [HttpDelete("{idClasseD}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Deletar(int idClasseD)
        {
            _classeRepository.Deletar(idClasseD);

            return StatusCode(204);
        }
    }
}

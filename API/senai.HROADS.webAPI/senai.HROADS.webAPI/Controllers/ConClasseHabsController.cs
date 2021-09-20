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

    public class ConClasseHabsController : Controller
    {
        private IConClasseHabRepository _conClasseHabepository { get; set; }

        public ConClasseHabsController()
        {
            _conClasseHabepository = new ConClasseHabRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_conClasseHabepository.ListarTodos());
        }

        [HttpGet("{idClasseHabB}")]
        public IActionResult BuscarPorId(int idClasseHabB)
        {
            return Ok(_conClasseHabepository.BuscarPorId(idClasseHabB));
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Cadastrar(ConClasseHab novaConClasseHab)
        {
            _conClasseHabepository.Cadastrar(novaConClasseHab);

            return StatusCode(201);
        }

        [HttpPut("{idClasseHabA}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Atualizar(int idClasseHabA, ConClasseHab novaConClasseHabA)
        {
            _conClasseHabepository.Atualizar(idClasseHabA, novaConClasseHabA);

            return StatusCode(204);
        }

        [HttpDelete("{idClasseHabD}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Deletar(int idClasseHabD)
        {
            _conClasseHabepository.Deletar(idClasseHabD);

            return StatusCode(204);
        }
    }
}

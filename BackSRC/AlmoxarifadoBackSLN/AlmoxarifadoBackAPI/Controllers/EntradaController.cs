using AlmoxarifadoBackAPI.DTO;
using AlmoxarifadoBackAPI.Models;
using AlmoxarifadoBackAPI.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlmoxarifadoBackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntradaController : ControllerBase
    {
        private readonly IEntradaRepositorio _db;
        public EntradaController(IEntradaRepositorio db)
        {
            _db = db;

        }

        [HttpGet("/lista")]
        public IActionResult listaEntrada()
        {
            return Ok(_db.GetAll());
        }

        [HttpPost("/entrada")]
        public IActionResult listaEntrada(EntradaDTO entrada)
        {
            return Ok(_db.GetAll().Where(x => x.Codigo == entrada.Codigo));
        }

        [HttpPost("/criarentrada")]
        public IActionResult criarentrada(EntradaCadastroDTO entrada)
        {

            var novaEntrada = new Entrada()
            {
                Descricao = entrada.Descricao,
                Dataentrada = entrada.Dataentrada,
                CodigoFornecedor = entrada.CodigoFornecedor

            };
            //_categorias.Add(novaCategoria);
            _db.Add(novaEntrada);
            return Ok("Cadastro com Sucesso");
        }

    }
}

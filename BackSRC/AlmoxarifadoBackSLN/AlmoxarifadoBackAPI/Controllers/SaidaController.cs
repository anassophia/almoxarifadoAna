using AlmoxarifadoBackAPI.DTO;
using AlmoxarifadoBackAPI.Models;
using AlmoxarifadoBackAPI.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlmoxarifadoBackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaidaController : ControllerBase
    {
        private readonly ISaidaRepositorio _db;
        public SaidaController(ISaidaRepositorio db)
        {
            _db = db;

        }

        [HttpGet("/lista")]
        public IActionResult listaSaida()
        {
            return Ok(_db.GetAll());
        }

        [HttpPost("/saida")]
        public IActionResult listaSaida(SaidaDTO saida)
        {
            return Ok(_db.GetAll().Where(x => x.Codigo == saida.Codigo));
        }

        [HttpPost("/criarsaida")]
        public IActionResult criarsaida(SaidaCadastroDTO saida)
        {

            var novaSaida = new Saida()
            {
                Descricao = saida.Descricao,
                DataSaida = saida.DataSaida,
                CodigoSecretaria = saida.CodigoSecretaria
            };
            //_categorias.Add(novaCategoria);
            _db.Add(novaSaida);
            return Ok("Cadastro com Sucesso");
        }

    }
}

using AlmoxarifadoBackAPI.DTO;
using AlmoxarifadoBackAPI.Models;
using AlmoxarifadoBackAPI.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlmoxarifadoBackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecretariaController : ControllerBase
    {
        private readonly ISecretariaRepositorio _db;
        public SecretariaController(ISecretariaRepositorio db)
        {
            _db = db;

        }

        [HttpGet("/listasecretaria")]
        public IActionResult listaSecretaria()
        {
            return Ok(_db.GetAll());
        }

        [HttpPost("/secretaria")]
        public IActionResult listaSecretaria(SecretariaDTO secretaria)
        {
            return Ok(_db.GetAll().Where(x => x.Codigo == secretaria.Codigo));
        }

        [HttpPost("/criarsecretaria")]
        public IActionResult criarsecretaria(SecretariaCadastroDTO secretaria)
        {

            var novaSecretaria = new Secretaria()
            {
                Nome = secretaria.Nome,
                Telefone = secretaria.Telefone,
                Estado = secretaria.Estado,
                Cidade = secretaria.Cidade,
                CNPJ = secretaria.CNPJ

            };
            //_categorias.Add(novaCategoria);
            _db.Add(novaSecretaria);
            return Ok("Cadastro com Sucesso");
        }
    }
}
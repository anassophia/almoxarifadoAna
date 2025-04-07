using AlmoxafiradoFront.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace AlmoxafiradoFront.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            var url = "https://localhost:7112/listaproduto";
            List<ProdutoDTO> produto = new List<ProdutoDTO>();
            using HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
                string json = response.Content.ReadAsStringAsync().Result;
                produto = JsonSerializer.Deserialize<List<ProdutoDTO>>(json);
                ViewBag.Produto = produto;


            }
            catch (Exception)
            {
                return View();

            }

            return View();
        }
        [HttpGet]
        public IActionResult Creater()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Produto(string descricao)
        {
            var url = "https://localhost:7112/criarproduto";

            using HttpClient client = new HttpClient();
            try
            {
                var produtoNovo = new ProdutoNovoDTO { descricao = descricao };
                var produtoSerializado = JsonSerializer.Serialize<ProdutoNovoDTO>(produtoNovo);
                var jsonContent = new StringContent(produtoSerializado, Encoding.UTF8, "aplication/json");

                HttpResponseMessage response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();

            }

            catch (Exception)
            {
                return View();

            }
            return RedirectToAction("Index");

        }
    }
}

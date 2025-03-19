using AlmoxafiradoFront.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AlmoxafiradoFront.Controllers
{
    public class EntradaController : Controller
    {
        public IActionResult Index()
        {
            var url = "https://localhost:7112/listaentrada\r\n";
            List<EntradaDTO> entrada = new List<EntradaDTO>();
            using HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
                string json = response.Content.ReadAsStringAsync().Result;
                entrada = JsonSerializer.Deserialize<List<EntradaDTO>>(json);
                ViewBag.Entradas = entrada;


            }
            catch (Exception)
            {
                return View();

            }

            return View();
        }
    }
}

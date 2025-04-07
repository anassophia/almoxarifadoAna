using AlmoxafiradoFront.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
using System.Text;

namespace AlmoxafiradoFront.Controllers
{
    public class CategoriaController : Controller
    {
        public  IActionResult Index()
        {
            var url = "https://localhost:7112/listacategoria";
            List <CategoriaDTO> categoria = new List < CategoriaDTO> ();
            using HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response =  client.GetAsync(url).Result ;
                response.EnsureSuccessStatusCode();
                string json =  response.Content.ReadAsStringAsync().Result;
                 categoria = JsonSerializer.Deserialize<List<CategoriaDTO>>(json);
                 ViewBag.Categorias = categoria;


            }
            catch (Exception)
            {
                return View();
                
            }

            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(string descricao)
        {
            var url = "https://localhost:7112/criarcategoria";

            using HttpClient client = new HttpClient();
            try
            {
                var categoriaNova = new CategoriaNovaDTO { descricao = descricao };
                var categoriaSerializada = JsonSerializer.Serialize<CategoriaNovaDTO>(categoriaNova);
                var jsonContent = new StringContent(categoriaSerializada, Encoding.UTF8, "aplication/json");

                HttpResponseMessage response = client.PostAsync(url, jsonContent).Result;
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

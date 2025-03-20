using AlmoxafiradoFront.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;

namespace AlmoxafiradoFront.Controllers
{
    public class CategoriaController : Controller
    {
        public  IActionResult Index()
        {
            var url = "https://localhost:7112/listacategoria\r\n";
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
    }
}

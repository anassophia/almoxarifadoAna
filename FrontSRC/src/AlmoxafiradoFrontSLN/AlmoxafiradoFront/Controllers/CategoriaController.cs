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
            var url = "http://localhost:5070/lista";
            List <CategoriaDTO> categoria = new List < CategoriaDTO> ();
            using HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response =  client.GetAsync(url).Result ;
                response.EnsureSuccessStatusCode();
                string json =  response.Content.ReadAsStringAsync().Result;
                 categoria = JsonSerializer.Deserialize<List<CategoriaDTO>>(json);
                 ViewBag.Categoria = categoria;


            }
            catch (Exception)
            {
                return View();
                
            }

            return View();
        }
    }
}

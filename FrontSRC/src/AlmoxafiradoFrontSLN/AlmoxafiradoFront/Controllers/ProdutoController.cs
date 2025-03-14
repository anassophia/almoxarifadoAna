﻿using AlmoxafiradoFront.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AlmoxafiradoFront.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            var url = "http://localhost:5070/lista";
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
    }
}

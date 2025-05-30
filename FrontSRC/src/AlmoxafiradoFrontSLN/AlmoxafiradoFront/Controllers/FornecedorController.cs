﻿using AlmoxafiradoFront.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AlmoxafiradoFront.Controllers
{
    public class FornecedorController : Controller
    {
        public IActionResult Index()
        {
            var url = "https://localhost:7112/listafornecedor ";
            List<FornecedorDTO> fornecedor = new List<FornecedorDTO>();
            using HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
                string json = response.Content.ReadAsStringAsync().Result;
                fornecedor = JsonSerializer.Deserialize<List<FornecedorDTO>>(json);
                ViewBag.Categoria = fornecedor;


            }
            catch (Exception)
            {
                return View();

            }

            return View();
        }
    }
}

﻿using AlmoxafiradoFront.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AlmoxafiradoFront.Controllers
{
    public class SecretariaController : Controller
    {
        public IActionResult Index()
        {
            var url = "http://localhost:5070/lista";
            List<SecretariaDTO> secretaria = new List<SecretariaDTO>();
            using HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
                string json = response.Content.ReadAsStringAsync().Result;
                secretaria = JsonSerializer.Deserialize<List<SecretariaDTO>>(json);
                ViewBag.Secretaria = secretaria;


            }
            catch (Exception)
            {
                return View();

            }

            return View();
        }
    }
}

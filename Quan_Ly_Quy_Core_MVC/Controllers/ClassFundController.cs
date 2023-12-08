using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Quan_Ly_Quy_Core_MVC.Models;

namespace Quan_Ly_Quy_Core_MVC.Controllers
{
    public class ClassFundController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public ClassFundController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiUrl = configuration["http://localhost:5077"];
        }

        // GET: ClassFund
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync(_apiUrl + "/classfund");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var classFunds = JsonConvert.DeserializeObject<List<ClassFund>>(content);
                return View(classFunds);
            }
            else
            {
                return View(new List<ClassFund>());
            }
        }

        // GET: ClassFund/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _httpClient.GetAsync(_apiUrl + "/classfund/" + id);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var classFund = JsonConvert.DeserializeObject<ClassFund>(content);
                return View(classFund);
            }
            else
            {
                return NotFound();
            }
        }
    }
}

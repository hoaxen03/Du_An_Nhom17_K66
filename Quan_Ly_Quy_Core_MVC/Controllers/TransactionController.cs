using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Quan_Ly_Quy_Core_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
// Transaction : giao dịch
namespace Quan_Ly_Quy_Core_MVC.Controllers
{
    public class TransactionController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public TransactionController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiUrl = configuration["ApiUrl"];
        }

        // GET: Transaction
        public async Task<IActionResult> Index(int? classFundId)
        {
            if (classFundId == null)
            {
                return NotFound();
            }

            var response = await _httpClient.GetAsync(_apiUrl + "/transaction?classFundId=" + classFundId);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var transactions = JsonConvert.DeserializeObject<List<Transaction>>(content);
                return View(transactions);
            }
            else
            {
                return View(new List<Transaction>());
            }
        }

        // GET: Transaction/Create
        public IActionResult Create(int? classFundId)
        {
            if (classFundId == null)
            {
                return NotFound();
            }

            var transaction = new Transaction { ClassFundId = classFundId.Value };
            return View(transaction);
        }

        // POST: Transaction/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Description,Amount,IsIncome,ClassFundId")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                transaction.Date = DateTime.Now;
                var json = JsonConvert.SerializeObject(transaction);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(_apiUrl + "/transaction", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index), new { classFundId = transaction.ClassFundId });
                }
                else
                {
                    return View(transaction);
                }
            }
            return View(transaction);
        }

        // GET: Transaction/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _httpClient.GetAsync(_apiUrl + "/transaction/" + id);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var transaction = JsonConvert.DeserializeObject<Transaction>(content);
                return View(transaction);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: Transaction/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,Amount,IsIncome,Date,ClassFundId")] Transaction transaction)
        {
            if (id != transaction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(transaction);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync(_apiUrl + "/transaction/" + id, content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index), new { classFundId = transaction.ClassFundId });
                }
                else
                {
                    return View(transaction);
                }
            }
            return View(transaction);
        }

        // GET: Transaction/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _httpClient.GetAsync(_apiUrl + "/transaction/" + id);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var transaction = JsonConvert.DeserializeObject<Transaction>(content);
                return View(transaction);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _httpClient.DeleteAsync(_apiUrl + "/transaction/" + id);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var transaction = JsonConvert.DeserializeObject<Transaction>(content);
                return RedirectToAction(nameof(Index), new { classFundId = transaction.ClassFundId });
            }
            else
            {
                return NotFound();
            }
        }
    }
}

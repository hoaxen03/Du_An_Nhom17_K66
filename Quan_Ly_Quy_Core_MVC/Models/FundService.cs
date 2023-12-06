using Microsoft.AspNetCore.Mvc;

namespace Quan_Ly_Quy_Core_MVC.Models
{

    public class FundService : IFundService
    {
        private readonly HttpClient _httpClient;

        public FundService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<decimal> GetBalanceAsync()
        {
            var response = await _httpClient.GetAsync("/api/student");
            response.EnsureSuccessStatusCode();
            var balance = await response.Content.ReadAsAsync<decimal>();
            return balance;
        }
    }

}
using System;
using System.ComponentModel.DataAnnotations;
using Quan_Ly_Quy_Core_MVC.Models;
using Quan_Ly_Quy_Core_API.Models;
namespace Quan_Ly_Quy_Core_MVC.Models
{

    public class Transaction
    {   
        
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public bool IsIncome { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int ClassFundId { get; set; }
        public KhoanChi ClassFund { get; set; }
    
    }
}

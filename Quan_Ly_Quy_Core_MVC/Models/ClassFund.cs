using System;
using System.ComponentModel.DataAnnotations;

namespace Quan_Ly_Quy_Core_MVC.Models
{
    public class ClassFund
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Balance { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
    }
}

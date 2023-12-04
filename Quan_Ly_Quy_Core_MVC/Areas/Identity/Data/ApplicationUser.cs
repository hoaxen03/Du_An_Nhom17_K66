using System;
using System.Collections.Generic; // Add
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Quan_Ly_Quy_Core_MVC.Areas.Identity;

namespace Quan_Ly_Quy_Core_MVC.Areas.Identity.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

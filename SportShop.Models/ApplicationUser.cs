using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportShop.Models
{
    public class ApplicationUser : IdentityUser
    {
        [DisplayName("First Name")]
        [MaxLength(100)]
        public string? FirstName { get; set; }
        [DisplayName("Last Name")]
        [MaxLength(100)]
        public string? LastName { get; set; }
        public string? UserImage { get; set; }
    }
}

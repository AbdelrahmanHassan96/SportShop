using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportShop.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="inter Name of Category")]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required(ErrorMessage = "inter priority")]
        [Range(1,10)]
        public int Priority { get; set; }
        public string? Description { get; set; }
        public string? CategoryImage { get; set; }
    }
}

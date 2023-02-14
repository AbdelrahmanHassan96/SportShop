using Microsoft.AspNetCore.Mvc.Rendering;
using SportShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportShop.DataAccess.ViewModels
{
    public class ProductVm
    {
        public IEnumerable<Product> products { get; set; }= new List<Product>();
        public Product product { get; set; } = new Product();
        public IEnumerable<SelectListItem>? categories { get; set; }
    }
}

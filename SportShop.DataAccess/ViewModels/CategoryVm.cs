using SportShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportShop.DataAccess.ViewModels
{
    public class CategoryVm
    {
        public IEnumerable<Category> categories { get; set; } = new List<Category>();
        public Category category { get; set; } = new Category();
    }
}

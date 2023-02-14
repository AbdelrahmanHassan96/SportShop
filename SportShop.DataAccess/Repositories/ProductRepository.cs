using SportShop.DataAccess.Data;
using SportShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportShop.DataAccess.Repositories
{
    public class ProductRepository : BaseRepository<Product>
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

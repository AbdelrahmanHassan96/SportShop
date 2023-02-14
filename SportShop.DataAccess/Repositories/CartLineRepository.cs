using SportShop.DataAccess.Data;
using SportShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportShop.DataAccess.Repositories
{
    public class CartLineRepository : BaseRepository<CartLine>
    {
        public CartLineRepository( ApplicationDbContext context) : base(context)
        {
        }
    }
}

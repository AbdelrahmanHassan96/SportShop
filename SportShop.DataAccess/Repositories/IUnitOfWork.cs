using SportShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportShop.DataAccess.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Category> category { get; }
        IBaseRepository<Product> product { get; }
        IBaseRepository<Cart> cart { get; }
        IBaseRepository<CartLine> cartLine { get; }
        void Save();
    }
}

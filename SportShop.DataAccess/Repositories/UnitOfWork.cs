using SportShop.DataAccess.Data;
using SportShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportShop.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IBaseRepository<Category> category { get; private set; }
        public IBaseRepository<Product> product { get; private set; }
        public IBaseRepository<Cart> cart { get; private set; }
        public IBaseRepository<CartLine> cartLine { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            category = new BaseRepository<Category>(_context);
            product = new BaseRepository<Product>(_context);
            cart = new BaseRepository<Cart>(_context);
            cartLine = new BaseRepository<CartLine>(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

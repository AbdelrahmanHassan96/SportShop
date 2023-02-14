using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SportShop.DataAccess.Data;
using SportShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportShop.DataAccess.Repositories
{
    public class CartRepository : BaseRepository<Cart>
    {
        private readonly ApplicationDbContext _context;
        public CartRepository(ApplicationDbContext context) : base(context)
        {
        }

        //public static Cart GetCart(IServiceProvider services)
        //{
        //    ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
        //    var context = services.GetService<ApplicationDbContext>();
        //    string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

        //    session.SetString("CartId", cartId);
        //    return new Cart(context) { Id = cartId };
        //}
        
        //public bool AddToCart(Product product,int quantity =1)
        //{
        //    if (product.UnitsInStock == 0 || quantity == 0)
        //    {
        //        return false;
        //    }
        //    var CartLine = _context.CartLines.FirstOrDefault(p => p.Product.Id == product.Id);
        //    var isValidAmount = true;

        //    if (CartLine == null)
        //    {
        //        if(product.UnitsInStock < quantity)
        //        {
        //            isValidAmount = false;
        //        }

                
        //        CartLine cartLine = new CartLine()
        //        {
                   
        //        };
        //    }

        //}
    }
}

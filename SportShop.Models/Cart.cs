using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportShop.Models
{
    public class Cart
    {
        #region Attribute
        [Key]
        public int Id { get; set; }
        [Column("UserId")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        
        public IList<CartLine>? CartLines { get; set; } = new List<CartLine> ();

        public int? Count { get; set; }
        public decimal Total { get; set; }

        #endregion

        

        #region Functions

        // public bool AddToCart(Cart cart,Product product, int quantity = 1)
        // {

        //    if (product.UnitsInStock == 0 || quantity == 0)
        //    {
        //        return false;
        //    }
        //    var CartLine = CartLines.FirstOrDefault(p => p.Product.Id == product.Id && p.CartId==cart.Id);
        //    var isValidAmount = true;

        //    if (CartLine == null)
        //    {
        //        if (product.UnitsInStock < quantity)
        //        {
        //            isValidAmount = false;
        //        }


        //        CartLine cartLine = new CartLine()
        //        {
        //            Id = Guid.NewGuid().ToString(),
        //            Quantity = quantity,
        //            Product = product,
        //        };
        //        cart.CartLines.Add(cartLine);
        //    }
        //    else
        //    {
        //        if (product.UnitsInStock - CartLine.Quantity - quantity >= 0)
        //        {
        //            CartLine.Quantity += quantity;
        //        }
        //        else
        //        {
        //            CartLine.Quantity += (product.UnitsInStock - CartLine.Quantity);
        //            isValidAmount = false;
        //        }
        //    }

        //    return isValidAmount;
        //}

        #endregion



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportShop.Models
{
    public class CartWithLogic
    {


        private List<CartLine> cartLines = new List<CartLine>();
        public void AddItem (Product product , int quantity = 1)
        {
            CartLine line = cartLines.FirstOrDefault(p =>p.Product.Id == product.Id);
            if(line == null)
            {
                cartLines.Add(new CartLine { Product=product,Quantity=quantity});
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public void RemoveItem(Product product)
        {
            cartLines.RemoveAll(p=>p.Product.Id==product.Id);
        }

        public decimal ComputeTotalValue()
        {
            return cartLines.Sum(p => p.Product.UnitPrice * p.Quantity);
        }

        public void Clear()
        {
            cartLines.Clear();
        }

        public IEnumerable<CartLine> lines
        {
            get { return cartLines; }
        }
    }
}

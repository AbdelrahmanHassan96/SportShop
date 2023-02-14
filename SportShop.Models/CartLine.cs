using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportShop.Models
{
    public class CartLine
    {
        [Key]
        public int Id { get; set; }
        public int CartId { get; set; }
        public Cart cart { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal LinePrice { get; set; }
    }
}

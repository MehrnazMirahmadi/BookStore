using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entities
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int BookId { get; set; } 
        public int OrderId { get; set; }  
        public int Quantity { get; set; }
        public double Price { get; set; }
    }

}

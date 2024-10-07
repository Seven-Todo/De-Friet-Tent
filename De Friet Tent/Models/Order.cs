using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De_Friet_Tent.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public List<Product>? Products { get; set; }
        public Status? Status { get; set; }
        public int StatusId { get; set; }
        public decimal Totalprice { get; set; }
    }
}

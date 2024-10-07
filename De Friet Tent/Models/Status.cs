using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De_Friet_Tent.Models
{
    public class Status
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public Status()
        {
            Order order = new Order();
        }

        public IList<Order>? Orders { get; set; }
    }
}

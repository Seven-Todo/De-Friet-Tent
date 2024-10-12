using System.ComponentModel.DataAnnotations;

namespace De_Friet_Tent.Models
{
    public class ProductRevenueViewModel
    {
        [DataType(DataType.Text), StringLength(25)]
        public string? ProductName { get; set; }

        [DataType(DataType.Currency)]
        public decimal Revenue { get; set; }
    }
}

namespace De_Friet_Tent.Models
{
    public class OrderProductViewModel
    {
        public Order Order { get; set; }

        public IList<Product>? Products { get; set; }

        public IList<int>? SelectedProducts { get; set; }
    }
}

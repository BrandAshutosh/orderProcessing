using System.Collections.Generic;

namespace OrderProcessing.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ? Name { get; set; }
        public decimal Price { get; set; }
        public ICollection<OrderProduct> ? OrderProducts { get; set; }
    }
}
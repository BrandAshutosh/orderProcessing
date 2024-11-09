using System.Collections.Generic;

namespace OrderProcessing.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public bool IsFulfilled {get; set;}
        public decimal TotalPrice {get; set;}
        public Customer ? Customer { get; set; }
        public ICollection<OrderProduct> ? OrderProducts { get; set; } 
    }
}
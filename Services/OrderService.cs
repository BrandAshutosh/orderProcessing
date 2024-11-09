using OrderProcessing.Models;
using OrderProcessing.Repositories;

namespace OrderProcessing.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICustomerRepository _customerRepository;

        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository, ICustomerRepository customerRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _customerRepository = customerRepository;
        }

        public async Task<Order> CreateOrderAsync(int customerId, List<int> productIds)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(customerId);
            if (customer == null) throw new ArgumentException("Customer not found.");

            var products = new List<Product>();
            foreach (var productId in productIds)
            {
                var product = await _productRepository.GetProductByIdAsync(productId);
                if (product == null) throw new ArgumentException($"Product {productId} not found.");
                products.Add(product);
            }

            var order = new Order
            {
                CustomerId = customerId,
                IsFulfilled = false,
                OrderProducts = products.Select(p => new OrderProduct { Product = p }).ToList()
            };

            await _orderRepository.CreateOrderAsync(order);
            return order;
        }

        public async Task<decimal> GetTotalPriceAsync(int orderId)
        {
            var order = await _orderRepository.GetOrderByIdAsync(orderId);
            if (order == null) throw new ArgumentException("Order not found.");
            return order.TotalPrice;
        }
    }
}
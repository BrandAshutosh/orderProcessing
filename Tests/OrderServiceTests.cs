using Moq;
using OrderProcessing.Models;
using OrderProcessing.Repositories;
using OrderProcessing.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace OrderProcessing.Tests
{
    public class OrderServiceTests
    {
        private readonly Mock<IOrderRepository> _mockOrderRepository;
        private readonly Mock<IProductRepository> _mockProductRepository;
        private readonly Mock<ICustomerRepository> _mockCustomerRepository;
        private readonly OrderService _orderService;

        public OrderServiceTests()
        {
            _mockOrderRepository = new Mock<IOrderRepository>();
            _mockProductRepository = new Mock<IProductRepository>();
            _mockCustomerRepository = new Mock<ICustomerRepository>();
            _orderService = new OrderService(_mockOrderRepository.Object, _mockProductRepository.Object, _mockCustomerRepository.Object);
        }

        [Fact]
        public async Task CreateOrder_ShouldReturnOrder()
        {
            var customer = new Customer { Id = 1, Name = "John" };
            var product = new Product { Id = 1, Name = "Product A", Price = 100 };

            _mockCustomerRepository.Setup(repo => repo.GetCustomerByIdAsync(1)).ReturnsAsync(customer);
            _mockProductRepository.Setup(repo => repo.GetProductByIdAsync(1)).ReturnsAsync(product);

            var productIds = new List<int> { 1 };

            var order = await _orderService.CreateOrderAsync(1, productIds);

            Assert.NotNull(order);
            Assert.Equal(1, order.CustomerId);
            Assert.Single(order.OrderProducts); 

            var orderProduct = order.OrderProducts.ToList()[0]; 
            Assert.Equal(1, orderProduct.ProductId); 
           
            _mockCustomerRepository.Verify(repo => repo.GetCustomerByIdAsync(1), Times.Once);
            _mockProductRepository.Verify(repo => repo.GetProductByIdAsync(1), Times.Once);
        }
    }
}
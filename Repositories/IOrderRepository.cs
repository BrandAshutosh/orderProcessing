using OrderProcessing.Models;

namespace OrderProcessing.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderByIdAsync(int id);
        Task CreateOrderAsync(Order order);
    }
}
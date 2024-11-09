using OrderProcessing.Models;

namespace OrderProcessing.Services
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(int customerId, List<int> productIds);
        Task<decimal> GetTotalPriceAsync(int orderId);
    }
}
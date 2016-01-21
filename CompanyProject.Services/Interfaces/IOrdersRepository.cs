using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyProject.Models;

namespace CompanyProject.Services.Interfaces
{
    public interface IOrdersRepository
    {
        List<Order> GetOrdersForCustomers(Guid customerId);
        List<Order> GetAllOrders();
        Order AddOrder(Order order);
        Order UpdateOrder(Order order);
        void DeleteOrder(int orderId);

        List<Product> GetProducts();
        List<ProductOption> GetProductOptions();
        List<ProductSize> GetProductSizes();
        List<OrderStatus> GetOrderStatuses();
    }
}

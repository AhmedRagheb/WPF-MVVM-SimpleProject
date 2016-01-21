using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using CompanyProject.Data;
using CompanyProject.Models;
using CompanyProject.Services.Interfaces;

namespace CompanyProject.Services
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly ICompanyContext _context;
        public OrdersRepository(ICompanyContext companyContext)
        {
            _context = companyContext;
        }


        public List<Order> GetOrdersForCustomers(Guid customerId)
        {
            return  _context.Orders.Where(o => o.CustomerId == customerId).ToList();
        }

        public List<Order> GetAllOrders()
        {
            return  _context.Orders.ToList();
        }

        public Order AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order;
        }

        public Order UpdateOrder(Order order)
        {
            if (_context.Orders.Local.All(o => o.Id != order.Id))
            {
                _context.Orders.Attach(order);
            }
            //_context.Entry(order).State = EntityState.Modified;
            _context.SaveChanges();
            return order;
        }

        public  void DeleteOrder(int orderId)
        {
            using (var scope = new TransactionScope())
            {
                var order = _context.Orders.Include("OrderItems").Include("OrderItems.OrderItemOptions").FirstOrDefault(o => o.Id == orderId);
                if (order != null)
                {
                    foreach (OrderItem item in order.OrderItems)
                    {
                        foreach (var orderItemOption in item.Options)
                        {
                            _context.OrderItemOptions.Remove(orderItemOption);
                        }
                        _context.OrderItems.Remove(item);
                    }
                    _context.Orders.Remove(order);
                }
                _context.SaveChanges();
                scope.Complete();
            }
        }


        public List<Product> GetProducts()
        {
            return  _context.Products.ToList();
        }

        public List<ProductOption> GetProductOptions()
        {
            return  _context.ProductOptions.ToList();
        }

        public List<ProductSize> GetProductSizes()
        {
            return  _context.ProductSizes.ToList();
        }

        public List<OrderStatus> GetOrderStatuses()
        {
            return  _context.OrderStatuses.ToList();
        }
    }
}

using System.Data.Entity;
using CompanyProject.Models;

namespace CompanyProject.Data
{
    public interface ICompanyContext
    {
        int SaveChanges();
        IDbSet<Employee> Employees { get; set; }
        IDbSet<Customer> Customers { get; set; }
        IDbSet<Order> Orders { get; set; }
        IDbSet<Product> Products { get; set; }
        IDbSet<OrderItem> OrderItems { get; set; }
        IDbSet<OrderItemOption> OrderItemOptions { get; set; }
        IDbSet<ProductOption> ProductOptions { get; set; }
        IDbSet<ProductSize> ProductSizes { get; set; }
        IDbSet<OrderStatus> OrderStatuses { get; set; }

    }
}

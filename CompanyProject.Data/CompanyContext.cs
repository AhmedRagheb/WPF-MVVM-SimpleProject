using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using CompanyProject.Models;

namespace CompanyProject.Data
{
    public class CompanyContext : DbContext, ICompanyContext
    {
        public CompanyContext(string connectionStringName)
            : base(connectionStringName)
        {
            base.Database.Initialize(false);
        }

        public IDbSet<Employee> Employees { get; set; }
        public IDbSet<Customer> Customers { get; set; }
        public IDbSet<Order> Orders { get; set; }
        public IDbSet<Product> Products { get; set; }
        public IDbSet<OrderItem> OrderItems { get; set; }
        public IDbSet<OrderItemOption> OrderItemOptions { get; set; }
        public IDbSet<ProductOption> ProductOptions { get; set; }
        public IDbSet<ProductSize> ProductSizes { get; set; }
        public IDbSet<OrderStatus> OrderStatuses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Table names match entity names by default (don't pluralize)
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // Globally disable the convention for cascading deletes
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Customer>()
                        .Property(c => c.Id) // Client must set the ID.
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}

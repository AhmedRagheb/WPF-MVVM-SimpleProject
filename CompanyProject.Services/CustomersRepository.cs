using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using CompanyProject.Data;
using CompanyProject.Models;
using CompanyProject.Services.Interfaces;

namespace CompanyProject.Services
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly ICompanyContext _context;
        public CustomersRepository(ICompanyContext companyContext)
        {
            _context = companyContext;
        }

        public List<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        public Customer GetCustomer(Guid id)
        {
            return _context.Customers.FirstOrDefault(c => c.Id == id);
        }

        public  Customer AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        public  Customer UpdateCustomer(Customer customer)
        {
            if (_context.Customers.Local.All(c => c.Id != customer.Id))
            {
                _context.Customers.Attach(customer);
            }
            //_context.Entry(customer).State = EntityState.Modified;
            
            _context.SaveChanges();
            return customer;

        }

        public void DeleteCustomer(Guid customerId)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Id == customerId);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
            }
            _context.SaveChanges();
        }
    }
}

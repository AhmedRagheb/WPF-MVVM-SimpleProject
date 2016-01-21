using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyProject.Models;

namespace CompanyProject.Services.Interfaces
{
    public interface ICustomersRepository
    {
        List<Customer> GetCustomers();
        Customer GetCustomer(Guid id);
        Customer AddCustomer(Customer customer);
        Customer UpdateCustomer(Customer customer);
        void DeleteCustomer(Guid customerId);
    }
}

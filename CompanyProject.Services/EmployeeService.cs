using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using CompanyProject.Data;
using CompanyProject.Models;
using CompanyProject.Services.Interfaces;

namespace CompanyProject.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ICompanyContext _companyContext;
        public EmployeeService(ICompanyContext companyContext)
        {
            _companyContext = companyContext;
        }
        public void AddEmployee(Employee employee)
        {
            _companyContext.Employees.Add(employee);
            _companyContext.SaveChanges();
        }

        public List<Employee> GetEmployees(int pageSize, int index = 0)
        {
            if (index < 0) index = 0;
            return _companyContext.Employees.OrderBy(x => x.Id).Skip(index).Take(pageSize).ToList();
        }

        public int GetTotalCount()
        {
            return _companyContext.Employees.Count();
        }

        public void DeleteEmployee(int id)
        {
            var employee = _companyContext.Employees.Single(x => x.Id == id);
            _companyContext.Employees.Remove(employee);
            _companyContext.SaveChanges();
        }

        public Employee GetEmployeeById(int value)
        {
            return _companyContext.Employees.Single(x => x.Id == value);
        }
    }
}

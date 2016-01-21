
using System.Collections.Generic;
using CompanyProject.Models;

namespace CompanyProject.Services.Interfaces
{
    public interface IEmployeeService
    {
        void AddEmployee(Employee employee);
        List<Employee> GetEmployees(int page, int pageSize);
        int GetTotalCount();
        void DeleteEmployee(int id);
        Employee GetEmployeeById(int value);
    }
}

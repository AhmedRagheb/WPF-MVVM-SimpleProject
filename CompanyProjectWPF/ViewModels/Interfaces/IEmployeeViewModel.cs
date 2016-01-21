using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyProjectWPF.Wrapper;

namespace CompanyProjectWPF.ViewModels.Interfaces
{
    public interface IEmployeeViewModel
    {
        EmployeeViewModel Load(int? employeeId = null);
        EmployeeWrapper Employee { get; }
    }
}

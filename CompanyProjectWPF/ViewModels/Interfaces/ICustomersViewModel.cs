using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyProjectWPF.Wrapper;

namespace CompanyProjectWPF.ViewModels.Interfaces
{
    public interface ICustomersViewModel
    {
        CustomersViewModel Load(Guid? customerId = null);
        CustomerWrapper SelectedCustomer { get; }
        OrderWrapper NewOrder { get; }
    }
}

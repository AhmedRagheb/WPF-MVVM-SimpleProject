using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyProject.Models;

namespace CompanyProjectWPF.Wrapper
{
    public class OrderStatusWrapper : ModelWrapper<OrderStatus>
    {
        public OrderStatusWrapper(OrderStatus model)
            : base(model)
        {

        }

        public int Id
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }

        public string Name
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
    }
}

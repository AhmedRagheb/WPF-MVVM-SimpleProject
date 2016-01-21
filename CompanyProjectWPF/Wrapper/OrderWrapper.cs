using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyProject.Models;

namespace CompanyProjectWPF.Wrapper
{
    public class OrderWrapper : ModelWrapper<Order>
    {
        public OrderWrapper(Order model)
            : base(model)
        {

        }

        public long Id
        {
            get { return GetValue<long>(); }
            set { SetValue(value); }
        }

        public Guid? StoreId
        {
            get { return GetValue<Guid>(); }
            set { SetValue(value); }
        }

        public Guid CustomerId
        {
            get { return GetValue<Guid>(); }
            set { SetValue(value); }
        }

        public int OrderStatusId
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }

        public DateTime OrderDate
        {
            get { return GetValue<DateTime>(); }
            set { SetValue(value); }
        }

        public DateTime DeliveryDate
        {
            get { return GetValue<DateTime>(); }
            set { SetValue(value); }
        }

        public decimal DeliveryCharge
        {
            get { return GetValue<decimal>(); }
            set { SetValue(value); }
        }

        public decimal ItemsTotal
        {
            get { return GetValue<decimal>(); }
            set { SetValue(value); }
        }

        public string Phone
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string DeliveryStreet
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string DeliveryCity
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string DeliveryState
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string DeliveryZip
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public List<OrderItem> OrderItems
        {
            get { return GetValue<List<OrderItem>>(); }
            set { SetValue(value); }
        }

        public OrderStatus Status
        {
            get { return GetValue<OrderStatus>(); }
            set { SetValue(value); }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyProject.Models;

namespace CompanyProjectWPF.Wrapper
{
    public class CustomerWrapper : ModelWrapper<Customer>
    {
        public CustomerWrapper(Customer model)
            : base(model)
        {

        }

        public Guid Id
        {
            get { return GetValue<Guid>(); }
            set { SetValue(value); }
        }

        public Guid? StoreId
        {
            get { return GetValue<Guid?>(); }
            set { SetValue(value); }
        }
        public string FirstName
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public string LastName
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        
        public string FullName { get { return FirstName + " " + LastName; } }

        public string Phone
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public string Email
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public string Street
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public string City
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public string State
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public string Zip
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public ObservableCollection<OrderWrapper> Orders { get; set; }
    }
}

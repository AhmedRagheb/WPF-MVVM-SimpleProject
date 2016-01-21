using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CompanyProject.Models;
using CompanyProject.Services.Interfaces;
using CompanyProjectWPF.Command;
using CompanyProjectWPF.ViewModels.Interfaces;
using CompanyProjectWPF.Views.Services;
using CompanyProjectWPF.Wrapper;
using Microsoft.Practices.Prism.PubSubEvents;

namespace CompanyProjectWPF.ViewModels
{


    public class CustomersViewModel : Observable, ICustomersViewModel, IPageViewModel
    {
        private readonly IMessageDialogService _messageDialogService;
        private readonly ICustomersRepository _customersRepository;
        private readonly IOrdersRepository _ordersRepository;

        private CustomerWrapper _selectedCustomer;
        public CustomerWrapper SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                _selectedCustomer = value;
                OnChangeSelectedCustomer(_selectedCustomer);
                OnPropertyChanged();
            }
        }

        private OrderWrapper _newOrder;
        public OrderWrapper NewOrder
        {
            get { return _newOrder; }
            set
            {
                _newOrder = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<CustomerWrapper> Customers { get; private set; }
        public ObservableCollection<OrderStatusWrapper> OrderStatuses { get; private set; }

        public ICommand SaveCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }

        public CustomersViewModel(
            IMessageDialogService messageDialogService,
            ICustomersRepository customersRepository,
            IOrdersRepository ordersRepository)
        {
            _messageDialogService = messageDialogService;
            _customersRepository = customersRepository;
            _ordersRepository = ordersRepository;

            Customers =
                new ObservableCollection<CustomerWrapper>(
                    _customersRepository.GetCustomers().Select(x => new CustomerWrapper(x)));

            OrderStatuses = new ObservableCollection<OrderStatusWrapper>(
                    _ordersRepository.GetOrderStatuses().Select(x => new OrderStatusWrapper(x)));

            SaveCommand = new DelegateCommand(OnAdd);
            CancelCommand = new DelegateCommand(OnCancel);
        }

        public CustomersViewModel Load(Guid? customerId = null)
        {
            SelectedCustomer = !customerId.HasValue
                ? new CustomerWrapper(new Customer())
                : new CustomerWrapper(_customersRepository.GetCustomer(customerId.Value));

            return this;
        }

       
        private void OnAdd(object obj)
        {
            if (NewOrder.IsValid)
            {
                SelectedCustomer.Orders.Add(new OrderWrapper(NewOrder.Model));
                _ordersRepository.AddOrder(NewOrder.Model);
                MessageBox.Show("Order Saved Succesfully");
            }
            
        }

        private void OnCancel(object obj)
        {
           if(NewOrder.IsChanged)
           {
               var result = _messageDialogService.ShowYesNoDialog("Cancel", "Do you want to cancel");
               if(result == MessageDialogResult.Yes)
               {
                   NewOrder = new OrderWrapper(new Order());
               }
           }
        }

        private void OnChangeSelectedCustomer(CustomerWrapper selectedCustomer)
        {
            selectedCustomer.Orders =
                    new ObservableCollection<OrderWrapper>(
                        _ordersRepository.GetAllOrders().Where(o => o.CustomerId == SelectedCustomer.Id).Select(
                            x => new OrderWrapper(x)));

            var order = new Order
                            {
                                CustomerId = selectedCustomer.Id,
                                ItemsTotal = 1,
                                OrderDate = DateTime.Now,
                                StoreId = selectedCustomer.StoreId,
                                Phone = SelectedCustomer.Phone,
                                DeliveryCity = SelectedCustomer.City,
                                DeliveryState = selectedCustomer.State,
                                DeliveryStreet = selectedCustomer.Street,
                                DeliveryZip = selectedCustomer.Zip,
                                DeliveryDate = DateTime.Now.AddDays(2)
                            };

            NewOrder = new OrderWrapper(order);
        }

        public string Name { get { return "Customers"; } }
        public string TitleName { get { return "Customers"; } }
    }
}

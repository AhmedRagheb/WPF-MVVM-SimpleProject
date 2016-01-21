
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Practices.Prism.PubSubEvents;
using CompanyProject.Models;
using CompanyProject.Services.Interfaces;
using CompanyProjectWPF.Events;
using CompanyProjectWPF.ViewModels.Interfaces;
using CompanyProjectWPF.Views.Services;
using CompanyProjectWPF.Wrapper;
using DelegateCommand = CompanyProjectWPF.Command.DelegateCommand;

namespace CompanyProjectWPF.ViewModels
{
    public class EmployeeViewModel : Observable, IEmployeeViewModel, IPageViewModel
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IMessageDialogService _messageDialogService;
        private readonly IEmployeeService _employeeService;
        private EmployeeWrapper _employee;

        public EmployeeViewModel(IEventAggregator eventAggregator,
            IMessageDialogService messageDialogService,
            IEmployeeService employeeService)
        {
            _eventAggregator = eventAggregator;
            _messageDialogService = messageDialogService;
            _employeeService = employeeService;

            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
            ResetCommand = new DelegateCommand(OnResetExecute, OnResetCanExecute);
            DeleteCommand = new DelegateCommand(OnDeleteExecute, OnDeleteCanExecute);

        }

        public EmployeeViewModel Load(int? employeeId = null)
        {
            var employee = employeeId.HasValue
                ? _employeeService.GetEmployeeById(employeeId.Value)
                : new Employee();

            Employee = new EmployeeWrapper(employee);
            Employee.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "IsChanged"
                    || e.PropertyName == "IsValid")
                {
                    InvalidateCommands();
                }
            };

            InvalidateCommands();

            return this;
        }

        public EmployeeWrapper Employee
        {
            get { return _employee; }
            private set
            {
                _employee = value;
                OnPropertyChanged();
            }
        }


        public ICommand SaveCommand { get; private set; }

        public ICommand ResetCommand { get; private set; }

        public ICommand DeleteCommand { get; private set; }


        private void OnSaveExecute(object obj)
        {
            _employeeService.AddEmployee(Employee.Model);
            Employee.AcceptChanges();
            _eventAggregator.GetEvent<EmployeeSavedEvent>().Publish(Employee.Model);
            InvalidateCommands();
        }

        private bool OnSaveCanExecute(object arg)
        {
            return Employee.IsChanged && Employee.IsValid;
        }

        private void OnResetExecute(object obj)
        {
            Employee.RejectChanges();
        }

        private bool OnResetCanExecute(object arg)
        {
            return Employee.IsChanged;
        }

        private bool OnDeleteCanExecute(object arg)
        {
            return Employee != null && Employee.Id > 0;
        }

        private void OnDeleteExecute(object obj)
        {
            var result = _messageDialogService.ShowYesNoDialog(
                "Delete Friend",
                string.Format("Do you really want to delete the friend '{0} {1}'", Employee.FirstName, Employee.LastName),
                MessageDialogResult.No);

            if (result == MessageDialogResult.Yes)
            {
                _employeeService.DeleteEmployee(Employee.Id);
                _eventAggregator.GetEvent<EmployeeDeletedEvent>().Publish(Employee.Id);
            }
        }

        public void OnClosing(CancelEventArgs e)
        {
            if (Employee.IsChanged)
            {
                var result = _messageDialogService.ShowYesNoDialog("Close application?",
                    "You'll lose your changes if you close this application. Close it?",
                    MessageDialogResult.No);
                e.Cancel = result == MessageDialogResult.No;
            }
        }

        private void InvalidateCommands()
        {
            ((DelegateCommand) SaveCommand).RaiseCanExecuteChanged();
            ((DelegateCommand) ResetCommand).RaiseCanExecuteChanged();
            ((DelegateCommand) DeleteCommand).RaiseCanExecuteChanged();
        }


        public string Name
        {
            get { return "Employees"; }
        }

        public string TitleName { get { return "Employees"; } }
    }
}

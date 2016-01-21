using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using CompanyProject.Models;
using CompanyProject.Services.Interfaces;
using CompanyProjectWPF.Command;
using CompanyProjectWPF.Controls;
using CompanyProjectWPF.Wrapper;

namespace CompanyProjectWPF.ViewModels
{
    public interface IEmployeeListViewModel
    {
        
    }

    public class EmployeeListViewModel : IEmployeeListViewModel
    {
        private readonly IEmployeeService _employeeService;

        private const int PageSize = 3;
        public PagingController Pager { get; private set; }

        private readonly ObservableCollection<EmployeeWrapper> _employees = new ObservableCollection<EmployeeWrapper>();
        private readonly CollectionViewSource _employeesViewSource = new CollectionViewSource();

        
        public ICollectionView Employees
        {
            get { return this._employeesViewSource.View; }
        }

        public EmployeeListViewModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            this._employeesViewSource.Source = this._employees;

            this.Pager = new PagingController(GetTotalCount(), PageSize);
            this.Pager.CurrentPageChanged += (s, e) => this.UpdateData();

            UpdateData();

            //DeleteCommand = new RelayCommand(OnDelete, CanDelete);
            //AddEmployeeCommand = new RelayCommand(OnAddEmployee);
            //EditEmployeeCommand = new RelayCommand<Employee>(OnEditEmployee);
        }

        #region List Bind
        private void UpdateData()
        {
            //SortDescription[] currentSort = this._employeesViewSource.View.SortDescriptions.DefaultIfEmpty(DefaultSortOrder).ToArray();

            //var data = _employeeService.GetEmployees(this.Pager.PageSize, this.Pager.CurrentPageStartIndex);
            this._employees.Clear();
            //this._employees.AddRange(data);
        }

        private int GetTotalCount()
        {
            return _employeeService.GetTotalCount();
        }

        private void OnSortOrderChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                this.UpdateData();
            }
        }
        #endregion

        #region Commands

        private EmployeeWrapper _selectedEmployee;
        public EmployeeWrapper SelectedEmployee
        {
            get
            {
                return _selectedEmployee;
            }
            set
            {
                _selectedEmployee = value;
                //DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        public DelegateCommand DeleteCommand { get; private set; }
        public DelegateCommand AddEmployeeCommand { get; private set; }
        //public RelayCommand<Employee> EditEmployeeCommand { get; private set; }

        public event Action<Employee> AddEmployeeRequested = delegate { };
        public event Action<Employee> EditEmployeeRequested = delegate { };

        private void OnDelete()
        {
            if (MessageBox.Show("Delete Employee ?", "Delete",
                MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                _employees.Remove(SelectedEmployee);
                _employeeService.DeleteEmployee(SelectedEmployee.Id);
            }
        }
        private bool CanDelete()
        {
            return SelectedEmployee != null;
        }

        private void OnAddEmployee()
        {
            AddEmployeeRequested(new Employee { BirthDate = DateTime.Now});
        }
        private void OnEditEmployee(Employee employee)
        {
            EditEmployeeRequested(employee);
        }

        #endregion
    }
}

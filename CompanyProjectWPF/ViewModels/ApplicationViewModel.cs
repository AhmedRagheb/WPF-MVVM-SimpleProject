using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using CompanyProjectWPF.Command;
using CompanyProjectWPF.ViewModels.Interfaces;

namespace CompanyProjectWPF.ViewModels
{
    public class ApplicationViewModel : Observable
    {
        #region Fields

        private ICommand _changePageCommand;

        private IPageViewModel _currentPageViewModel;
        private string _currentPageTitle;
        private List<IPageViewModel> _pageViewModels;

        private IEmployeeViewModel _employeeViewModel;
        private ICustomersViewModel _customerViewModel;

        #endregion

        public ApplicationViewModel(IEmployeeViewModel employeeViewModel, ICustomersViewModel customerViewModel)
        {
            _customerViewModel = customerViewModel;
            _employeeViewModel = employeeViewModel;

            // Add available pages
            PageViewModels.Add(_customerViewModel.Load());
            PageViewModels.Add(_employeeViewModel.Load());

            // Set starting page
            CurrentPageViewModel = PageViewModels[0];
            CurrentPageTitle = CurrentPageViewModel.TitleName;
        }

        #region Properties / Commands

        public ICommand ChangePageCommand
        {
            get
            {
                if (_changePageCommand == null)
                {
                    _changePageCommand = new DelegateCommand(
                        p => ChangeViewModel((IPageViewModel)p),
                        p => p is IPageViewModel);
                }

                return _changePageCommand;
            }
        }

        public List<IPageViewModel> PageViewModels
        {
            get
            {
                if (_pageViewModels == null)
                    _pageViewModels = new List<IPageViewModel>();

                return _pageViewModels;
            }
        }

        public IPageViewModel CurrentPageViewModel
        {
            get
            {
                return _currentPageViewModel;
            }
            set
            {
                if (_currentPageViewModel != value)
                {
                    _currentPageViewModel = value;
                    OnPropertyChanged("CurrentPageViewModel");
                }
            }
        }
        
        public string CurrentPageTitle
        {
            get
            {
                return _currentPageTitle;
            }
            set
            {
                if (_currentPageTitle != value)
                {
                    _currentPageTitle = value;
                    OnPropertyChanged("CurrentPageTitle");
                }
            }
        }

        #endregion

        #region Methods

        private void ChangeViewModel(IPageViewModel viewModel)
        {
            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);

            CurrentPageViewModel = PageViewModels.FirstOrDefault(vm => vm == viewModel);
            CurrentPageTitle = CurrentPageViewModel != null ? CurrentPageViewModel.TitleName : "";
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using Autofac;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CompanyProject.Services;
using CompanyProject.Services.Interfaces;
using CompanyProjectWPF.Startup;
using CompanyProjectWPF.ViewModels;

namespace CompanyProjectWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ApplicationViewModel _mainViewModel;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var bootstrapper = new Bootstrapper();
            IContainer container = bootstrapper.Bootstrap();

            _mainViewModel = container.Resolve<ApplicationViewModel>();
            MainWindow = new MainWindow(_mainViewModel);
            MainWindow.Show();
            //_mainViewModel.Load();

        }
    }

}

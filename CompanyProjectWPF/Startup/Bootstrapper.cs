using Autofac;
using Microsoft.Practices.Prism.PubSubEvents;
using CompanyProject.Data;
using CompanyProject.Services;
using CompanyProject.Services.Interfaces;
using CompanyProjectWPF.ViewModels;
using CompanyProjectWPF.ViewModels.Interfaces;
using CompanyProjectWPF.Views.Services;

namespace CompanyProjectWPF.Startup
{
  public class Bootstrapper
  {
      public IContainer Bootstrap()
      {
          var builder = new ContainerBuilder();

          builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();

          builder.RegisterType<MessageDialogService>().As<IMessageDialogService>();
          builder.RegisterType<EmployeeViewModel>().As<IEmployeeViewModel>();
          builder.RegisterType<CustomersViewModel>().As<ICustomersViewModel>();
          builder.RegisterType<EmployeeListViewModel>().As<IEmployeeListViewModel>();

          builder.RegisterType<CompanyContext>().As<ICompanyContext>().WithParameter("connectionStringName", "TestEntitiesStr");
          builder.RegisterType<EmployeeService>().As<IEmployeeService>();
          builder.RegisterType<CustomersRepository>().As<ICustomersRepository>();
          builder.RegisterType<OrdersRepository>().As<IOrdersRepository>();
          
          //builder.RegisterType<NavigationViewModel>().As<INavigationViewModel>();

          builder.RegisterType<ApplicationViewModel>().AsSelf();


          return builder.Build();
      }
  }
}

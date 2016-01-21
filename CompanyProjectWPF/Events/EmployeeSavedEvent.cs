using Microsoft.Practices.Prism.PubSubEvents;
using CompanyProject.Models;

namespace CompanyProjectWPF.Events
{
  public class EmployeeSavedEvent : PubSubEvent<Employee>
  {
  }
}

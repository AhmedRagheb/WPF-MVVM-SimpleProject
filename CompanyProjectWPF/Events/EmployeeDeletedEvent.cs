using Microsoft.Practices.Prism.PubSubEvents;

namespace CompanyProjectWPF.Events
{
  public class EmployeeDeletedEvent : PubSubEvent<int>
  {
  }
}
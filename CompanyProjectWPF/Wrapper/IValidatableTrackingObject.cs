using System.ComponentModel;

namespace CompanyProjectWPF.Wrapper
{
  public interface IValidatableTrackingObject :
    IRevertibleChangeTracking,
    INotifyPropertyChanged
  {
    bool IsValid { get; }
  }
}

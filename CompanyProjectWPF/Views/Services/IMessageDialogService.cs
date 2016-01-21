namespace CompanyProjectWPF.Views.Services
{
  public interface IMessageDialogService
  {
    MessageDialogResult ShowYesNoDialog(string title, string text,
        MessageDialogResult defaultResult = MessageDialogResult.Yes);
  }
}
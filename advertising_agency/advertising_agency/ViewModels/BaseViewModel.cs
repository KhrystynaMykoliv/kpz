namespace advertising_agency.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;

public partial class BaseViewModel : ObservableObject
{
  private bool _isBusy;
  public bool IsBusy
  {
      get => _isBusy;
      set => SetProperty(ref _isBusy, value);
  }

  [ObservableProperty]
  public bool title;
   
}

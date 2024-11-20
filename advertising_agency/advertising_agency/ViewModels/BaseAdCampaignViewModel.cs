using CommunityToolkit.Mvvm.ComponentModel;
using advertising_agency.Models;

namespace advertising_agency.ViewModels;

public partial class BaseAdCampaignViewModel : BaseViewModel {
  [ObservableProperty]
  private AdCampaign _adCampaign;
}

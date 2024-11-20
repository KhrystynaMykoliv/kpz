using advertising_agency.Models;
using advertising_agency.ViewModels;

namespace advertising_agency.Views;

public partial class AddAdCampaignPage : ContentPage 
{
  public AdCampaign AdCampaign { get; set; }
  AddAdCampaignPageViewModel addAdCampaignPageViewModel;

  public AddAdCampaignPage() 
  {
    InitializeComponent();
    this.BindingContext = addAdCampaignPageViewModel = new AddAdCampaignPageViewModel();
  }
}

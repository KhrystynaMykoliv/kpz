using CommunityToolkit.Mvvm.Input;
using advertising_agency.Models;
using advertising_agency.Services.AdCampaignService;
using System.Windows.Input;

namespace advertising_agency.ViewModels;

public class AddAdCampaignPageViewModel : BaseAdCampaignViewModel
{
    public ICommand OnSubmitCommand { get; }
    public ICommand OnCancelCommand { get; }
    private readonly AdCampaignService adCampaignService;

    public event Action<AdCampaign> AdCampaignAdded;

    public AddAdCampaignPageViewModel()
    { 
        adCampaignService = new AdCampaignService();
        AdCampaign = new AdCampaign();
        OnSubmitCommand = new Command(async () => await OnSubmit());
        OnCancelCommand = new Command(async () => await OnCancel());
    }

    public async Task OnSubmit()
    {
        try
        {
            var adCampaign = AdCampaign;
            await adCampaignService.AddUpdateAdCampaignAsync(adCampaign);

            await Shell.Current.DisplayAlert("Success", "Successfully added!", "OK");
            await Shell.Current.GoToAsync("..");
        }
        catch (Exception e)
        {
            await Shell.Current.DisplayAlert("Error", e.Message, "OK");
        }
    }

    public async Task OnCancel()
    {
        await Shell.Current.GoToAsync("..");
    }

    public void onAppearing()
    {
        IsBusy = true;
    }
}

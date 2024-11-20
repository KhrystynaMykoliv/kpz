using advertising_agency.Models;
using advertising_agency.Views;
using advertising_agency.Services.AdCampaignService;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace advertising_agency.ViewModels
{
    public partial class AdCampaignPageViewModel : BaseAdCampaignViewModel
    {
        public ICommand OnAddAdCampaignCommand { get; }
        private readonly AdCampaignService adCampaignService;
        public ICommand loadAdCampaignCommand { get; }
        public ICommand OnSubmitCommand { get; }
        public ObservableCollection<AdCampaign> AdCampaignList { get; set; } = new ObservableCollection<AdCampaign>();
        
        public AdCampaignPageViewModel()
        {
            adCampaignService = new AdCampaignService();
            OnAddAdCampaignCommand = new Command(async () => await OnAddAdCampaign());
            loadAdCampaignCommand = new Command(async () => await loadAdCampaign());
            AdCampaign = new AdCampaign();
            OnSubmitCommand = new Command(async () => await OnSubmit());
        }

        public async Task OnSubmit()
        {
            try
            {
                await adCampaignService.AddUpdateAdCampaignAsync(AdCampaign);
                await Shell.Current.DisplayAlert("Success", "Successfully added!", "OK");

                AdCampaignList.Clear();
                var items = await adCampaignService.getAdCampaignsAsync();
                if (items != null)
                {
                    foreach (var item in items)
                    {
                        AdCampaignList.Add(item);
                    }
                }

                await Shell.Current.GoToAsync("..");
            }
            catch (Exception e)
            {
                await Shell.Current.DisplayAlert("Error", e.Message, "OK");
            }
        }

        private async Task OnAddAdCampaign()
        {
            await Shell.Current.GoToAsync(nameof(AddAdCampaignPage));
        }

        public async Task loadAdCampaign()
        {
            IsBusy = true;
            try
            {
                AdCampaignList.Clear();
                var items = await adCampaignService.getAdCampaignsAsync();
                if (items != null)
                {
                    foreach (var item in items)
                    {
                        AdCampaignList.Add(item);
                    }
                }
            }
            catch (Exception e)
            {
                IsBusy = false;
                await Shell.Current.DisplayAlert("Error", e.Message, "OK");
            }
            finally 
            {
                IsBusy = false;
            }
        }
    }
}

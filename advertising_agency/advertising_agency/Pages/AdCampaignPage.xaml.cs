using advertising_agency.Models;
using advertising_agency.ViewModels;

namespace advertising_agency.Views
{
    public partial class AdCampaignPage : ContentPage
    {
        private AdCampaignPageViewModel _viewModel;

        public AdCampaignPage()
        {
            InitializeComponent();
            _viewModel = new AdCampaignPageViewModel();
            BindingContext = _viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.loadAdCampaignCommand.Execute(null);
        }

        private async void OnSubmitButtonClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            await button.ScaleTo(1.1, 100);
            await button.ScaleTo(1, 100);
            if (BindingContext is AdCampaignPageViewModel viewModel && viewModel.OnSubmitCommand.CanExecute(null))
            {
                viewModel.OnSubmitCommand.Execute(null);
            }
        }

    }
}

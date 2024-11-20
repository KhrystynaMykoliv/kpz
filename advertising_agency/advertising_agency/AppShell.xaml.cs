using advertising_agency.Views;

namespace advertising_agency;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(AdCampaignPage), typeof(AdCampaignPage));
		Routing.RegisterRoute(nameof(AddAdCampaignPage), typeof(AddAdCampaignPage));
	}
}

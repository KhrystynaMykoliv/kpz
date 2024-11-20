using advertising_agency.Services.AdCampaignService;

namespace advertising_agency;

public partial class App : Application
{

  public static AdCampaignService _adCamaignService;

  public static AdCampaignService AdCampaignService {
    get
    {
      if (_adCamaignService == null) {
        _adCamaignService = new AdCampaignService();
      }

      return _adCamaignService;
    }
  }

	public App()
	{
		InitializeComponent();
  
		MainPage = new AppShell();
    
	}
}

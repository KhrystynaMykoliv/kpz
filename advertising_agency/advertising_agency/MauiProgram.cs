using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using advertising_agency.ViewModels;

namespace advertising_agency;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
      		.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

    builder.Services.AddSingleton<AdCampaignPageViewModel>()
                    .AddTransient<AddAdCampaignPageViewModel>();
	
  	return builder.Build();
	}
}

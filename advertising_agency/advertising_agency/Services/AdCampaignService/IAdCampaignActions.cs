using advertising_agency.Models;

namespace advertising_agency.Services.AdCampaignService {
  public interface IAdCampaignActions {
    Task<bool> AddUpdateAdCampaignAsync(AdCampaign adCampaign);
    Task<AdCampaign> GetAdCampaignAsync(int adCampaignId);
    Task<IEnumerable<AdCampaign>> getAdCampaignsAsync();
  }
}

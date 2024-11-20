using advertising_agency.Models;
using SQLite;
using advertising_agency.Services.Database;

namespace advertising_agency.Services.AdCampaignService {
  public class AdCampaignService : IAdCampaignActions {
    public SQLiteAsyncConnection _database;

    public AdCampaignService() {
      _ = Task.Run(async () =>
        {
          _database = await ConnectionService.GetDatabaseConnectionAsync();
        });
    }

    public async Task<bool> AddUpdateAdCampaignAsync(AdCampaign adCampaign) {
      if (adCampaign.Id > 0) {
        await _database.UpdateAsync(adCampaign);
      } else {
        await _database.InsertAsync(adCampaign);
      }

      return await Task.FromResult(true);
    }
    public async Task<IEnumerable<AdCampaign>> getAdCampaignsAsync() {
      return await Task.FromResult(await _database.Table<AdCampaign>().ToListAsync());
    }
    public async Task<AdCampaign> GetAdCampaignAsync(int adCampaignId) {
      return await _database.Table<AdCampaign>().Where(p => p.Id == adCampaignId).FirstOrDefaultAsync();
    }
  }
}

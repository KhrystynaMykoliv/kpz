namespace AdvertisingAgencyApi.Models;

public partial class Advertising {
    public long Id { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }
    public string? AdvertisingType { get; set; }

    public long CampaignCode { get; set; }
    public Campaign? Campaign { get; set; }

    public virtual ICollection<AdsRate> AdsRates { get; set; } = new List<AdsRate>();
}

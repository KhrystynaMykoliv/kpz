namespace AdvertisingAgencyApi.Models;

public partial class AdsRate {
    public long Id { get; set; }
    public float CostPerClick { get; set; }
    public float ClickThroughRate { get; set; }
    public float ConversionRate { get; set; }
    public float AvgQualityScore { get; set; }

    public long AdvertisingId { get; set; }
    public Advertising? Advertising { get; set; }
}

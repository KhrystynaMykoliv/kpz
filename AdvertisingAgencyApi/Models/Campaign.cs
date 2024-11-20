namespace AdvertisingAgencyApi.Models;

public partial class Campaign {
    public long ContractCode { get; set; }

    public string? CurrentStatus { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Advertising> Advertisings { get; set; } = new List<Advertising>();
}

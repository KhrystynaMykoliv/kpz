namespace AdvertisingAgencyApi.Models;

public partial class Client {
    public long PersonId { get; set; }

    public string? CompanyName { get; set; }

    public virtual Person Person { get; set; } = null!;

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
}

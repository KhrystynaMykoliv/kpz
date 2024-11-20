namespace AdvertisingAgencyApi.Models;

public partial class Manager
    {
        public DateTime StartedWork { get; set; }

        public long PersonId { get; set; }

        public virtual Person Person { get; set; } = null!;
    }

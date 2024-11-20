namespace AdvertisingAgencyApi.DTOs 
{
    public class ManagerDto
    {

        public DateTime StartedWork { get; set; }

        public long PersonId { get; set; }

        public virtual PersonDto Person { get; set; } = null!;
    }
}


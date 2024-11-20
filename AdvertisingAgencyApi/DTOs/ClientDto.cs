namespace AdvertisingAgencyApi.DTOs 
{
    public class ClientDto
    {
        public long PersonId { get; set; }

        public string? CompanyName { get; set; }

        public virtual PersonDto Person { get; set; } = null!;

        public virtual ICollection<ContractDto> Contracts { get; set; } = new List<ContractDto>();
    }
}


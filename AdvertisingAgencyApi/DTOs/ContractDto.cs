namespace AdvertisingAgencyApi.DTOs 
{
    public class ContractDto
    {
        public long ContractCode { get; set; }
        public DateTime DateDesigned { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        public long ManagerId { get; set; }
        public long ClientId { get; set; }
        
        public string? ManagerName { get; set; }
        public string? ClientCompanyName { get; set; }
    }
}


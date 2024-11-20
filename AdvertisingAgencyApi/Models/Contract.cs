namespace AdvertisingAgencyApi.Models;

public partial class Contract
    {
        public long ContractCode { get; set; }

        public DateTime DateDesigned { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        public long ManagerId { get; set; }
        public Manager? Manager { get; set; }

        public long ClientId { get; set; }
        public Client? Client { get; set; }
    }

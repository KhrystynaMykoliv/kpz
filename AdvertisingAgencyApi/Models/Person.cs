namespace AdvertisingAgencyApi.Models;

public partial class Person
    {
       public long Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public virtual Client? Client { get; set; }
        public virtual Manager? Manager { get; set; }
    }

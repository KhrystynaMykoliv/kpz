using System.ComponentModel.DataAnnotations;

namespace AdvertisingAgencyApi.DTOs 
{
    public class CreateClientDto
    {
        [Required(ErrorMessage = "Please provide a company name.")]
        [StringLength(50, ErrorMessage = "Company name must be 50 characters or fewer.")]
        public string? CompanyName { get; set; }

        [Required(ErrorMessage = "Please provide person details.")]
        public CreatePersonDto Person { get; set; } = null!;
    }
}

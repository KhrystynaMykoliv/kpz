using System.ComponentModel.DataAnnotations;

namespace AdvertisingAgencyApi.DTOs 
{
    public class CreateManagerDto
    {
        [Required(ErrorMessage = "Please provide the start date of employment.")]
        public DateTime StartedWork { get; set; }

        [Required(ErrorMessage = "Please provide person details.")]
        public CreatePersonDto Person { get; set; } = null!;
    }
}

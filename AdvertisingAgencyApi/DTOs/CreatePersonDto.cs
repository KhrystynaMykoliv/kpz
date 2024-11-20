using System.ComponentModel.DataAnnotations;

namespace AdvertisingAgencyApi.DTOs 
{
    public class CreatePersonDto
    {
        [Required(ErrorMessage = "Please provide a first name.")]
        [StringLength(55, ErrorMessage = "First name must be 55 characters or fewer.")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Please provide a last name.")]
        [StringLength(55, ErrorMessage = "Last name must be 55 characters or fewer.")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "Please provide a email.")]
        [StringLength(50, ErrorMessage = "Email must be 50 characters or fewer.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Please provide a phone number.")]
        [StringLength(30, ErrorMessage = "Phone number must be 30 characters or fewer.")]
        public string Phone { get; set; } = null!;
    }
}

using System.ComponentModel.DataAnnotations;

namespace AdvertisingAgencyApi.DTOs 
{
    public class CreateContractDto
    {
        [Required(ErrorMessage = "Please provide the contract design date.")]
        public DateTime DateDesigned { get; set; }

        [Required(ErrorMessage = "Please provide the contract start date.")]
        public DateTime ValidFrom { get; set; }

        [Required(ErrorMessage = "Please provide the contract end date.")]
        public DateTime ValidTo { get; set; }

        [Required(ErrorMessage = "Please provide the manager ID.")]
        public long ManagerId { get; set; }

        [Required(ErrorMessage = "Please provide the client ID.")]
        public long ClientId { get; set; }
    }
}

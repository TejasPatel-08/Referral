using System.ComponentModel.DataAnnotations;

namespace Referral.DAL.Models
{
    public class CustomerModal
    {
        [Required]
        public string CustomerModalFirstName { get; set; }

        [Required]
        public string CustomerModalLastName { get; set; }

        [Required]
        public string CustomerModalArea { get; set; }

        public string CustomerModalPhoneNumber { get; set; }
    }
}

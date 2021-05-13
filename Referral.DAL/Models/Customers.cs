using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Referral.DAL.Models
{
    public class Customers : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Address { get; set; }

        [Required]
        public string Area { get; set; }

        public DateTime Dob { get; set; }

        public string City { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public string ReferralId { get; set; }
    }
}

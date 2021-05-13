using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Referral.DAL.Models
{
    public class CustomersPurchase
    {
        [Key]
        public Guid Id { get; set; }

        public Guid CustomerId { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Amount { get; set; }

        [Required]
        public DateTime PurchaseDate { get; set; }
    }
}

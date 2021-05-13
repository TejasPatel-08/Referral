using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Referral.DAL.Models
{
    public class RedeemPoints
    {
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal TotalPoint { get; set; }
        public int MaxRedeemPoint { get; set; }
        public Guid CustomerId { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal RedeemAmount { get; set; }
    }
}

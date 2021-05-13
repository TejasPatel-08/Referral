using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Referral.DAL.Models
{
    public class ReferralConfig
    {
        public ReferralConfig()
        {
            PPA = new PointPurchaseAmount();
        }

        [Key]
        public Guid Id { get; set; }
        public decimal FMP { get; set; } = 0;
        public virtual PointPurchaseAmount PPA { get; set; }
        public int RedeemPointPercentage { get; set; }
        public int ReferralPoints { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal RedeemPointValue { get; set; }
    }

    public class PointPurchaseAmount
    {
        [Key]
        public Guid Id { get; set; }
        public int Points { get; set; } = 2;

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal PurchaseAmount { get; set; } = 50;
    }
}

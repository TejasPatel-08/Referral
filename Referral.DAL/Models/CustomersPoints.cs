using System;
using System.ComponentModel.DataAnnotations;

namespace Referral.DAL.Models
{
    public class CustomersPoints
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public PointType PointType { get; set; }
        public decimal PointEarned { get; set; }
        public DateTime CreateDate { get; set; }
    }
}

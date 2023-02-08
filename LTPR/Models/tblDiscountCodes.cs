using System.ComponentModel.DataAnnotations;

namespace LTPR.Models
{
    public class tblDiscountCodes
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string DiscountCode { get; set; }
        [Required]
        public decimal DiscountAmount { get; set; }
        [Required]
        public bool IsPercentage { get; set; }
    }
}

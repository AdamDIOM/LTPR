using System.ComponentModel.DataAnnotations;

namespace LTPR.Models
{
    public class tblItemsOnSale
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int SID { get; set; }
        [Required]
        public int IID { get; set; }
        [Required]
        public decimal Cost { get; set; }
        [Required]
        public int Qty { get; set; }
    }
}

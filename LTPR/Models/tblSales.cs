using System.ComponentModel.DataAnnotations;

namespace LTPR.Models
{
    public class tblSales
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string UID { get; set; }
        [Required]
        public DateTime OrderTime { get; set; }
        public double Discount { get; set; }
    }
}

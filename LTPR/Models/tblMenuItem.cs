using System.ComponentModel.DataAnnotations;

namespace LTPR.Models
{
    public class tblMenuItem
    {
        [Key]
        public int ID { get; set; }
        [Required, StringLength(25)]
        public string Name { get; set; }
        [Required]
        public decimal Cost { get; set; }
        [Required, StringLength(150)]
        public string Description { get; set; }
    }
}

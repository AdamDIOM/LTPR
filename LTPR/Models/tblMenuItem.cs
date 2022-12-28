using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LTPR.Models
{
    public class tblMenuItem
    {
        [Key]
        public int ID { get; set; }
        [Required, StringLength(25)]
        public string Name { get; set; }
        [Required, Range(0,50), Column(TypeName ="decimal(18,2)")]
        public decimal Cost { get; set; }
        [Required, StringLength(150), MinLength(10)]
        public string Description { get; set; }
    }
}

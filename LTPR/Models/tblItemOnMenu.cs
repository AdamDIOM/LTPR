using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace LTPR.Models
{
    public class tblItemOnMenu
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public int MID { get; set; }
        [Required]
        public int IID { get; set; }
        [Required, Range(0, 50), Column(TypeName = "decimal(18,2)")]
        public decimal Cost { get; set; }
        public string SpecialDay { get; set; }
    }
}

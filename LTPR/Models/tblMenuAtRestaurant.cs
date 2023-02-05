using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace LTPR.Models
{
    public class tblMenuAtRestaurant
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public int RID { get; set; }
        [Required]
        public int MID { get; set; }
    }
}

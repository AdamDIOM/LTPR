using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace LTPR.Models
{
    public class tblIngredientInItem
    {
        [Key]
        public int KID { get; set; }
        [Required]
        public int MIID { get; set; }
        [Required]
        public int IID { get; set; }

    }
}

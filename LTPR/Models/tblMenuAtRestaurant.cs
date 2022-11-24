using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace LTPR.Models
{
    public class tblMenuAtRestaurant
    {
        [Key]
        public int RID { get; set; }
        [Key]
        public int MID { get; set; }
    }
}

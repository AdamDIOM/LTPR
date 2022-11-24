using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace LTPR.Models
{
    public class tblItemOnMenu
    {
        [Key]
        public int MID { get; set; }
        [Key]
        public int IID { get; set; }
    }
}

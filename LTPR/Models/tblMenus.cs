using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace LTPR.Models
{
    public class tblMenus
    {
        [Key]
        public int ID { get; set; }
        [Required, StringLength(25)]
        public string Name { get; set; }
    }
}

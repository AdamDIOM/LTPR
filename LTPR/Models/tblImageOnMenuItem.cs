using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LTPR.Models
{
    public class tblImageOnMenuItem
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public int MIID { get; set; }
        [Required]
        public int IID { get; set; }
    }
}

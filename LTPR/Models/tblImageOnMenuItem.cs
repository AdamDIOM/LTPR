using System.ComponentModel.DataAnnotations;

namespace LTPR.Models
{
    public class tblImageOnMenuItem
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int MIID { get; set; }
        [Required]
        public int IID { get; set; }
    }
}

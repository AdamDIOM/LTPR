using System.ComponentModel.DataAnnotations;

namespace LTPR.Models
{
    public class tblImages
    {
        [Key]
        public int ID { get; set; }
        public byte[] ImageData { get; set; }
        [StringLength(250), MinLength(10)]
        [Required]
        public string ImageDescription { get; set; }
    }
}

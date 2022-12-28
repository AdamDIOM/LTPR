using System.ComponentModel.DataAnnotations;

namespace LTPR.Models
{
    public class tblImages
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public byte[] ImageData { get; set; }
        [Required]
        public string ImageDescription { get; set; }
    }
}

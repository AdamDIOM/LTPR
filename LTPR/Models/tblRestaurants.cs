using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace LTPR.Models
{
    public class tblRestaurants
    {
        [Key]
        public int ID { get; set; }
        [Required, StringLength(25)]
        public string Name { get; set; }
        [Required, StringLength(75)]
        public string Address { get; set; }
        [Required, StringLength(13)]
        public string PhoneNo { get; set; }
        [Required]
        public bool Delivers { get; set; }
    }
}

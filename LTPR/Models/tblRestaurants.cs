using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace LTPR.Models
{
    public class tblRestaurants
    {
        [Key]
        public int ID { get; set; }
        [Required, StringLength(25), MinLength(3)]
        public string Name { get; set; }
        [Required, StringLength(75), MinLength(5)]
        public string Address { get; set; }
        [Required, StringLength(13)]
        public string PhoneNo { get; set; }
        [Required]
        public bool Delivers { get; set; }
    }
}

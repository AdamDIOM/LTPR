using System.ComponentModel.DataAnnotations;

namespace LTPR.Models
{
    public class tblIngredients
    {
        [Key]
        public int ID { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
    }
}

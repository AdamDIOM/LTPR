using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LTPR.Models
{
    public class tblBasket
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string UID { get; set; }
        [Required]
        public int IID { get; set; }
        [Required]
        public int MID { get; set; }
        [Required]
        public int Qty { get; set; }
        
    }
}

﻿using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace LTPR.Models
{
    public class tblItemOnMenu
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int MID { get; set; }
        [Required]
        public int IID { get; set; }
    }
}
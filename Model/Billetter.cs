using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Billetter
    {
        [Key]
        public int billett_id { get; set; }
        [Required]
        public int bestilling_id { get; set; }
        [Required]
        public String billett_type { get; set; }
    }
}
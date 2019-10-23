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
        public Bestillinger bestilling_id { get; set; }
        [Required]
        public string billett_type { get; set; }
    }
}
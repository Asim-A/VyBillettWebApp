using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Billett
    {
        public int billett_id { get; set; }
        public int bestilling_id { get; set; }
        public String billett_type { get; set; }
        public double pris { get; set; }
    }
}
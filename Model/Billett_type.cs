using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Billett_type
    {
        [Key]
        public string billett_type { get; set; }

        public double pris { get; set; }
    }
}

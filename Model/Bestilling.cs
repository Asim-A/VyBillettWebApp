using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Bestilling
    {
        public int ID { get; set; }
        public string fra { get; set; }

        public string til { get; set; }

        public List<Billett> billetter  { get; set; }
        public DateTime reise_dato { get; set; }
        public DateTime? retur_dato { get; set; }
        public DateTime bestilling_dato { get; set; }


    }
}

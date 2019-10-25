using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Bruker
    {
        
        public int bruker_id { get; set; }
       
        public string e_postadresse { get; set; }
        
        public byte[] passord { get; set; }
        
        public DateTime dato { get; set; }
       
        public string salt { get; set; }
    }
}

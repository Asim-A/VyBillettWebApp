﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Bruker
    {
        [Key]
        public int bruker_id { get; set; }
        [Required]
        public string e_postadresse { get; set; }
        [Required]
        public byte[] passord { get; set; }
        [Required]
        public DateTime dato { get; set; }
        [Required]
        public string salt { get; set; }
    }
}

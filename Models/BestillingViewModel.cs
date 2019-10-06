using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VyBillettWebApp.Models
{
    public class BestillingViewModel
    {
        [Display(Name = "Reise Fra:")]
        [Required(ErrorMessage = "Du må velge hvor du skal reise fra")]
        [RegularExpression("[a-zA-ZøæåØÆÅ ]{1,32}", ErrorMessage = "vennligst gi en gyldig destinasjon")]
        public string fra { get; set; }

        [Display(Name = "Reise Til:")]
        [Required(ErrorMessage = "Du må velge hvor du skal reise til")]
        [RegularExpression("[a-zA-ZøæåØÆÅ ]{1,32}", ErrorMessage = "vennligst gi en gyldig destinasjon")]
        public string til { get; set; }

        [Display(Name = "Antall Barn")]
        [Range(0, 10, ErrorMessage ="velg antall barn, maksgrense er 10 per bestilling")]
        public int antall_barn { get; set; }

        [Display(Name = "Antall Studenter")]
        [Range(0, 10, ErrorMessage = "velg antall studenter, maksgrense er 10 per bestilling")]
        public int antall_studenter { get; set; }

        [Display(Name = "Antall Voksne")]
        [Range(0, 10, ErrorMessage = "velg antall voksne, maksgrense er 10 per bestilling")]
        public int antall_voksne { get; set; }

        [Display(Name = "Reise Dato")]
        public DateTime reise_dato { get; set; }     
        public DateTime reise_dato_tid { get; set; }

        [Display(Name = "Retur Dato")]
        public DateTime retur_dato { get; set; }
        public DateTime retur_dato_tid { get; set; }
    }
}
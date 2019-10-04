using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VyBillettWebApp.Models
{
    public class BestillingViewModel
    {
        [Display(Name = "fra:")]
        [Required(ErrorMessage = "Du må velge hvor du skal reise fra")]
        [RegularExpression("[a-zA-ZøæåØÆÅ]{2,16}", ErrorMessage = "vennligst gi en gyldig destinasjon")]
        public string fra { get; set; }

        [Display(Name = "til:")]
        [Required(ErrorMessage = "Du må velge hvor du skal reise til")]
        [RegularExpression("[a-zA-ZøæåØÆÅ]{2,16}", ErrorMessage = "vennligst gi en gyldig destinasjon")]
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

        [Display(Name = "Reise dato")]
        public DateTime reise_dato_tid { get; set; }     
 
    }
}
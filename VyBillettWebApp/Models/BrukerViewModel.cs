using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VyBillettWebApp.Models
{
    public class BrukerViewModel
    {
        [Display(Name = "E-postadresse")]
        [Required(ErrorMessage = "vennligst fyll ut felt")]
        [RegularExpression(@"^([\w-.]+)@(([[0-9]{1,3}.[0-9]{1,3}.[0-9]{1,3}.)|(([\w-]+.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(]?)$", ErrorMessage = "vennligst oppgi en email på riktig format")]
        public string e_postadresse { get; set; }

        [Required(ErrorMessage = "vennligst fyll ut felt")]

        public string passord { get; set; }
        public string loginErrorMessage { get; set; }
    }
}
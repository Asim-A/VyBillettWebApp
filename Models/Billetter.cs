using System.ComponentModel.DataAnnotations;

namespace VyBillettWebApp.Models
{
    public class Billetter
    {
        [Key]
        public int BillettId { get; set; }
        public string strekning { get; set; }
        public string dato { get; set; }
        public BillettType billett_type { get; set; }
    }
}
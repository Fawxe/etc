using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace technical_prototype.Models
{
    public class PrototypeModel
    {
        [Required]
        public string Account_Type { get; set; }
        [Key]
        public string Acct_Num { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Amount { get; set; }
        public string Store { get; set; }
        public string Location { get; set; }
        public string State { get; set; }
        public string Cardholder_Name { get; set; }
    }
}

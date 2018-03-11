using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace technical_prototype.Models
{
    public class AddRuleModel
    {
        [DataType(DataType.EmailAddress), Display(Name = "Maximum Purchase Limit")]
        [Required]
        public string Maximum_Purchase_Limit { get; set; }
        [Display(Name = "Maximum Purchase Limit")]
        public string other { get; set; }

    }
}


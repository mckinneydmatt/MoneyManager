using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Models.RetirementAcct
{
    public class RetireCreate
    {
        [Required]
        public decimal RtAcctBalance { get; set; }
        
        [Required]
        public string AcctType { get; set; }
        [Key]
        public int AccountId { get; set; }
    }
}

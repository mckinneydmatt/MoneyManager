using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Models.RetirementAcct
{
    public class RetireCreate
    {
        [Key]
        public int AccountId { get; set; }

        [Required]
        public string RtAcctNumber { get; set; }

        [Required]
        public double RtAcctBalance { get; set; }

        [Required]
        public string AcctType { get; set; }
        public int UserAcctNumber { get; set; }

    }
}

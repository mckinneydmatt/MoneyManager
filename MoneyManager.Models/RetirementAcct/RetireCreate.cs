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
        public int RtAcctNumber { get; set; }

        public decimal RtAcctBalance { get; set; }

        public int UserAcctNumber { get; set; }
       
        public string AcctType { get; set; }
       
        public int AccountId { get; set; }
    }
}

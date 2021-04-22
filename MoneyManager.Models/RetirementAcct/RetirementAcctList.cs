using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Models.RetirementAcct
{
    public class RetirementAcctList
    {
        public int UserAcctNumber { get; set; }
       
        public string RtAcctNumber { get; set; }

        public decimal RtAcctBalance { get; set; }

        public string AcctType { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Models
{
    public class SavingsAcctDetail
    {
        public int AccountId { get; set; }

        public int UserAccountNumber { get; set; }

        public string SvAcctName { get; set; }

        public decimal SvAcctBalance { get; set; }
    }
}
